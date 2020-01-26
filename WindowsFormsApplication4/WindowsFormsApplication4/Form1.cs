using LILAutoClicker;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApplication4
{

    public partial class Form1 : Form
    {
        Thread thread;

        private const int CP_NOCLOSE_BUTTON = 0x200;

        string process;
        string keyToPress;
        int delay;
        int repeatFor;
        int counter;
        Boolean abort = false;

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
            InitializeComponent();

            //this.initProcessList();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            button1.Enabled = true;
            button2.Enabled = false;
        }

        private Boolean validate()
        {
            Boolean ret = true;

            if(process == "")
            {
                MessageBox.Show("Precess must be filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            process = comboBox1.Text;
            keyToPress = textBox2.Text;
            delay = (int) numericUpDown1.Value;
            repeatFor = (int)numericUpDown2.Value;

            if(!this.validate())
            {
                return;
            }

            this.thread = new Thread(new ThreadStart(this.RunThread));

            this.thread.Start();

            button1.Enabled = false;
            button2.Enabled = true;
        }

        delegate void SetTextCallback();

        private void SetText()
        {
            if (this.textBox5.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                this.textBox5.Text = counter.ToString();
            }
        }

        private void performOperation()
        {
            Thread.Sleep(delay);

            SendKeys.SendWait(keyToPress);

            counter++;

            this.SetText();
        }

        private void RunThread()
        {
            int i;

            abort = false;

            try
            {
                Process p = Process.GetProcessesByName(process).First();//.FirstOrDefault();

                if (p != null)
                {
                    IntPtr h = p.MainWindowHandle;
                    SetForegroundWindow(h);

                    if (repeatFor == 0)
                    {
                        while (true)
                        {
                            this.performOperation();
                        }
                    }
                    else
                    {
                        for (i = 0; i < repeatFor; i++)
                        {
                            this.performOperation();
                        }

                        button1.Enabled = true;
                        button2.Enabled = false;
                    }
                }
                
            }
            catch(Exception e)
            {
                if (abort == false)
                {
                    MessageBox.Show("Process cannot be loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            abort = true;

            thread.Abort();

            button1.Enabled = true;
            button2.Enabled = false;
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

            this.SetText();
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

        private void diablo3CrusSeedFarmGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "Diablo III64";
            textBox2.Text = "134";
            numericUpDown1.Value = 300;
        }
    }
}
