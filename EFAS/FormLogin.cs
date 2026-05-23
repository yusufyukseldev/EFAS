using System;
using System.Windows.Forms;
using Dapper;
using CorporateFinanceManager; // DbHelper sınıfımızı tanıması için bunu ekledik
using System.Runtime.InteropServices;

namespace EFAS
{
    public partial class FormLogin : Form
    {
        // Sistem şu an Giriş modunda mı, Kayıt modunda mı onu takip ediyoruz
        bool isRegisterMode = false;

        // Windows'un sürükleme algılayıcılarını projemize dahil ediyoruz
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormLogin()
        {
            InitializeComponent();
            textBox1.PlaceholderText = " Kullanıcı Adı";
            textBox2.PlaceholderText = " Şifre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string plainPassword = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(plainPassword))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = DbHelper.HashPassword(plainPassword);

            using (var connection = DbHelper.GetConnection())
            {
                if (isRegisterMode)
                {
                    // ==========================================
                    // KUTUSUZ ÜYE OLMA İŞLEMİ
                    // ==========================================
                    var existingUser = connection.QueryFirstOrDefault("SELECT * FROM Users WHERE Username = @User", new { User = username });
                    if (existingUser != null)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor. Lütfen başka bir ad seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    // Saatlik ücreti kullanıcıyı yormamak için varsayılan olarak 0 (sıfır) atıyoruz
                    string insertQuery = "INSERT INTO Users (Username, PasswordHash, HourlyRate) VALUES (@User, @Pass, 0)";
                    connection.Execute(insertQuery, new { User = username, Pass = hashedPassword });

                    MessageBox.Show("Kayıt başarılı! Şimdi giriş yapabilirsiniz.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox2.Clear();
                    linkLabel1_LinkClicked(null, null); // Otomatik olarak Giriş moduna geri dön
                }
                else
                {
                    // ==========================================
                    // GİRİŞ YAPMA İŞLEMİ
                    // ==========================================
                    string query = "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @Password";
                    var user = connection.QueryFirstOrDefault(query, new { Username = username, Password = hashedPassword });

                    if (user != null)
                    {
                        FormMain mainForm = new FormMain();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Modu değiştir (Giriş ise Kayıt yap, Kayıt ise Giriş yap)
            isRegisterMode = !isRegisterMode;

            if (isRegisterMode)
            {
                // Ekranı Kayıt Ekranına Çevir
                button1.Text = "Kayıt Ol";
                linkLabel1.Text = "Zaten üye misin? Giriş Yap";
                button1.BackColor = Color.ForestGreen;
                linkLabel1.LinkColor = Color.ForestGreen;
            }
            else
            {
                // Ekranı Giriş Ekranına Çevir
                button1.Text = "Giriş Yap";
                linkLabel1.Text = "Hesabın yok mu? Üye Ol";
                button1.BackColor = Color.DodgerBlue;
                linkLabel1.LinkColor = Color.DodgerBlue;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}