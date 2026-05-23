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
            btnDashboard = new Button();
            btnExpenses = new Button();
            btnPersonnel = new Button();
            label2 = new Label();
            btnAnalysis = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panelChart = new Panel();
            tabPage2 = new TabPage();
            btnDeleteExpense = new Button();
            btnAddExpense = new Button();
            txtExpenseAmount = new TextBox();
            txtExpenseTitle = new TextBox();
            dgvExpenses = new DataGridView();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            lblResult = new Label();
            btnCalculate = new Button();
            comboBoxExpenses = new ComboBox();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateBlue;
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(btnExpenses);
            panel1.Controls.Add(btnPersonnel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnAnalysis);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(215, 641);
            panel1.TabIndex = 0;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 12F);
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
            btnExpenses.BackColor = Color.White;
            btnExpenses.FlatAppearance.BorderSize = 0;
            btnExpenses.FlatStyle = FlatStyle.Flat;
            btnExpenses.Font = new Font("Segoe UI", 12F);
            btnExpenses.ForeColor = Color.DarkSlateBlue;
            btnExpenses.Location = new Point(23, 278);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(161, 38);
            btnExpenses.TabIndex = 1;
            btnExpenses.Text = "Gider Yönetimi";
            btnExpenses.UseVisualStyleBackColor = false;
            btnExpenses.Click += btnExpenses_Click;
            // 
            // btnPersonnel
            // 
            btnPersonnel.BackColor = Color.White;
            btnPersonnel.FlatAppearance.BorderSize = 0;
            btnPersonnel.FlatStyle = FlatStyle.Flat;
            btnPersonnel.Font = new Font("Segoe UI", 12F);
            btnPersonnel.ForeColor = Color.DarkSlateBlue;
            btnPersonnel.Location = new Point(23, 440);
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
            btnAnalysis.BackColor = Color.White;
            btnAnalysis.FlatAppearance.BorderSize = 0;
            btnAnalysis.FlatStyle = FlatStyle.Flat;
            btnAnalysis.Font = new Font("Segoe UI", 12F);
            btnAnalysis.ForeColor = Color.DarkSlateBlue;
            btnAnalysis.Location = new Point(23, 600);
            btnAnalysis.Name = "btnAnalysis";
            btnAnalysis.Size = new Size(161, 38);
            btnAnalysis.TabIndex = 3;
            btnAnalysis.Text = "Fırsat Maliyet Analizi";
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
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(902, 641);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panelChart);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(894, 613);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelChart
            // 
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(3, 3);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(888, 607);
            panelChart.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnDeleteExpense);
            tabPage2.Controls.Add(btnAddExpense);
            tabPage2.Controls.Add(txtExpenseAmount);
            tabPage2.Controls.Add(txtExpenseTitle);
            tabPage2.Controls.Add(dgvExpenses);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(894, 613);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDeleteExpense
            // 
            btnDeleteExpense.BackColor = Color.WhiteSmoke;
            btnDeleteExpense.FlatAppearance.BorderSize = 0;
            btnDeleteExpense.FlatStyle = FlatStyle.Flat;
            btnDeleteExpense.Font = new Font("Segoe UI", 12F);
            btnDeleteExpense.Location = new Point(455, 68);
            btnDeleteExpense.Name = "btnDeleteExpense";
            btnDeleteExpense.Size = new Size(126, 29);
            btnDeleteExpense.TabIndex = 4;
            btnDeleteExpense.Text = "Seçili Olanı Sil";
            btnDeleteExpense.UseVisualStyleBackColor = false;
            btnDeleteExpense.Click += btnDeleteExpense_Click;
            // 
            // btnAddExpense
            // 
            btnAddExpense.BackColor = Color.WhiteSmoke;
            btnAddExpense.FlatAppearance.BorderSize = 0;
            btnAddExpense.FlatStyle = FlatStyle.Flat;
            btnAddExpense.Font = new Font("Segoe UI", 12F);
            btnAddExpense.Location = new Point(455, 30);
            btnAddExpense.Name = "btnAddExpense";
            btnAddExpense.Size = new Size(126, 29);
            btnAddExpense.TabIndex = 3;
            btnAddExpense.Text = "Harcamayı Ekle";
            btnAddExpense.UseVisualStyleBackColor = false;
            btnAddExpense.Click += btnAddExpense_Click;
            // 
            // txtExpenseAmount
            // 
            txtExpenseAmount.Font = new Font("Segoe UI", 12F);
            txtExpenseAmount.Location = new Point(231, 68);
            txtExpenseAmount.Name = "txtExpenseAmount";
            txtExpenseAmount.Size = new Size(170, 29);
            txtExpenseAmount.TabIndex = 2;
            // 
            // txtExpenseTitle
            // 
            txtExpenseTitle.Font = new Font("Segoe UI", 12F);
            txtExpenseTitle.Location = new Point(231, 30);
            txtExpenseTitle.Name = "txtExpenseTitle";
            txtExpenseTitle.Size = new Size(170, 29);
            txtExpenseTitle.TabIndex = 1;
            // 
            // dgvExpenses
            // 
            dgvExpenses.BackgroundColor = Color.White;
            dgvExpenses.BorderStyle = BorderStyle.None;
            dgvExpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Dock = DockStyle.Bottom;
            dgvExpenses.Location = new Point(3, 154);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(888, 456);
            dgvExpenses.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(894, 613);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lblResult);
            tabPage4.Controls.Add(btnCalculate);
            tabPage4.Controls.Add(comboBoxExpenses);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(894, 613);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(72, 193);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(84, 32);
            lblResult.TabIndex = 2;
            lblResult.Text = "Sonuç";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(74, 149);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(157, 23);
            btnCalculate.TabIndex = 1;
            btnCalculate.Text = "Zaman Maliyetini Hesapla";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click_1;
            // 
            // comboBoxExpenses
            // 
            comboBoxExpenses.FormattingEnabled = true;
            comboBoxExpenses.Location = new Point(74, 98);
            comboBoxExpenses.Name = "comboBoxExpenses";
            comboBoxExpenses.Size = new Size(121, 23);
            comboBoxExpenses.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1117, 641);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
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
        private Label lblResult;
        private Button btnCalculate;
        private ComboBox comboBoxExpenses;
        private Button btnDeleteExpense;
        private Button btnAddExpense;
        private TextBox txtExpenseAmount;
        private TextBox txtExpenseTitle;
        private DataGridView dgvExpenses;
        private Label label2;
    }
}