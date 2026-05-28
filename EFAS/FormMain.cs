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
            LoadDashboardStats();
        }
        private void LoadDashboardStats()
        {
            using (var connection = DbHelper.GetConnection())
            {
                // 1. Sistemdeki toplam çalışan sayısını saydırıyoruz
                int totalUsers = connection.QueryFirstOrDefault<int>("SELECT COUNT(Id) FROM Users");
                lblTotalPersonnel.Text = totalUsers.ToString() + " Kişi";

                // 2. Şirketin o ana kadarki toplam masrafını toplatıyoruz (Veri yoksa hata vermemesi için Null kontrolü ekledik)
                double totalExpense = connection.QueryFirstOrDefault<double?>("SELECT SUM(Amount) FROM Expenses") ?? 0;
                // "C0" formatı sayının sonuna otomatik TL simgesi ve binlik ayıracı (nokta) koyar
                lblTotalExpense.Text = totalExpense.ToString("N0") + " ₺";

                // 3. Şirketteki tüm personelin saatlik efor maliyetinin ortalamasını alıyoruz
                double avgRate = connection.QueryFirstOrDefault<double?>("SELECT AVG(HourlyRate) FROM Users WHERE HourlyRate > 0") ?? 0;
                lblAvgCost.Text = Math.Round(avgRate, 1).ToString() + " ₺ / Saat";
            }
        }
        private void LoadDashboardChart()
        {
            panelChart.Controls.Clear();
            LiveCharts.WinForms.CartesianChart myChart = new LiveCharts.WinForms.CartesianChart();
            myChart.Dock = DockStyle.Fill;
            panelChart.Controls.Add(myChart);

            using (var connection = DbHelper.GetConnection())
            {
                var expenses = connection.Query("SELECT Title, Amount FROM Expenses").AsList();

                var labels = new List<string>();
                var values = new LiveCharts.ChartValues<double>();

                foreach (var expense in expenses)
                {
                    labels.Add((string)expense.Title);
                    values.Add(Convert.ToDouble(expense.Amount));
                }

                // Tavan boşluğu için dizideki en yüksek harcamayı buluyoruz (Liste boşsa 1000 baz alınır)
                double maxAmount = values.Count > 0 ? values.Max() : 1000;

                var columnSeries = new LiveCharts.Wpf.ColumnSeries
                {
                    Title = "Gider Tutarı",
                    Values = values,
                    DataLabels = true,
                    MaxColumnWidth = 60,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(60, 179, 113)),
                    // Çubukların tepesinde yazan rakamları (Örn: 20000) daha koyu ve belirgin yaptık
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 30, 30))
                };

                myChart.Series.Add(columnSeries);

                // ==========================================
                // ALT EKSEN (Harcama Kalemleri - Daha Büyük Yazı)
                // ==========================================
                myChart.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Harcama Kalemleri",
                    Labels = labels,
                    Separator = new LiveCharts.Wpf.Separator { Step = 1, IsEnabled = false },
                    FontSize = 14, // Yazıları büyüttük
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(40, 40, 40)) // Silik griden koyu, tok bir renge geçtik
                });

                // ==========================================
                // SOL EKSEN (Maliyet - Tavan Boşluğu Eklendi)
                // ==========================================
                myChart.AxisY.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Maliyet (TL)",
                    LabelFormatter = value => value.ToString("N0") + " ₺",
                    MinValue = 0,
                    MaxValue = maxAmount * 1.2, // İŞTE SİHİR BURADA: Tavanı %20 oranında yukarı çekerek grafiğe nefes aldırır
                    FontSize = 13, // Yazıları büyüttük
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(40, 40, 40))
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
                LoadDashboardStats();
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
                LoadDashboardStats();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 1. Kutudaki maliyeti (txtBoxB) rakam olarak almayı deniyoruz
            if (!double.TryParse(txtBoxB.Text, out double hedefMaliyet))
            {
                MessageBox.Show("Lütfen maliyet kısmına geçerli bir rakam (Örn: 50000) giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Kutudaki yatırım adını (txtBoxA) alıyoruz
            string yatirimAdi = txtBoxA.Text;

            using (var connection = DbHelper.GetConnection())
            {
                // 3. Veritabanına bağlanıp personelin "Ortalama Saatlik Ücretini" buluyoruz
                double ortalamaSaatlikUcret = connection.QueryFirstOrDefault<double?>("SELECT AVG(HourlyRate) FROM Users WHERE HourlyRate > 0") ?? 0;

                // 4. Eğer sistemde hiç saatlik ücreti olan personel yoksa uyaralım
                if (ortalamaSaatlikUcret == 0)
                {
                    MessageBox.Show("Sistemde saatlik ücreti girilmiş aktif personel bulunamadı. Lütfen 'Personel' sekmesinden çalışan ekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5. BÜYÜK HESAPLAMA (Maliyet / Ortalama Saatlik Ücret)
                double gerekenSaat = hedefMaliyet / ortalamaSaatlikUcret;

                // 6. Sonucu ve formülü hocanın şak diye anlayacağı rapor formatında yazdırıyoruz
                lblSonuc.Text = $"--- EFOR MALİYETİ ANALİZ RAPORU ---\n\n" +
                                $"Hedeflenen Yatırım: {yatirimAdi}\n" +
                                $"Yatırım Bedeli: {hedefMaliyet.ToString("N0")} ₺\n" +
                                $"Şirket Ort. Personel Maliyeti: {Math.Round(ortalamaSaatlikUcret, 1)} ₺ / Saat\n" +
                                $"--------------------------------------------------\n" +
                                $"📌 SONUÇ: ({hedefMaliyet.ToString("N0")} ₺ / {Math.Round(ortalamaSaatlikUcret, 1)} ₺)\n\n" +
                                $"Bu yatırımın maliyetini amorti etmek için ekibinizin\n" +
                                $"toplam {Math.Round(gerekenSaat, 1)} SAAT efor üretmesi gerekmektedir.";
            }
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