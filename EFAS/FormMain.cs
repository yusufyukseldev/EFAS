using System;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf; // LiveCharts arka planda WPF grafik motorunu kullanır
using LiveCharts.WinForms;
using Dapper;
using CorporateFinanceManager; // DbHelper için (Eğer EFAS ise EFAS olarak kalsın)
using LiveCharts.Wpf;

namespace EFAS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Form Yüklenirken Çalışacak Kodlar
        private void FormMain_Load(object sender, EventArgs e)
        {
            // PROFESYONEL DOKUNUŞ: TabControl'ün üstteki standart sekmelerini görünmez yapıyoruz.
            // Böylece kullanıcı sayfalar arasında sadece sol menüdeki butonlarımızla geçebilecek.
            this.WindowState = FormWindowState.Maximized;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            LoadDashboardChart();
            LoadAnalysisData();
            LoadExpenses();

            txtExpenseTitle.PlaceholderText = "Harcama Adı";
            txtExpenseAmount.PlaceholderText = "Harcama Tutarı";
        }
        private void LoadDashboardChart()
        {
            // 1. Grafiği temizle ve sıfırdan oluştur
            panelChart.Controls.Clear();
            LiveCharts.WinForms.CartesianChart myChart = new LiveCharts.WinForms.CartesianChart();
            myChart.Dock = DockStyle.Fill;
            panelChart.Controls.Add(myChart);

            // 2. Verileri Veritabanından Çek
            using (var connection = DbHelper.GetConnection())
            {
                // Giderler tablosundaki kalemleri çekiyoruz
                var expenses = connection.Query("SELECT Title, Amount FROM Expenses").AsList();

                // ŞİMDİLİK TEST İÇİN: Eğer veritabanı boşsa sahte veriler ekleyelim ki grafiği görebilelim
                if (expenses.Count == 0)
                {
                    expenses.Add(new { Title = "Sunucu Kirası", Amount = 1500.0 });
                    expenses.Add(new { Title = "Reklam Bütçesi", Amount = 3200.0 });
                    expenses.Add(new { Title = "Ofis Gideri", Amount = 800.0 });
                    expenses.Add(new { Title = "Scooter Bakım", Amount = 1200.0 });
                }

                // 3. Grafiğe Verileri Basma Hazırlığı
                ChartValues<double> values = new ChartValues<double>();
                List<string> labels = new List<string>();

                foreach (var item in expenses)
                {
                    values.Add(Convert.ToDouble(item.Amount));
                    labels.Add(item.Title.ToString());
                }

                // 4. Grafiği Şekillendirme
                myChart.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Tutar (TL)",
                        Values = values
                    }
                };

                // X Ekseni (Alt Taraf - İsimler)
                myChart.AxisX.Add(new Axis
                {
                    Title = "Harcama Kalemleri",
                    Labels = labels,
                    Separator = new Separator { Step = 1, IsEnabled = false }
                });

                // Y Ekseni (Sol Taraf - Sayılar)
                myChart.AxisY.Add(new Axis
                {
                    Title = "Maliyet",
                    LabelFormatter = value => value.ToString("C") // Rakamları TL formatında gösterir
                });
            }
        }
        // 1. ComboBox'ı Harcamalarla Dolduran Metot
        private void LoadAnalysisData()
        {
            using (var connection = DbHelper.GetConnection())
            {
                // Veritabanındaki harcamaları az önce oluşturduğumuz ExpenseModel formatında çekiyoruz
                var expenses = connection.Query<ExpenseModel>("SELECT * FROM Expenses").AsList();

                // Eğer veritabanı boşsa, test için sahte veriler ekleyelim
                if (expenses.Count == 0)
                {
                    expenses.Add(new ExpenseModel { Id = 1, Title = "Performans Kayışı & Yağ Bakımı", Amount = 1500 });
                    expenses.Add(new ExpenseModel { Id = 2, Title = "Protein Tozu Stoğu", Amount = 3200 });
                    expenses.Add(new ExpenseModel { Id = 3, Title = "Yeni Kask (ECE Sertifikalı)", Amount = 4500 });
                }

                comboBoxExpenses.DataSource = expenses;
                comboBoxExpenses.DisplayMember = "DisplayText"; // Ekranda görünen yazı
                comboBoxExpenses.ValueMember = "Amount";        // Arka planda tutulan sayısal değer
            }
        }



        // Programı çarpıdan kapatınca arka planda çalışmaya devam etmemesi için
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        // 1. VERİLERİ TABLOYA ÇEKME (READ)
        private void LoadExpenses()
        {
            // 1. DOKUNUŞ: Tabloya yeni veri basmadan önce içindeki tüm eski/çift sütunları yok ediyoruz!
            dgvExpenses.DataSource = null;
            dgvExpenses.Columns.Clear();

            using (var connection = DbHelper.GetConnection())
            {
                // Dapper ile verileri çekip doğrudan DataGridView'e bağlıyoruz
                var expenses = connection.Query("SELECT Id, Title AS 'Harcama Kalemi', Amount AS 'Tutar (TL)', Date AS 'Tarih' FROM Expenses").AsList();

                dgvExpenses.DataSource = expenses;

                // Id sütununu gizleyelim ki ekranda çirkin durmasın
                if (dgvExpenses.Columns["Id"] != null)
                {
                    dgvExpenses.Columns["Id"].Visible = false;
                }
            }
        }

        // 2. YENİ HARCAMA EKLEME (CREATE)
        // Ekle butonuna çift tıklayıp içine şu kodları yaz:
        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            // 1. KUTULAR BOŞ MU KONTROLÜ
            if (string.IsNullOrWhiteSpace(txtExpenseTitle.Text) || string.IsNullOrWhiteSpace(txtExpenseAmount.Text))
            {
                MessageBox.Show("Lütfen harcama adını ve tutarını girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. SAYI YERİNE HARF GİRİLMİŞ Mİ KONTROLÜ (Hayat kurtaran kısım)
            double safeAmount;
            // TryParse: "İçindeki yazıyı sayıya çevirmeyi dene, yapamazsan bana false dön" demek.
            if (!double.TryParse(txtExpenseAmount.Text, out safeAmount))
            {
                MessageBox.Show("Lütfen tutar kısmına sadece rakam giriniz! (Örn: 1500 veya 1500,50)", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sayı değilse işlemi iptal et ve aşağı inme
            }

            // 3. VERİTABANINA KAYIT İŞLEMİ
            using (var connection = DbHelper.GetConnection())
            {
                string query = "INSERT INTO Expenses (Title, Amount, Date) VALUES (@Title, @Amount, @Date)";

                // Dapper ile parametreleri gönderiyoruz (Artık safeAmount kullanıyoruz)
                connection.Execute(query, new
                {
                    Title = txtExpenseTitle.Text,
                    Amount = safeAmount,
                    Date = DateTime.Now.ToString("dd.MM.yyyy")
                });

                MessageBox.Show("Harcama başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // İşlem bitince kutuları temizle
                txtExpenseTitle.Clear();
                txtExpenseAmount.Clear();

                // Tüm sistemi anında güncelle
                LoadExpenses();
                LoadDashboardChart();
                LoadAnalysisData();
            }
        }

        // 3. SEÇİLİ HARCAMAYI SİLME (DELETE)
        // Sil butonuna çift tıklayıp içine şu kodları yaz:
        private void btnDeleteExpense_Click(object sender, EventArgs e)
        {
            // Tabloda seçili bir satır yoksa hiçbir şey yapma
            if (dgvExpenses.CurrentRow == null) return;

            // Seçili satırın gizli olan 'Id' değerini al
            int selectedId = Convert.ToInt32(dgvExpenses.CurrentRow.Cells["Id"].Value);

            using (var connection = DbHelper.GetConnection())
            {
                connection.Execute("DELETE FROM Expenses WHERE Id = @Id", new { Id = selectedId });
                MessageBox.Show("Seçilen harcama başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Silinince de tüm sistemleri dinamik olarak güncelle
                LoadExpenses();
                LoadDashboardChart();
                LoadAnalysisData();
            }
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            if (comboBoxExpenses.SelectedItem == null) return;

            // ComboBox'tan seçilen harcamanın tutarını al (Örn: 1500)
            double expenseAmount = Convert.ToDouble(comboBoxExpenses.SelectedValue);

            using (var connection = DbHelper.GetConnection())
            {
                // Sistemdeki admin'in saatlik kazancını veritabanından çek (500 TL olarak girmiştik)
                double hourlyRate = connection.QueryFirstOrDefault<double>("SELECT HourlyRate FROM Users WHERE Username = 'admin'");

                if (hourlyRate > 0)
                {
                    // Sihirli formül: Harcama / Saatlik Ücret
                    double hoursNeeded = expenseAmount / hourlyRate;

                    // Sonucu ekrandaki büyük Label'a yazdır
                    lblResult.Text = $"Bu harcamayı amorti etmek için tam\n{Math.Round(hoursNeeded, 1)} SAAT\nçalışmanız gerekmektedir!";
                    lblResult.ForeColor = Color.DarkRed; // Rengi dramatik olsun diye kırmızı yapıyoruz
                }
            }
        }



        private void btnDashboard_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnPersonnel_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    // Bu sınıf, harcamaları ComboBox'ta "İsim (Tutar TL)" şeklinde şık göstermemizi sağlayacak
    public class ExpenseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public string DisplayText => $"{Title} ({Amount} TL)";
    }
}