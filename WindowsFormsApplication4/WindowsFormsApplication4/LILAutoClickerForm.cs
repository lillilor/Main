using LILAutoClicker;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace LIL
{

    public partial class LILAutoClickerForm : Form
    {
        private delegate void SetTextCallback();
        private delegate void Button1Enable();
        private delegate void Button2Disable();

        private const int CP_NOCLOSE_BUTTON = 512;

        Thread          thread;
        string          process;
        string          keyToPress;
        int             delay;
        int             repeatFor;
        int             counter;
        //private int     counterAux;
        bool            abort = false;
        private bool    reset = false;
        public bool            running = false;

 
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        private void InitProcessList()
        {
            ProcessNameComboBox.Items.Clear();

            System.Diagnostics.Process[] allProcesses = Process.GetProcesses();

            foreach (System.Diagnostics.Process i in allProcesses)
            {
                ProcessNameComboBox.Items.Add(i.ProcessName);
            }
        }

        public LILAutoClickerForm()
        {
            base.KeyPreview = true;
            InitializeComponent();
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            Playbutton.Enabled = true;
            Stopbutton.Enabled = false;
        }

        private void SetRunningWindowsTitle()
        {
            if (!reset)
            {
                if (counter == 0 || counter % 4 == 0)
                {
                    Text = "LILAutoClicker [Running]";
                }
                if (counter % 4 == 1)
                {
                    Text = "LILAutoClicker [Running.]";
                }
                if (counter % 4 == 2)
                {
                    Text = "LILAutoClicker [Running..]";
                }
                if (counter % 4 == 3)
                {
                    Text = "LILAutoClicker [Running...]";
                }
            }
        }

        private bool ValidateValue()
        {
            bool ret = true;

            if(process == "")
            {
                MessageBox.Show("Process must be filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ret = false;
            }

            if (ret && keyToPress == "")
            {
                MessageBox.Show("keyToPress must be filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ret = false;
            }

            return ret;
        }

        private void Playbutton_Click(object sender, EventArgs e)
        {
            StartProcess();
        }
        
        private void SetText()
        {
            if (CountertextBox.InvokeRequired)
            {
                SetTextCallback method = SetText;
                Invoke(method, new object[0]);
            }
            else
            {
                CountertextBox.Text = counter.ToString();
                SetRunningWindowsTitle();
            }
        }

        public void StartProcess()
        {
            process = ProcessNameComboBox.Text;
            keyToPress = KeyTextBox.Text;
            delay = (int)DelaynumericUpDown.Value;
            repeatFor = (int)RepeatnumericUpDown.Value;

            if (this.ValidateValue())
            {
                thread = new Thread(RunThread);
                thread.Start();
                Playbutton.Enabled = false;
                Stopbutton.Enabled = true;
                reset = false;
                running = true;
            }
        }

        public void StopProcess()
        {
            abort = true;
            thread.Abort();
            Playbutton.Enabled = true;
            Stopbutton.Enabled = false;
            Text = "LILAutoClicker";
            //counterAux = 0;
            running = false;
        }

        private void PerformOperation()
        {
            Thread.Sleep(delay + GetOffset());
            SendKeys.SendWait(keyToPress);
            counter++;
            //counterAux++;
            SetText();
        }

        private bool PositiveNegativeOffset()
        {
            Random random = new Random();
            int num = random.Next(1, 100);

            if (num >= 50)
            {
                return true;
            }
            return false;
        }

        private int GetOffset()
        {
            if (!RandomcheckBox.Checked)
            {
                return 0;
            }

            Random random = new Random();
            int num = random.Next(1, 20);
            if (!PositiveNegativeOffset())
            {
                num *= -1;
            }

            return num;
        }

        private void SetButton1Enable()
        {
            if (Playbutton.InvokeRequired)
            {
                Button1Enable method = SetButton1Enable;
                Invoke(method, new object[0]);
            }
            else
            {
                Playbutton.Enabled = true;
            }
        }

        private void SetButton2Disable()
        {
            if (Stopbutton.InvokeRequired)
            {
                Button2Disable method = SetButton2Disable;
                Invoke(method, new object[0]);
            }
            else
            {
                Stopbutton.Enabled = false;
            }
        }

        private void RunThread()
        {
            abort = false;
            try
            {
                Process process = Process.GetProcessesByName(this.process).First();

                if (process == null)
                {
                    return;
                }

                IntPtr mainWindowHandle = process.MainWindowHandle;
                SetForegroundWindow(mainWindowHandle);

                if (repeatFor == 0)
                {
                    while (true)
                    {
                        PerformOperation();
                    }
                }

                for (int i = 0; i < repeatFor; i++)
                {
                    PerformOperation();
                }

                Playbutton.Enabled = true;
                Stopbutton.Enabled = false;
            }
            catch (Exception)
            {
                if (!abort)
                {
                    MessageBox.Show("Process cannot be loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    SetButton1Enable();
                    SetButton2Disable();
                }
            }
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            StopProcess();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            abort = true;

            if (thread != null)
            {
                thread.Abort();
            }

            this.Close();
        }

        private void Refreshbutton_Click(object sender, EventArgs e)
        {
            counter = 0;
            reset = true;
            SetText();
        }

        private void ProcessNameComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.InitProcessList();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void AboutLILAutoClickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LILAboutBox about = new LILAboutBox();

            about.Show();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abort = true;

            if (thread != null)
            {
                thread.Abort();
            }

            this.Close();
        }

        private void ExportConfFile()
        {
            XmlDocument xmlDocument = new XmlDocument();
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            string xml = $"<conf><process>{ProcessNameComboBox.Text}</process><keys>{KeyTextBox.Text}</keys><delay>{DelaynumericUpDown.Value}</delay><repeatfor>{RepeatnumericUpDown.Value}</repeatfor><randomize>{RandomcheckBox.Checked}</randomize></conf>";
            xmlDocument.LoadXml(xml);
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlDocument.Save(saveFileDialog.FileName);
            }
        }

        private void ImportConfFile()
        {
            XmlDocument xmlDocument = new XmlDocument();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string empty = openFileDialog.FileName;
                xmlDocument.Load(empty);
                XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("/conf/process");
                XmlNode xmlNode2 = xmlDocument.DocumentElement.SelectSingleNode("/conf/keys");
                XmlNode xmlNode3 = xmlDocument.DocumentElement.SelectSingleNode("/conf/delay");
                XmlNode xmlNode4 = xmlDocument.DocumentElement.SelectSingleNode("/conf/repeatfor");
                XmlNode xmlNode5 = xmlDocument.DocumentElement.SelectSingleNode("/conf/randomize");
                ProcessNameComboBox.Text = xmlNode.InnerXml;
                KeyTextBox.Text = xmlNode2.InnerXml;
                DelaynumericUpDown.Value = int.Parse(xmlNode3.InnerXml);
                RepeatnumericUpDown.Value = int.Parse(xmlNode4.InnerXml);
                RandomcheckBox.Checked = bool.Parse(xmlNode5.InnerXml);
            }
        }

        private void ExportConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidateValue())
            {
                ExportConfFile();
            }
        }

        private void ImportConfigurationFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportConfFile();
        }

        private void LILAutoClickerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '<')
            {
                if (!running)
                {
                    StartProcess();
                }
                else
                {
                    StopProcess();
                }
            }
        }
    }
}
