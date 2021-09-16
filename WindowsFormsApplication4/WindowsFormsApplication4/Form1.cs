using LILAutoClicker;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication4
{

    public partial class Form1 : Form
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
        private int     localCounter;
        Boolean         abort = false;
        private bool    reset = false;
        private bool    running = false;

 
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        private void initProcessList()
        {
            comboBox1.Items.Clear();

            System.Diagnostics.Process[] allProcesses = Process.GetProcesses();

            foreach (System.Diagnostics.Process i in allProcesses)
            {
                comboBox1.Items.Add(i.ProcessName);
            }
        }

        public Form1()
        {
            base.KeyPreview = true;
            InitializeComponent();
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void setRunningWindowsTitle()
        {
            if (!reset)
            {
                if (counter == 0 || counter % 4 == 0)
                {
                    Text = "LILAutoClicker Running";
                }
                if (counter % 4 == 1)
                {
                    Text = "LILAutoClicker Running.";
                }
                if (counter % 4 == 2)
                {
                    Text = "LILAutoClicker Running..";
                }
                if (counter % 4 == 3)
                {
                    Text = "LILAutoClicker Running...";
                }
            }
        }

        private Boolean validate()
        {
            Boolean ret = true;

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

        private void button1_Click(object sender, EventArgs e)
        {
            startProcess();
        }
        
        private void SetText()
        {
            if (textBox5.InvokeRequired)
            {
                SetTextCallback method = SetText;
                Invoke(method, new object[0]);
            }
            else
            {
                textBox5.Text = counter.ToString();
                setRunningWindowsTitle();
            }
        }

        private void startProcess()
        {
            process = comboBox1.Text;
            keyToPress = textBox2.Text;
            delay = (int)numericUpDown1.Value;
            repeatFor = (int)numericUpDown2.Value;

            if (validate())
            {
                thread = new Thread(RunThread);
                thread.Start();
                button1.Enabled = false;
                button2.Enabled = true;
                reset = false;
                running = true;
            }
        }

        private void stopProcess()
        {
            abort = true;
            thread.Abort();
            button1.Enabled = true;
            button2.Enabled = false;
            Text = "LILAutoClicker";
            localCounter = 0;
            running = false;
        }

        private void performOperation()
        {
            Thread.Sleep(delay + getOffset());
            SendKeys.SendWait(keyToPress);
            counter++;
            localCounter++;
            SetText();
        }

        private bool positiveNegativeOffset()
        {
            Random random = new Random();
            int num = random.Next(1, 100);

            if (num >= 50)
            {
                return true;
            }
            return false;
        }

        private int getOffset()
        {
            int num = 0;

            if (!checkBox1.Checked)
            {
                return 0;
            }

            Random random = new Random();
            num = random.Next(1, 20);

            if (!positiveNegativeOffset())
            {
                num *= -1;
            }
            return num;
        }

        private void SetButton1Enable()
        {
            if (button1.InvokeRequired)
            {
                Button1Enable method = SetButton1Enable;
                Invoke(method, new object[0]);
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void SetButton2Disable()
        {
            if (button2.InvokeRequired)
            {
                Button2Disable method = SetButton2Disable;
                Invoke(method, new object[0]);
            }
            else
            {
                button2.Enabled = false;
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
                        performOperation();
                    }
                }

                for (int i = 0; i < repeatFor; i++)
                {
                    performOperation();
                }

                button1.Enabled = true;
                button2.Enabled = false;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopProcess();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abort = true;

            if (thread != null)
            {
                thread.Abort();
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            counter = 0;
            reset = true;
            SetText();
        }

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.initProcessList();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void aboutLILAutoClickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LILAboutBox about = about = new LILAboutBox();

            about.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abort = true;

            if (thread != null)
            {
                thread.Abort();
            }

            this.Close();
        }

        private void exportConfFile()
        {
            XmlDocument xmlDocument = new XmlDocument();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            string xml = $"<conf><process>{comboBox1.Text}</process><keys>{textBox2.Text}</keys><delay>{numericUpDown1.Value}</delay><repeatfor>{numericUpDown2.Value}</repeatfor><randomize>{checkBox1.Checked}</randomize></conf>";
            xmlDocument.LoadXml(xml);
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlDocument.Save(saveFileDialog.FileName);
            }
        }

        private void importConfFile()
        {
            XmlDocument xmlDocument = new XmlDocument();
            string empty = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                empty = openFileDialog.FileName;
                xmlDocument.Load(empty);
                XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("/conf/process");
                XmlNode xmlNode2 = xmlDocument.DocumentElement.SelectSingleNode("/conf/keys");
                XmlNode xmlNode3 = xmlDocument.DocumentElement.SelectSingleNode("/conf/delay");
                XmlNode xmlNode4 = xmlDocument.DocumentElement.SelectSingleNode("/conf/repeatfor");
                XmlNode xmlNode5 = xmlDocument.DocumentElement.SelectSingleNode("/conf/randomize");
                comboBox1.Text = xmlNode.InnerXml;
                textBox2.Text = xmlNode2.InnerXml;
                numericUpDown1.Value = int.Parse(xmlNode3.InnerXml);
                numericUpDown2.Value = int.Parse(xmlNode4.InnerXml);
                checkBox1.Checked = bool.Parse(xmlNode5.InnerXml);
            }
        }

        private void diablo3CrusSeedFarmGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                exportConfFile();
            }
        }

        private void importConfigurationFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importConfFile();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '<')
            {
                if (!running)
                {
                    startProcess();
                }
                else
                {
                    stopProcess();
                }
            }
        }
    }
}
