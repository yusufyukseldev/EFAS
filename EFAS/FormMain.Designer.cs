namespace EFAS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label5 = new Label();
            btnDashboard = new Button();
            btnExpenses = new Button();
            btnPersonnel = new Button();
            label2 = new Label();
            btnAnalysis = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel5 = new Panel();
            panel2 = new Panel();
            lblTotalPersonnel = new Label();
            label1 = new Label();
            panel4 = new Panel();
            lblAvgCost = new Label();
            label4 = new Label();
            panel3 = new Panel();
            lblTotalExpense = new Label();
            label3 = new Label();
            panelChart = new Panel();
            tabPage2 = new TabPage();
            btnUpdateExpense = new Button();
            btnDeleteExpense = new Button();
            btnAddExpense = new Button();
            txtExpenseAmount = new TextBox();
            txtExpenseTitle = new TextBox();
            btnExportExcel = new Button();
            dgvExpenses = new DataGridView();
            tabPage3 = new TabPage();
            btnUpdatePersonnel = new Button();
            txtPerUcret = new TextBox();
            btnDeletePersonnel = new Button();
            btnAddPersonnel = new Button();
            txtPerDepartman = new TextBox();
            txtPerAd = new TextBox();
            button3 = new Button();
            dgvPersonel = new DataGridView();
            tabPage4 = new TabPage();
            roundedPanel3 = new RoundedPanel();
            lblSonuc = new Label();
            panel7 = new Panel();
            roundedPanel1 = new RoundedPanel();
            label6 = new Label();
            btnCalculate = new Button();
            txtBoxB = new TextBox();
            txtBoxA = new TextBox();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).BeginInit();
            tabPage4.SuspendLayout();
            roundedPanel3.SuspendLayout();
            panel7.SuspendLayout();
            roundedPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateBlue;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(btnExpenses);
            panel1.Controls.Add(btnPersonnel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnAnalysis);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(215, 857);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 63.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(22, 702);
            label5.Name = "label5";
            label5.Size = new Size(164, 113);
            label5.TabIndex = 5;
            label5.Text = "📈";
            // 
            // btnDashboard
            // 
            btnDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDashboard.BackColor = Color.White;
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.DarkSlateBlue;
            btnDashboard.Location = new Point(23, 132);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(161, 38);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Ana Sayfa";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnExpenses
            // 
            btnExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnExpenses.BackColor = Color.White;
            btnExpenses.Cursor = Cursors.Hand;
            btnExpenses.FlatAppearance.BorderSize = 0;
            btnExpenses.FlatStyle = FlatStyle.Flat;
            btnExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExpenses.ForeColor = Color.DarkSlateBlue;
            btnExpenses.Location = new Point(23, 288);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(161, 38);
            btnExpenses.TabIndex = 1;
            btnExpenses.Text = "Gider Yönetimi";
            btnExpenses.UseVisualStyleBackColor = false;
            btnExpenses.Click += btnExpenses_Click;
            // 
            // btnPersonnel
            // 
            btnPersonnel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPersonnel.BackColor = Color.White;
            btnPersonnel.Cursor = Cursors.Hand;
            btnPersonnel.FlatAppearance.BorderSize = 0;
            btnPersonnel.FlatStyle = FlatStyle.Flat;
            btnPersonnel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPersonnel.ForeColor = Color.DarkSlateBlue;
            btnPersonnel.Location = new Point(23, 444);
            btnPersonnel.Name = "btnPersonnel";
            btnPersonnel.Size = new Size(161, 38);
            btnPersonnel.TabIndex = 2;
            btnPersonnel.Text = "Personel";
            btnPersonnel.UseVisualStyleBackColor = false;
            btnPersonnel.Click += btnPersonnel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 56.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(1, 0);
            label2.Name = "label2";
            label2.Size = new Size(212, 100);
            label2.TabIndex = 4;
            label2.Text = "EFAS";
            label2.Click += label2_Click;
            // 
            // btnAnalysis
            // 
            btnAnalysis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAnalysis.BackColor = Color.White;
            btnAnalysis.Cursor = Cursors.Hand;
            btnAnalysis.FlatAppearance.BorderSize = 0;
            btnAnalysis.FlatStyle = FlatStyle.Flat;
            btnAnalysis.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAnalysis.ForeColor = Color.DarkSlateBlue;
            btnAnalysis.Location = new Point(23, 600);
            btnAnalysis.Name = "btnAnalysis";
            btnAnalysis.Size = new Size(161, 38);
            btnAnalysis.TabIndex = 3;
            btnAnalysis.Text = "Efor Analizi";
            btnAnalysis.UseVisualStyleBackColor = false;
            btnAnalysis.Click += btnAnalysis_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(215, 0);
            tabControl1.MinimumSize = new Size(1100, 700);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1169, 857);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panelChart);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1161, 829);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(panel3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1155, 100);
            panel5.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DodgerBlue;
            panel2.Controls.Add(lblTotalPersonnel);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(2, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 100);
            panel2.TabIndex = 1;
            // 
            // lblTotalPersonnel
            // 
            lblTotalPersonnel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPersonnel.ForeColor = Color.White;
            lblTotalPersonnel.Location = new Point(3, 41);
            lblTotalPersonnel.Name = "lblTotalPersonnel";
            lblTotalPersonnel.Size = new Size(294, 45);
            lblTotalPersonnel.TabIndex = 0;
            lblTotalPersonnel.Text = "0";
            lblTotalPersonnel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(1, 16);
            label1.Name = "label1";
            label1.Size = new Size(299, 21);
            label1.TabIndex = 0;
            label1.Text = "AKTİF PERSONEL";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.BackColor = Color.Crimson;
            panel4.Controls.Add(lblAvgCost);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(861, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 100);
            panel4.TabIndex = 3;
            // 
            // lblAvgCost
            // 
            lblAvgCost.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvgCost.ForeColor = Color.White;
            lblAvgCost.Location = new Point(0, 41);
            lblAvgCost.Name = "lblAvgCost";
            lblAvgCost.Size = new Size(294, 45);
            lblAvgCost.TabIndex = 0;
            lblAvgCost.Text = "0";
            lblAvgCost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(0, 16);
            label4.Name = "label4";
            label4.Size = new Size(294, 21);
            label4.TabIndex = 0;
            label4.Text = "ORTALAMA SAATLİK EFOR";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.BackColor = Color.MediumSeaGreen;
            panel3.Controls.Add(lblTotalExpense);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(444, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 100);
            panel3.TabIndex = 2;
            // 
            // lblTotalExpense
            // 
            lblTotalExpense.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalExpense.ForeColor = Color.White;
            lblTotalExpense.Location = new Point(0, 41);
            lblTotalExpense.Name = "lblTotalExpense";
            lblTotalExpense.Size = new Size(297, 45);
            lblTotalExpense.TabIndex = 0;
            lblTotalExpense.Text = "0";
            lblTotalExpense.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(0, 16);
            label3.Name = "label3";
            label3.Size = new Size(300, 21);
            label3.TabIndex = 0;
            label3.Text = "TOPLAM GİDER BÜTÇESİ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // panelChart
            // 
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(3, 3);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(1155, 823);
            panelChart.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnUpdateExpense);
            tabPage2.Controls.Add(btnDeleteExpense);
            tabPage2.Controls.Add(btnAddExpense);
            tabPage2.Controls.Add(txtExpenseAmount);
            tabPage2.Controls.Add(txtExpenseTitle);
            tabPage2.Controls.Add(btnExportExcel);
            tabPage2.Controls.Add(dgvExpenses);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1161, 829);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnUpdateExpense
            // 
            btnUpdateExpense.Anchor = AnchorStyles.Top;
            btnUpdateExpense.BackColor = Color.SteelBlue;
            btnUpdateExpense.Cursor = Cursors.Hand;
            btnUpdateExpense.FlatAppearance.BorderSize = 0;
            btnUpdateExpense.FlatStyle = FlatStyle.Flat;
            btnUpdateExpense.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateExpense.ForeColor = Color.White;
            btnUpdateExpense.Location = new Point(587, 113);
            btnUpdateExpense.Name = "btnUpdateExpense";
            btnUpdateExpense.Size = new Size(280, 33);
            btnUpdateExpense.TabIndex = 14;
            btnUpdateExpense.Text = "Harcamayı Güncelle";
            btnUpdateExpense.UseVisualStyleBackColor = false;
            btnUpdateExpense.Click += btnUpdateExpense_Click;
            // 
            // btnDeleteExpense
            // 
            btnDeleteExpense.Anchor = AnchorStyles.Top;
            btnDeleteExpense.BackColor = Color.Crimson;
            btnDeleteExpense.Cursor = Cursors.Hand;
            btnDeleteExpense.FlatAppearance.BorderSize = 0;
            btnDeleteExpense.FlatStyle = FlatStyle.Flat;
            btnDeleteExpense.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteExpense.ForeColor = Color.White;
            btnDeleteExpense.Location = new Point(440, 152);
            btnDeleteExpense.Name = "btnDeleteExpense";
            btnDeleteExpense.Size = new Size(280, 33);
            btnDeleteExpense.TabIndex = 13;
            btnDeleteExpense.Text = "Harcamayı Sil";
            btnDeleteExpense.UseVisualStyleBackColor = false;
            btnDeleteExpense.Click += btnDeleteExpense_Click;
            // 
            // btnAddExpense
            // 
            btnAddExpense.Anchor = AnchorStyles.Top;
            btnAddExpense.BackColor = Color.MediumSeaGreen;
            btnAddExpense.Cursor = Cursors.Hand;
            btnAddExpense.FlatAppearance.BorderSize = 0;
            btnAddExpense.FlatStyle = FlatStyle.Flat;
            btnAddExpense.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddExpense.ForeColor = Color.White;
            btnAddExpense.Location = new Point(587, 74);
            btnAddExpense.Name = "btnAddExpense";
            btnAddExpense.Size = new Size(280, 33);
            btnAddExpense.TabIndex = 12;
            btnAddExpense.Text = "Harcamayı Ekle";
            btnAddExpense.UseVisualStyleBackColor = false;
            btnAddExpense.Click += btnAddExpense_Click;
            // 
            // txtExpenseAmount
            // 
            txtExpenseAmount.Anchor = AnchorStyles.Top;
            txtExpenseAmount.BorderStyle = BorderStyle.FixedSingle;
            txtExpenseAmount.Font = new Font("Segoe UI", 14.25F);
            txtExpenseAmount.Location = new Point(294, 113);
            txtExpenseAmount.Name = "txtExpenseAmount";
            txtExpenseAmount.PlaceholderText = "Harcama Tutarı";
            txtExpenseAmount.Size = new Size(280, 33);
            txtExpenseAmount.TabIndex = 11;
            txtExpenseAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // txtExpenseTitle
            // 
            txtExpenseTitle.Anchor = AnchorStyles.Top;
            txtExpenseTitle.BorderStyle = BorderStyle.FixedSingle;
            txtExpenseTitle.Font = new Font("Segoe UI", 14.25F);
            txtExpenseTitle.Location = new Point(294, 74);
            txtExpenseTitle.Name = "txtExpenseTitle";
            txtExpenseTitle.PlaceholderText = "Harcama Adı";
            txtExpenseTitle.Size = new Size(280, 33);
            txtExpenseTitle.TabIndex = 10;
            txtExpenseTitle.TextAlign = HorizontalAlignment.Center;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.BackColor = Color.ForestGreen;
            btnExportExcel.Cursor = Cursors.Hand;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(934, 287);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(219, 33);
            btnExportExcel.TabIndex = 9;
            btnExportExcel.Text = "Excel Olarak Aktar";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // dgvExpenses
            // 
            dgvExpenses.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.BackgroundColor = Color.White;
            dgvExpenses.BorderStyle = BorderStyle.None;
            dgvExpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Location = new Point(2, 336);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(1159, 493);
            dgvExpenses.TabIndex = 0;
            dgvExpenses.CellClick += dgvExpenses_CellClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnUpdatePersonnel);
            tabPage3.Controls.Add(txtPerUcret);
            tabPage3.Controls.Add(btnDeletePersonnel);
            tabPage3.Controls.Add(btnAddPersonnel);
            tabPage3.Controls.Add(txtPerDepartman);
            tabPage3.Controls.Add(txtPerAd);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(dgvPersonel);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1161, 829);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePersonnel
            // 
            btnUpdatePersonnel.Anchor = AnchorStyles.Top;
            btnUpdatePersonnel.BackColor = Color.SteelBlue;
            btnUpdatePersonnel.Cursor = Cursors.Hand;
            btnUpdatePersonnel.FlatAppearance.BorderSize = 0;
            btnUpdatePersonnel.FlatStyle = FlatStyle.Flat;
            btnUpdatePersonnel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdatePersonnel.ForeColor = Color.White;
            btnUpdatePersonnel.Location = new Point(591, 115);
            btnUpdatePersonnel.Name = "btnUpdatePersonnel";
            btnUpdatePersonnel.Size = new Size(280, 33);
            btnUpdatePersonnel.TabIndex = 21;
            btnUpdatePersonnel.Text = "Personeli Güncelle";
            btnUpdatePersonnel.UseVisualStyleBackColor = false;
            btnUpdatePersonnel.Click += btnUpdatePersonnel_Click;
            // 
            // txtPerUcret
            // 
            txtPerUcret.Anchor = AnchorStyles.Top;
            txtPerUcret.BorderStyle = BorderStyle.FixedSingle;
            txtPerUcret.Font = new Font("Segoe UI", 14.25F);
            txtPerUcret.Location = new Point(289, 154);
            txtPerUcret.Name = "txtPerUcret";
            txtPerUcret.PlaceholderText = "Saatlik Ücreti";
            txtPerUcret.Size = new Size(280, 33);
            txtPerUcret.TabIndex = 20;
            txtPerUcret.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDeletePersonnel
            // 
            btnDeletePersonnel.Anchor = AnchorStyles.Top;
            btnDeletePersonnel.BackColor = Color.Crimson;
            btnDeletePersonnel.Cursor = Cursors.Hand;
            btnDeletePersonnel.FlatAppearance.BorderSize = 0;
            btnDeletePersonnel.FlatStyle = FlatStyle.Flat;
            btnDeletePersonnel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeletePersonnel.ForeColor = Color.White;
            btnDeletePersonnel.Location = new Point(591, 153);
            btnDeletePersonnel.Name = "btnDeletePersonnel";
            btnDeletePersonnel.Size = new Size(280, 33);
            btnDeletePersonnel.TabIndex = 19;
            btnDeletePersonnel.Text = "Personeli Sil";
            btnDeletePersonnel.UseVisualStyleBackColor = false;
            btnDeletePersonnel.Click += btnDeletePersonnel_Click;
            // 
            // btnAddPersonnel
            // 
            btnAddPersonnel.Anchor = AnchorStyles.Top;
            btnAddPersonnel.BackColor = Color.MediumSeaGreen;
            btnAddPersonnel.Cursor = Cursors.Hand;
            btnAddPersonnel.FlatAppearance.BorderSize = 0;
            btnAddPersonnel.FlatStyle = FlatStyle.Flat;
            btnAddPersonnel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddPersonnel.ForeColor = Color.White;
            btnAddPersonnel.Location = new Point(591, 75);
            btnAddPersonnel.Name = "btnAddPersonnel";
            btnAddPersonnel.Size = new Size(280, 33);
            btnAddPersonnel.TabIndex = 18;
            btnAddPersonnel.Text = "Personeli Ekle";
            btnAddPersonnel.UseVisualStyleBackColor = false;
            btnAddPersonnel.Click += btnAddPersonnel_Click;
            // 
            // txtPerDepartman
            // 
            txtPerDepartman.Anchor = AnchorStyles.Top;
            txtPerDepartman.BorderStyle = BorderStyle.FixedSingle;
            txtPerDepartman.Font = new Font("Segoe UI", 14.25F);
            txtPerDepartman.Location = new Point(289, 115);
            txtPerDepartman.Name = "txtPerDepartman";
            txtPerDepartman.PlaceholderText = "Personel Departmanı";
            txtPerDepartman.Size = new Size(280, 33);
            txtPerDepartman.TabIndex = 17;
            txtPerDepartman.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPerAd
            // 
            txtPerAd.Anchor = AnchorStyles.Top;
            txtPerAd.BorderStyle = BorderStyle.FixedSingle;
            txtPerAd.Font = new Font("Segoe UI", 14.25F);
            txtPerAd.Location = new Point(289, 76);
            txtPerAd.Name = "txtPerAd";
            txtPerAd.PlaceholderText = "Personel Adı";
            txtPerAd.Size = new Size(280, 33);
            txtPerAd.TabIndex = 16;
            txtPerAd.TextAlign = HorizontalAlignment.Center;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.ForestGreen;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(934, 288);
            button3.Name = "button3";
            button3.Size = new Size(219, 33);
            button3.TabIndex = 15;
            button3.Text = "Excel Olarak Aktar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // dgvPersonel
            // 
            dgvPersonel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPersonel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonel.BackgroundColor = Color.White;
            dgvPersonel.BorderStyle = BorderStyle.None;
            dgvPersonel.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPersonel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonel.Location = new Point(0, 336);
            dgvPersonel.Name = "dgvPersonel";
            dgvPersonel.RowHeadersVisible = false;
            dgvPersonel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonel.Size = new Size(1159, 493);
            dgvPersonel.TabIndex = 14;
            dgvPersonel.CellClick += dgvPersonel_CellClick;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(roundedPanel3);
            tabPage4.Controls.Add(panel7);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1161, 829);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // roundedPanel3
            // 
            roundedPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel3.BackColor = Color.DarkSlateBlue;
            roundedPanel3.Controls.Add(lblSonuc);
            roundedPanel3.Location = new Point(313, 382);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(538, 395);
            roundedPanel3.TabIndex = 11;
            // 
            // lblSonuc
            // 
            lblSonuc.Anchor = AnchorStyles.Top;
            lblSonuc.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSonuc.ForeColor = Color.White;
            lblSonuc.ImageAlign = ContentAlignment.TopRight;
            lblSonuc.Location = new Point(5, 11);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(530, 374);
            lblSonuc.TabIndex = 2;
            lblSonuc.Text = "--- EFOR MALİYETİ ANALİZ RAPORU ---";
            lblSonuc.TextAlign = ContentAlignment.TopCenter;
            lblSonuc.Click += lblResult_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(roundedPanel1);
            panel7.Controls.Add(btnCalculate);
            panel7.Controls.Add(txtBoxB);
            panel7.Controls.Add(txtBoxA);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1161, 326);
            panel7.TabIndex = 10;
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top;
            roundedPanel1.BackColor = Color.LightBlue;
            roundedPanel1.Controls.Add(label6);
            roundedPanel1.Location = new Point(192, 42);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(777, 46);
            roundedPanel1.TabIndex = 10;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(6, 12);
            label6.Name = "label6";
            label6.Size = new Size(763, 20);
            label6.TabIndex = 9;
            label6.Text = "Planladığınız yatırımın şirket bütçesine olan yükünü, ekibinizin üretmesi gereken 'mesai saati' cinsinden analiz eder.";
            label6.Click += label6_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Anchor = AnchorStyles.Top;
            btnCalculate.BackColor = Color.DarkSlateBlue;
            btnCalculate.Cursor = Cursors.Hand;
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(438, 217);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(280, 33);
            btnCalculate.TabIndex = 8;
            btnCalculate.Text = "Zaman Maliyetini Hesapla";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // txtBoxB
            // 
            txtBoxB.Anchor = AnchorStyles.Top;
            txtBoxB.BorderStyle = BorderStyle.FixedSingle;
            txtBoxB.Font = new Font("Segoe UI", 14.25F);
            txtBoxB.Location = new Point(438, 159);
            txtBoxB.Name = "txtBoxB";
            txtBoxB.PlaceholderText = " Maliyeti (Örn: 50000)";
            txtBoxB.Size = new Size(280, 33);
            txtBoxB.TabIndex = 6;
            txtBoxB.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBoxA
            // 
            txtBoxA.Anchor = AnchorStyles.Top;
            txtBoxA.BorderStyle = BorderStyle.FixedSingle;
            txtBoxA.Font = new Font("Segoe UI", 14.25F);
            txtBoxA.Location = new Point(440, 111);
            txtBoxA.Name = "txtBoxA";
            txtBoxA.PlaceholderText = " Yatırım Adı (Örn: Yeni Sunucu)";
            txtBoxA.Size = new Size(280, 33);
            txtBoxA.TabIndex = 5;
            txtBoxA.TextAlign = HorizontalAlignment.Center;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1384, 857);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            MinimumSize = new Size(1400, 873);
            Name = "FormMain";
            Text = "EFAS";
            Load += FormMain_Load;
            Shown += FormMain_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).EndInit();
            tabPage4.ResumeLayout(false);
            roundedPanel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAnalysis;
        private Button btnPersonnel;
        private Button btnExpenses;
        private Button btnDashboard;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Panel panelChart;
        private Label lblSonuc;
        private DataGridView dgvExpenses;
        private Label label2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private Label lblAvgCost;
        private Label label4;
        private Label lblTotalExpense;
        private Label label3;
        private Label lblTotalPersonnel;
        private Panel panel5;
        private Label label5;
        private TextBox txtBoxB;
        private TextBox txtBoxA;
        private Button btnCalculate;
        private Label label6;
        private Panel panel7;
        private Button btnExportExcel;
        private TextBox txtExpenseAmount;
        private TextBox txtExpenseTitle;
        private Button btnDeleteExpense;
        private Button btnAddExpense;
        private RoundedPanel roundedPanel1;
        private TextBox txtPerUcret;
        private Button btnDeletePersonnel;
        private Button btnAddPersonnel;
        private TextBox txtPerDepartman;
        private TextBox txtPerAd;
        private Button button3;
        private DataGridView dgvPersonel;
        private RoundedPanel roundedPanel3;
        private Button btnUpdatePersonnel;
        private Button btnUpdateExpense;
    }
}