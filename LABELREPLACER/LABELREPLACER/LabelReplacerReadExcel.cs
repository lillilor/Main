using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LABELREPLACER
{
    public partial class LabelReplacerReadExcel : Form
    {
        DataTable dtexcel;

        int totalRows       = 0;
        int totalFound      = 0;
        int totalReplaced   = 0;
        int totalNotFound   = 0;

        const int conlumnIndexStart = 1; // first columns is reserved for linenum
        public LabelReplacerReadExcel()
        {
            string LoadExcelLabelInfoText;

            InitializeComponent();

            LoadExcelLabelInfoText = "Excel file must have tree columns:";
            LoadExcelLabelInfoText += "\n";
            LoadExcelLabelInfoText += "Columns 1 cotains LabelId (without label file) es: 'ViewPallet'";
            LoadExcelLabelInfoText += "\n";
            LoadExcelLabelInfoText += "Columns 2 cotains current text";
            LoadExcelLabelInfoText += "\n";
            LoadExcelLabelInfoText += "Columns 3 cotains new text";
            LoadExcelLabelInfoText += "\n";
            LoadExcelLabelInfoText += "Example:";
            LoadExcelLabelInfoText += "ViewPallet  |   View pallet composition | Náhľad paletovej kompozície";


            LoadExcelLabelInfo.Text = LoadExcelLabelInfoText;
        }

        public DataTable GetData()
        {
            return dtexcel;
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            dtexcel = new DataTable();

            if (fileExt.CompareTo(".xls") == 0)
            {
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            }
            else
            {
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            }

            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                    Microsoft.Office.Interop.Excel.Workbooks books = excel.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook book = books.Open(fileName);
                    Microsoft.Office.Interop.Excel.Worksheet sheet = book.Sheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

                    string sheetName = sheet.Name;

                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter(String.Format("select * from [{0}$]", sheetName), con);
                    oleAdpt.Fill(dtexcel);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dtexcel;
        }

        private void ImportExcelFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel Files (*.xls)|*.xls";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                string filePath = file.FileName;
                string fileExt = Path.GetExtension(filePath);

                try
                {
                    DataTable dtExcel = new DataTable();
                    dtExcel = ReadExcel(filePath, fileExt);

                    DataRowCollection itemColumns = dtExcel.Rows;

                    if (ExcelGotHeader.Checked)
                    {
                        //remove header from excel
                        if (itemColumns != null && itemColumns[0] != null)
                        {
                            itemColumns[0].Delete();
                        }
                    }

                    dataGridView.Visible = true;
                    dataGridView.DataSource = dtExcel;

                    AddLineNumber();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddLineNumber()
        {

            if(GetData() == null)
            {
                return;
            }

            DataRowCollection itemColumns = GetData().Rows;

            int j = 0;

            foreach (DataRow row in itemColumns)
            {
                dataGridView.Rows[j].Cells[0].Value = j + 1;

                j++;
            }
        }

        void LabelFileChoose()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    LabelFilePath.Text = filePath;
                }
            }
        }
        private void LabelFilePathChoose_Click(object sender, EventArgs e)
        {
            LabelFileChoose();
        }

        private bool ValidateField()
        {
            bool ret;

            ret = true;
            
            if(dtexcel == null ||
               dtexcel.Rows.Count == 0)
            {
                MessageBox.Show("No data was found", "LABELREPLACER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ret = false;
            }

            if(ret &&
               LabelFilePath.Text == "")
            {
                MessageBox.Show("Label File path must be filled in", "LABELREPLACER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ret = false;
            }

            return ret;
        }

        private void CheckRows()
        {
            int i = conlumnIndexStart;
            int found;

            DataGridViewCellStyle RedCellStyle = new DataGridViewCellStyle
            {
                ForeColor = Color.Red
            };

            DataGridViewCellStyle GreenCellStyle = new DataGridViewCellStyle
            {
                ForeColor = Color.Green
            };

            foreach (DataGridViewRow row in PreviewDataGrid.Rows)
            {
                if (row.Cells[i].Value != null)
                {
                    string labelId = row.Cells[i].Value.ToString(); i++;
                    string oldLabel = row.Cells[i].Value.ToString(); i++;
                    string newLabel = row.Cells[i].Value.ToString(); i++;

                    found = OccurencesFound(LabelFilePath.Text, oldLabel);

                    if (found == 0)
                    {
                        row.DefaultCellStyle = RedCellStyle;

                        row.Cells[i].Value = "ERROR";
                    }

                    if (found == 1)
                    {
                        row.DefaultCellStyle = GreenCellStyle;
                    }

                    i = conlumnIndexStart;
                }
            }
        }

        private DialogResult PromptDoReplace()
        {
            DialogResult result = MessageBox.Show("Do you want to continue?", "LABELREPLACER",
                                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            return result;
        }

        private void DoReplace(bool previeMode)
        {
            int i           = conlumnIndexStart;
            totalRows       = 0;
            totalFound      = 0;
            totalReplaced   = 0;
            totalNotFound   = 0;
            bool found;

            if (!ValidateField())
            {
                return;
            }

            if (previeMode && PreviewDataGrid.Rows.Count > 0)
            {
                PreviewDataGrid.Rows.Clear();
                PreviewDataGrid.Refresh();
            }

            if (previeMode)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {

                    if (row.Cells[i].Value != null)
                    {
                        string labelId  = row.Cells[i].Value.ToString(); i++;
                        string oldLabel = row.Cells[i].Value.ToString(); i++;
                        string newLabel = row.Cells[i].Value.ToString();

                        found = PerformReplacePreview(labelId, oldLabel, newLabel);

                        totalRows++;

                        if (!found)
                        {
                            totalNotFound++;
                        }

                        i = conlumnIndexStart;
                    }

                    CheckRows();
                }
            }
            else
            {
                if (PromptDoReplace() == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in PreviewDataGrid.Rows)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            string labelId = row.Cells[i].Value.ToString(); i++;
                            string oldLabel = row.Cells[i].Value.ToString(); i++;
                            string newLabel = row.Cells[i].Value.ToString();

                            try
                            {
                                found = PerformReplace(oldLabel, newLabel);

                                totalRows++;

                                if (!found)
                                {
                                    totalNotFound++;
                                }

                                i = conlumnIndexStart;
                            }
                            catch
                            {
                                //MessageBox.Show("Operation conceled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        }
                    }
                }
            }

            ShowInfo();
        }

        private void ShowInfo()
        {
            if ((totalRows == totalFound) &&
               (totalFound == totalReplaced))
            {
                MessageBox.Show(String.Format("Total: {0}\nFound: {1}\nReplaced: {2}\nNot Found: {3}", totalRows, totalFound, totalReplaced, totalNotFound), "LABELREPLACER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(String.Format("Total: {0}\nFound: {1}\nReplaced: {2}\nNot Found: {3}", totalRows, totalFound, totalReplaced, totalNotFound), "LABELREPLACER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            DoReplace(true);
        }

        private int OccurencesFound(string path, string value)
        {
            int occurences = 0;

            using (StreamReader sr = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);

                for (int x = 0; x < lines.Length - 1; x++)
                {
                    if (value == lines[x])
                    {
                        occurences++;
                    }
                }

                sr.Close();
            }

            return occurences;
        }

        private bool PerformReplace(string _oldLabel, string _newLabel)
        {
            int found = 0;
           
            try
            {
                string oldTxt, newTxt;
                oldTxt = _oldLabel;
                newTxt = _newLabel;

                found = OccurencesFound(LabelFilePath.Text, oldTxt);

                if (found == 0)
                {
                    // MessageBox.Show(String.Format("'{0}' not found in file", _oldLabel), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string text = File.ReadAllText(LabelFilePath.Text);
                    text = text.Replace(oldTxt, newTxt);
                    File.WriteAllText(LabelFilePath.Text, text);

                    found = OccurencesFound(LabelFilePath.Text, newTxt);
                                        
                    totalFound++;

                    totalReplaced++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw ex;
            }

            return found == 1;
        }

        private Boolean PerformReplacePreview(string _labelId, string _oldLabel, string _newLabel)
        {
           int found = 0;

            try
            {
                string oldTxt, newTxt;
                int replaced = 0;

                oldTxt = _labelId + "=" + _oldLabel;
                newTxt = _labelId + "=" + _newLabel;

                int i = 1;
                int j = PreviewDataGrid.Rows.Add();

                PreviewDataGrid.Rows[j].Cells[0].Value = j+1;
                PreviewDataGrid.Rows[j].Cells[i].Value = _labelId; i++;
                PreviewDataGrid.Rows[j].Cells[i].Value = oldTxt;   i++;
                PreviewDataGrid.Rows[j].Cells[i].Value = newTxt;

                found = OccurencesFound(LabelFilePath.Text, oldTxt);

                if (found == 0)
                {
                    // MessageBox.Show(String.Format("'{0}' not found in file", _oldLabel), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    replaced = OccurencesFound(LabelFilePath.Text, newTxt);
                                        
                    totalFound++;
                    totalReplaced++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);             
            }

            return found == 1;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            DoReplace(false);
        }

        private void GeneratePreviewButton_Click(object sender, EventArgs e)
        {
            DoReplace(true);
        }

        private void DataGridView_Sorted(object sender, EventArgs e)
        {
            AddLineNumber();
        }

        private void ImportExcelFileButton_Click(object sender, EventArgs e)
        {
            ImportExcelFile();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ExcelParametersGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}

