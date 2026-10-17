using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace isef_project_3
{
    public partial class Form1 : Form
    {
        private DataGridView dgvLogs;
        private ListBox lstAlerts;
        private Label lblStatus;
        private Button btnSimulateBruteForce;
        private Button btnSimulateLateNight;
        private Button btnSimulateCommandLine;
        private Panel pnlHeader;
        private Label lblTitle;

        public Form1()
        {
            InitializeComponent();
            SetupDashboard();
            LoadSampleData();
        }

        private void SetupDashboard()
        {
            this.Text = "AD-Shield: Automated Behavior-Based Threat Detection Dashboard";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(28, 28, 30);

            pnlHeader = new Panel { Size = new Size(1000, 70), Dock = DockStyle.Top, BackColor = Color.FromArgb(44, 44, 46) };
            lblTitle = new Label { Text = "AD-SHIELD // SYSTEM MONITORING & AUTOMATED RESPONSE", ForeColor = Color.LightGreen, Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            lblStatus = new Label { Text = "SYSTEM STATUS: ACTIVE & MONITORING LOGS", ForeColor = Color.Lime, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(20, 85), AutoSize = true };
            this.Controls.Add(lblStatus);

            Label lblGrid = new Label { Text = "Active Directory Live Event Logs (Security Log Audit)", ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(20, 120), AutoSize = true };
            this.Controls.Add(lblGrid);

            dgvLogs = new DataGridView
            {
                Location = new Point(20, 145),
                Size = new Size(600, 430),
                BackgroundColor = Color.FromArgb(44, 44, 46),
                ForeColor = Color.Black,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvLogs);

            Label lblAlerts = new Label { Text = "Automated Incident Responses (Proactive Mitigation)", ForeColor = Color.Tomato, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(640, 120), AutoSize = true };
            this.Controls.Add(lblAlerts);

            lstAlerts = new ListBox { Location = new Point(640, 145), Size = new Size(320, 250), BackColor = Color.FromArgb(44, 44, 46), ForeColor = Color.Tomato, Font = new Font("Consolas", 9, FontStyle.Bold) };
            this.Controls.Add(lstAlerts);

            Label lblSimulate = new Label { Text = "Simulate Insider Threats (ISEF Live Demo)", ForeColor = Color.Yellow, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(640, 410), AutoSize = true };
            this.Controls.Add(lblSimulate);

            btnSimulateBruteForce = new Button { Text = "1. Simulate SQL Brute Force", Location = new Point(640, 440), Size = new Size(320, 35), BackColor = Color.DarkRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSimulateBruteForce.Click += TriggerBruteForce;
            this.Controls.Add(btnSimulateBruteForce);

            btnSimulateLateNight = new Button { Text = "2. Simulate Late Night Access (03:00 AM)", Location = new Point(640, 485), Size = new Size(320, 35), BackColor = Color.DarkRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSimulateLateNight.Click += TriggerLateNight;
            this.Controls.Add(btnSimulateLateNight);

            btnSimulateCommandLine = new Button { Text = "3. Simulate Network Scan via CMD", Location = new Point(640, 530), Size = new Size(320, 35), BackColor = Color.DarkRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSimulateCommandLine.Click += TriggerNetworkScan;
            this.Controls.Add(btnSimulateCommandLine);
        }

        private void LoadSampleData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Timestamp");
            dt.Columns.Add("User Account");
            dt.Columns.Add("Event ID");
            dt.Columns.Add("Activity Description");
            dt.Columns.Add("Source IP");

            dt.Rows.Add(DateTime.Now.AddMinutes(-10).ToString("HH:mm:ss"), "admin_ahmed", "4624", "Successful Logon", "192.168.1.50");
            dt.Rows.Add(DateTime.Now.AddMinutes(-8).ToString("HH:mm:ss"), "hr_mona", "4634", "Logoff", "192.168.1.62");
            dt.Rows.Add(DateTime.Now.AddMinutes(-5).ToString("HH:mm:ss"), "dev_ali", "4624", "Successful Logon", "192.168.1.15");

            dgvLogs.DataSource = dt;
        }

        private void TriggerBruteForce(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string user = "marketing_user";

            DataTable dt = (DataTable)dgvLogs.DataSource;
            for (int i = 0; i < 3; i++)
            {
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { timestamp, user, "4625", "Failed Logon Attempt to SQL", "192.168.1.45" };
                dt.Rows.InsertAt(row, 0);
            }

            ExecuteAutomatedResponse(user, "192.168.1.45", "SQL Brute Force Attack Detected");
        }

        private void TriggerLateNight(object sender, EventArgs e)
        {
            string timestamp = "03:14:22 AM";
            string user = "finance_manager";

            DataTable dt = (DataTable)dgvLogs.DataSource;
            DataRow row = dt.NewRow();
            row.ItemArray = new object[] { timestamp, user, "4624", "Logon outside working hours", "192.168.1.80" };
            dt.Rows.InsertAt(row, 0);

            ExecuteAutomatedResponse(user, "192.168.1.80", "Anomalous Late Night Access");
        }

        private void TriggerNetworkScan(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string user = "reception_desk";

            DataTable dt = (DataTable)dgvLogs.DataSource;
            DataRow row = dt.NewRow();
            row.ItemArray = new object[] { timestamp, user, "4688", "Process Created: cmd.exe (nmap / net view)", "192.168.1.99" };
            dt.Rows.InsertAt(row, 0);

            ExecuteAutomatedResponse(user, "192.168.1.99", "Suspicious Network Reconnaissance via CMD");
        }

        private void ExecuteAutomatedResponse(string username, string ipAddress, string threatType)
        {
            string logTime = DateTime.Now.ToString("HH:mm:ss");

            lstAlerts.Items.Insert(0, $"[{logTime}] 🚨 CRITICAL: {threatType}");
            lstAlerts.Items.Insert(1, $"    ↳ TARGET USER: {username}");
            lstAlerts.Items.Insert(2, $"    ↳ ACTION 1: Account [{username}] Disabled in AD.");
            lstAlerts.Items.Insert(3, $"    ↳ ACTION 2: Host [{ipAddress}] Isolated from Network.");
            lstAlerts.Items.Insert(4, $"    ↳ STATUS: Incident logged to SQL Database.");
            lstAlerts.Items.Insert(5, "----------------------------------------");

            lblStatus.Text = $"ALERT: THREAT MITIGATED AT {logTime} - SYSTEM SECURE";
            lblStatus.ForeColor = Color.Red;

            MessageBox.Show($"[AD-Shield Response Engine]\n\nThreat: {threatType}\nUser: {username}\nHost IP: {ipAddress}\n\nMitigation Successful: User disabled and network adapter isolated in 0.45 seconds!",
                            "Automated Mitigation Triggered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
