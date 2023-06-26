using NetLimiter.Service;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NLLM;
using System.Linq;
using static NLMMB.Src.Frm1_func;

namespace NLMMB
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll")]
        public static extern int NtSuspendProcess(IntPtr ProcessHandle);

        [DllImport("ntdll.dll")]
        public static extern int NtResumeProcess(IntPtr ProcessHandle);

        public static readonly NLClient client = new NLClient();
        readonly FormOverlay frm = new FormOverlay();
        public static readonly Settings1 settings = new Settings1();

        public ColorDialog dlg = new ColorDialog();
        public ColorDialog dlg1 = new ColorDialog();
        public ColorDialog dlg2 = new ColorDialog();
        public ColorDialog dlg3 = new ColorDialog();
        public ColorDialog dlg4 = new ColorDialog();
        public ColorDialog dlg5 = new ColorDialog();
        public ColorDialog dlg6 = new ColorDialog();
        public ColorDialog dlg7 = new ColorDialog();
        public ColorDialog dlg8 = new ColorDialog();
        public ColorDialog dlg9 = new ColorDialog();
        public ColorDialog dlg10 = new ColorDialog();
        public ColorDialog dlg11 = new ColorDialog();
        public ColorDialog dlg12 = new ColorDialog();
        public ColorDialog dlg13 = new ColorDialog();
        public ColorDialog dlg14 = new ColorDialog();
        public ColorDialog dlg15 = new ColorDialog();
        public ColorDialog dlg16 = new ColorDialog();
        public ColorDialog dlg17 = new ColorDialog();
        public ColorDialog dlg18 = new ColorDialog();
        public ColorDialog dlg19 = new ColorDialog();
        public ColorDialog dlg20 = new ColorDialog();
        public ColorDialog dlg21 = new ColorDialog();
        public ColorDialog dlg22 = new ColorDialog();
        public ColorDialog dlg23 = new ColorDialog();
        public ColorDialog dlg24 = new ColorDialog();
        public ColorDialog dlg25 = new ColorDialog();
        public ColorDialog dlg26 = new ColorDialog();

        public static bool chk1;
        bool chk2;

        bool mousedown;

        public string path;
        public static int processId;
        public static string processName = "destiny2";

        public Form1()
        {
            InitializeComponent();
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                processId = processes[0].Id;
            }
            catch (Exception)
            {
                MessageBox.Show("Open Destiny 2 before opening the limiter!");
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            frm.Show();
            frm.Hide();
            try
            {
                client.Connect();
            }
            catch (Exception)
            {
                MessageBox.Show("Download Net Limiter");
            }
            ObtainD2path();
            GetHotKeySettings();
            GetSettings();
            DisposeAndCreateFilters();

            gamePause += GamePauseEventHandler;
            blocker += OnPvPLimitRuleEnabled;
            dl3074 += On3074DownRuleEnabled;
            ul3074 += On3074UpRuleEnabled;
            dl7500 += On7500DownRuleEnabled;
            ul7500 += On7500UpRuleEnabled;
            dl27k += On27kDownRuleEnabled;
            ul27k += On27kUpRuleEnabled;
            fullGame += OnFullGameRuleEnabled;
            dl30k += On30kRuleEnabled;
        }


        public void GetSettings()
        {
            button1.BackColor = settings.dlbg3074;
            button1.ForeColor = settings.dlfg3074;
            button2.BackColor = settings.ulbg3074;
            button2.ForeColor = settings.ulfg3074;
            button3.BackColor = settings.dlbg7500;
            button3.ForeColor = settings.dlfg7500;
            button4.BackColor = settings.ulbg7500;
            button4.ForeColor = settings.ulfg7500;
            button5.BackColor = settings.dlbg27k;
            button5.ForeColor = settings.dlfg27k;
            button6.BackColor = settings.ulbg27k;
            button6.ForeColor = settings.ulfg27k;
            button7.BackColor = settings.bgd2ol;
            button7.ForeColor = settings.fgd2ol;
            button8.BackColor = settings.bggp;
            button8.ForeColor = settings.fggp;
            button9.BackColor = settings.bgpvp;
            button9.ForeColor = settings.fgpvp;
            button10.BackColor = settings.bg30kkc;
            button10.ForeColor = settings.fg30kkc;
            button11.BackColor = settings.bglfg;
            button11.ForeColor = settings.fglfg;
            button12.BackColor = settings.bghpved;
            button12.ForeColor = settings.fgpvp;
            button13.BackColor = settings.bg30k;
            button13.ForeColor = settings.fg30k;
            try
            {
                Bitmap newImage = new Bitmap(settings.imagepath);
                panel1.BackgroundImage = newImage;
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception)
            {
                
            }
        }

        public void On3074DownRuleEnabled(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "3074 Down");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button1.BackColor = Color.Red;
                frm.SetLabel5Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button1.BackColor = dlg1.Color;
                button1.BackColor = Settings1.Default.dlbg3074;
                frm.SetLabel5Color(dlg1.Color);
                frm.SetLabel5Color(Settings1.Default.dlbg3074);
            }
        }

        private void On3074UpRuleEnabled(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "3074 Up");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button2.BackColor = Color.Red;
                frm.SetLabel6Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button2.BackColor = dlg3.Color;
                button2.BackColor = Settings1.Default.ulbg3074;
                frm.SetLabel6Color(dlg3.Color);
                frm.SetLabel6Color(Settings1.Default.ulbg3074);
            }
        }

        private void On7500DownRuleEnabled(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "7500 Down");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button3.BackColor = Color.Red;
                frm.SetLabel7Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button3.BackColor = dlg5.Color;
                button3.BackColor = Settings1.Default.dlbg7500;
                frm.SetLabel7Color(dlg5.Color);
                frm.SetLabel7Color(Settings1.Default.dlbg7500);
            }
        }

        private void On7500UpRuleEnabled(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "7500 Up");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button4.BackColor = Color.Red;
                frm.SetLabel8Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button4.BackColor = dlg7.Color;
                button4.BackColor = Settings1.Default.ulbg7500;
                frm.SetLabel8Color(dlg7.Color);
                frm.SetLabel8Color(Settings1.Default.ulbg7500);
            }
        }

        private void On27kDownRuleEnabled(object sender, EventArgs e)
        {
            button5.PerformClick();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "27k Down");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button5.BackColor = Color.Red;
                frm.SetLabel9Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button5.BackColor = dlg9.Color;
                button5.BackColor = Settings1.Default.dlbg27k;
                frm.SetLabel9Color(dlg9.Color);
                frm.SetLabel9Color(Settings1.Default.dlbg27k);
            }
        }

        private void On27kUpRuleEnabled(object sender, EventArgs e)
        {
            button6.PerformClick();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "27k Up");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button6.BackColor = Color.Red;
                frm.SetLabel10Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button6.BackColor = dlg11.Color;
                button6.BackColor = Settings1.Default.ulbg27k;
                frm.SetLabel10Color(dlg11.Color);
                frm.SetLabel10Color(Settings1.Default.ulbg27k);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (chk2 != true)
            {
                chk2 = true;
                button7.BackColor = Color.Green;
                frm.Show();
            }
            else
            {
                chk2 = false;
                button7.BackColor = dlg13.Color;
                button7.BackColor = Settings1.Default.bgd2ol;
                frm.Hide();
            }
        }

        private void GamePauseEventHandler(object sender, EventArgs e)
        {
            if (chk1 != false)
            {
                button8.BackColor = Color.Red;
            }
            else
            {
                button8.BackColor = dlg13.Color;
                button8.BackColor = Settings1.Default.bggp;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.GetProcessesByName(processName)[0];
                int processId = process.Id;
                IntPtr processHandle = Process.GetProcessById(processId).Handle;

                if (chk1 != true)
                {
                    chk1 = true;
                    button8.BackColor = Color.Red;
                    NtSuspendProcess(processHandle);
                }
                else
                {
                    chk1 = false;
                    button8.BackColor = dlg13.Color;
                    button8.BackColor = Settings1.Default.bggp;
                    NtResumeProcess(processHandle);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("D2 is not opened");
            }
        }

        private void OnPvPLimitRuleEnabled(object sender, EventArgs e)
        {
            button9.PerformClick();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "PvP Limit");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button9.BackColor = Color.Red;
                frm.SetLabel1Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button9.BackColor = dlg21.Color;
                button9.BackColor = Settings1.Default.bgpvp;
                frm.SetLabel1Color(dlg21.Color);
                frm.SetLabel1Color(Settings1.Default.bgpvp);
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            client.KillCnnsByFilterId(client.Filters.Find(x => x.Name == "30k").Id);
        }

        private void OnFullGameRuleEnabled(object sender, EventArgs e)
        {
            button11.PerformClick();
        }
        public void Button11_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "Destiny 2");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button11.BackColor = Color.Red;
                frm.SetLabel2Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button11.BackColor = dlg21.Color;
                button11.BackColor = Settings1.Default.bglfg;
                frm.SetLabel2Color(dlg21.Color);
                frm.SetLabel2Color(Settings1.Default.bglfg);
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            client.KillCnnsByFilterId(client.Filters.Find(x => x.Name == "7500 Down").Id);
        }

        private void On30kRuleEnabled(object sender, EventArgs e)
        {
            button13.PerformClick();
        }
        private void Button13_Click(object sender, EventArgs e)
        {
            var filter = client.Filters.Find(x => x.Name == "30k");
            var rule = client.Rules.Find(x => x.FilterId == filter.Id);

            if (rule.IsEnabled != true)
            {
                rule.IsEnabled = true;
                client.UpdateRule(rule);
                button13.BackColor = Color.Red;
                frm.SetLabel4Color(Color.Red);
            }
            else
            {
                rule.IsEnabled = false;
                client.UpdateRule(rule);
                button13.BackColor = dlg25.Color;
                button13.BackColor = Settings1.Default.bg30k;
                frm.SetLabel4Color(dlg25.Color);
                frm.SetLabel4Color(Settings1.Default.bg30k);
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            FormUtility existingForm = Application.OpenForms.OfType<FormUtility>().FirstOrDefault();

            if (existingForm == null)
            {
                FormUtility frm1 = new FormUtility();
                frm1.Show();
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mousex = MousePosition.X;
                int mousey = MousePosition.Y;
                SetDesktopLocation(mousex, mousey);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        public void ForegroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                button1.ForeColor = dlg.Color;
                Settings1.Default.dlfg3074 = dlg.Color;
                Settings1.Default.Save();
            }
        }

        public void BackgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = dlg1.Color;
                Settings1.Default.dlbg3074 = dlg1.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dlg2.ShowDialog() == DialogResult.OK)
            {
                button2.ForeColor = dlg2.Color;
                Settings1.Default.ulfg3074 = dlg2.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dlg3.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = dlg3.Color;
                Settings1.Default.ulbg3074 = dlg3.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dlg4.ShowDialog() == DialogResult.OK)
            {
                button3.ForeColor = dlg4.Color;
                Settings1.Default.dlfg7500 = dlg4.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dlg5.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = dlg5.Color;
                Settings1.Default.dlbg7500 = dlg5.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dlg6.ShowDialog() == DialogResult.OK)
            {
                button4.ForeColor = dlg6.Color;
                Settings1.Default.ulfg7500 = dlg6.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dlg7.ShowDialog() == DialogResult.OK)
            {
                button4.BackColor = dlg7.Color;
                Settings1.Default.ulbg7500 = dlg7.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (dlg8.ShowDialog() == DialogResult.OK)
            {
                button5.ForeColor = dlg8.Color;
                Settings1.Default.dlfg27k = dlg8.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (dlg9.ShowDialog() == DialogResult.OK)
            {
                button5.BackColor = dlg9.Color;
                Settings1.Default.dlbg27k = dlg9.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (dlg10.ShowDialog() == DialogResult.OK)
            {
                button6.ForeColor = dlg10.Color;
                Settings1.Default.ulfg27k = dlg10.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (dlg11.ShowDialog() == DialogResult.OK)
            {
                button6.BackColor = dlg11.Color;
                Settings1.Default.ulbg27k = dlg11.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (dlg12.ShowDialog() == DialogResult.OK)
            {
                button7.ForeColor = dlg12.Color;
                Settings1.Default.fgd2ol = dlg12.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (dlg13.ShowDialog() == DialogResult.OK)
            {
                button7.BackColor = dlg13.Color;
                Settings1.Default.bgd2ol = dlg13.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (dlg14.ShowDialog() == DialogResult.OK)
            {
                button8.ForeColor = dlg14.Color;
                Settings1.Default.fggp = dlg14.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (dlg15.ShowDialog() == DialogResult.OK)
            {
                button8.BackColor = dlg15.Color;
                Settings1.Default.bggp = dlg15.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (dlg16.ShowDialog() == DialogResult.OK)
            {
                button9.ForeColor = dlg16.Color;
                Settings1.Default.fgpvp = dlg16.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (dlg17.ShowDialog() == DialogResult.OK)
            {
                button9.BackColor = dlg17.Color;
                Settings1.Default.bgpvp = dlg17.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (dlg19.ShowDialog() == DialogResult.OK)
            {
                button10.ForeColor = dlg19.Color;
                Settings1.Default.fg30kkc = dlg19.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (dlg20.ShowDialog() == DialogResult.OK)
            {
                button10.BackColor = dlg20.Color;
                Settings1.Default.bg30kkc = dlg20.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (dlg20.ShowDialog() == DialogResult.OK)
            {
                button11.ForeColor = dlg20.Color;
                Settings1.Default.fglfg = dlg20.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (dlg21.ShowDialog() == DialogResult.OK)
            {
                button11.BackColor = dlg21.Color;
                Settings1.Default.bglfg = dlg21.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (dlg22.ShowDialog() == DialogResult.OK)
            {
                button12.ForeColor = dlg22.Color;
                Settings1.Default.fghpved = dlg22.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (dlg23.ShowDialog() == DialogResult.OK)
            {
                button12.BackColor = dlg23.Color;
                Settings1.Default.bghpved = dlg23.Color;
                Settings1.Default.Save();
            }
        }

        private void ForegroundToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (dlg24.ShowDialog() == DialogResult.OK)
            {
                button13.ForeColor = dlg24.Color;
                Settings1.Default.fg30k = dlg24.Color;
                Settings1.Default.Save();
            }
        }

        private void BackgroundToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (dlg25.ShowDialog() == DialogResult.OK)
            {
                button13.BackColor = dlg25.Color;
                Settings1.Default.bg30k = dlg25.Color;
                Settings1.Default.Save();
            }
        }

        private void ErmWhatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Settings1.Default.imagepath = openFileDialog.FileName;
                    Settings1.Default.Save();
                    Bitmap newImage = new Bitmap(openFileDialog.FileName);
                    panel1.BackgroundImage = newImage;
                    panel1.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You probably used some image from Google images");
            }
        }
    }
}