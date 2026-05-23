namespace EFAS
{
    partial class FormLogin
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            panel1 = new Panel();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(200, 153);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 29);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(200, 198);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(182, 29);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(200, 250);
            button1.Name = "button1";
            button1.Size = new Size(182, 31);
            button1.TabIndex = 2;
            button1.Text = "Giriş Yap";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(19, 424);
            label1.Name = "label1";
            label1.Size = new Size(544, 15);
            label1.TabIndex = 3;
            label1.Text = "🔒 Kullanıcı verileri ve şifreler SHA-256 kriptografi algoritması ile uçtan uca şifrelenerek korunmaktadır.";
            label1.Click += label1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(202, 292);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(180, 21);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Hesabın yok mu? Üye Ol";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateBlue;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(577, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(306, 448);
            panel1.TabIndex = 5;
            panel1.MouseDown += FormLogin_MouseDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Cursor = Cursors.Hand;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(276, 0);
            label5.Name = "label5";
            label5.Size = new Size(27, 30);
            label5.TabIndex = 6;
            label5.Text = "X";
            label5.Click += label5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(52, 100);
            label3.Name = "label3";
            label3.Size = new Size(209, 15);
            label3.TabIndex = 1;
            label3.Text = "Kurumsal Finans ve Efor Analiz Sistemi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 63.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(74, 280);
            label4.Name = "label4";
            label4.Size = new Size(164, 113);
            label4.TabIndex = 0;
            label4.Text = "📈";
            label4.Click += label2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 60F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(43, 9);
            label2.Name = "label2";
            label2.Size = new Size(227, 106);
            label2.TabIndex = 0;
            label2.Text = "EFAS";
            label2.Click += label2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(181, 100);
            label6.Name = "label6";
            label6.Size = new Size(238, 40);
            label6.TabIndex = 6;
            label6.Text = "Hoş Geldiniz 👋";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 448);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(linkLabel1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            MouseDown += FormLogin_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label1;
        private LinkLabel linkLabel1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}