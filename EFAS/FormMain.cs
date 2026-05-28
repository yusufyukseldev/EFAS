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


            txtExpenseTitle.PlaceholderText = "Harcama Adı";
            txtExpenseAmount.PlaceholderText = "Harcama Tutarı";

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
            // 1. Önce tabloyu tamamen sıfırlıyoruz
            dgvExpenses.DataSource = null;
            dgvExpenses.Columns.Clear();
            dgvExpenses.AutoGenerateColumns = true;

            using (var connection = DbHelper.GetConnection())
            {
                // 2. WinForms'un hata vermeyen kendi sınıfı DataTable'ı yaratıyoruz
                var dt = new System.Data.DataTable();

                // 3. Dapper ile veriyi "Liste" olarak değil, doğrudan "Tablo" olarak okuyoruz!
                using (var reader = connection.ExecuteReader("SELECT Id, Title AS 'Harcama Kalemi', Amount AS 'Tutar (TL)', Date AS 'Tarih' FROM Expenses"))
                {
                    dt.Load(reader);
                }

                // 4. Jilet gibi temizlenmiş veriyi ekrana basıyoruz
                dgvExpenses.DataSource = dt;

                // 5. Arka planda silme işlemi için duran Id'yi gizliyoruz
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
            if (string.IsNullOrWhiteSpace(txtExpenseTitle.Text) || string.IsNullOrWhiteSpace(txtExpenseAmount.Text))
            {
                MessageBox.Show("Lütfen harcama adını ve tutarını girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtExpenseAmount.Text, out double safeAmount))
            {
                MessageBox.Show("Lütfen tutar kısmına sadece rakam giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = DbHelper.GetConnection())
            {
                string query = "INSERT INTO Expenses (Title, Amount, Date) VALUES (@Title, @Amount, @Date)";
                connection.Execute(query, new { Title = txtExpenseTitle.Text, Amount = safeAmount, Date = DateTime.Now.ToString("dd.MM.yyyy") });

                MessageBox.Show("Harcama başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtExpenseTitle.Clear();
                txtExpenseAmount.Clear();

                // Sistemi anında güncelle
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
            if (dgvExpenses.CurrentRow == null) return;

            int selectedId = Convert.ToInt32(dgvExpenses.CurrentRow.Cells["Id"].Value);

            using (var connection = DbHelper.GetConnection())
            {
                connection.Execute("DELETE FROM Expenses WHERE Id = @Id", new { Id = selectedId });
                MessageBox.Show("Seçilen harcama başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                // --- AKILLI ZAMAN ÇEVİRİSİ MOTORU ---
                string zamanMetni = "";

                if (gerekenSaat < 1)
                {
                    // 1 saatten az ise: 60 ile çarpıp dakikaya çeviriyoruz
                    double dakika = Math.Round(gerekenSaat * 60, 0);
                    zamanMetni = $"{dakika} DAKİKA";
                }
                else if (gerekenSaat > 24)
                {
                    // 24 saatten fazla ise: Günde 8 saatlik mesai üzerinden "İş Gününe" çeviriyoruz
                    double gun = Math.Round(gerekenSaat / 8, 1);
                    zamanMetni = $"{gun} İŞ GÜNÜ";
                }
                else
                {
                    // Normal saat aralığındaysa
                    zamanMetni = $"{Math.Round(gerekenSaat, 1)} SAAT";
                }
                // ------------------------------------

                // 6. Sonucu ve formülü hocanın şak diye anlayacağı rapor formatında yazdırıyoruz
                lblSonuc.Text = $"--- EFOR MALİYETİ ANALİZ RAPORU ---\n\n" +
                                $"Hedeflenen Yatırım: {yatirimAdi}\n" +
                                $"Yatırım Bedeli: {hedefMaliyet.ToString("N0")} ₺\n" +
                                $"Şirket Ort. Personel Maliyeti: {Math.Round(ortalamaSaatlikUcret, 1)} ₺ / Saat\n" +
                                $"--------------------------------------------------\n" +
                                $"📌 SONUÇ: ({hedefMaliyet.ToString("N0")} ₺ / {Math.Round(ortalamaSaatlikUcret, 1)} ₺)\n\n" +
                                $"Bu yatırımın maliyetini amorti etmek için ekibinizin\n" +
                                $"toplam {zamanMetni} efor üretmesi gerekmektedir.";
            }
        }

        private async void FormMain_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100);

            TabloMakyajiniUygula(dgvExpenses);
            TabloMakyajiniUygula(dgvPersonel);

            LoadDashboardChart();
            LoadAnalysisData();
            LoadExpenses();
            LoadDashboardStats();
            LoadPersonnels();
        }

        private void btnDeleteExpense_Click_1(object sender, EventArgs e)
        {

        }


        // Parametre olarak dışarıdan bir DataGridView (dgv) alan genel makyaj metodumuz
        private void TabloMakyajiniUygula(DataGridView dgv)
        {
            // Tablonun genel arka planı ve dış çizgilerini temizliyoruz
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            // Sadece yatay çizgiler kalsın (Modern web sitelerindeki gibi)
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Satırların rengi bir beyaz, bir açık gri olsun (Gözü yormaz)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Fareyle bir satırı seçtiğimizde o iğrenç standart mavi yerine menümüzün rengi olsun
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 90);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // EN ÖNEMLİSİ: Windows'un o çirkin gri başlıklarını ezmek için izni kapatıyoruz!
            dgv.EnableHeadersVisualStyles = false;

            // Başlıkların (Harcama Kalemi, Tutar vs.) rengini sol menüyle uyumlu yapıyoruz
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 75);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            // Tablonun en altındaki o çirkin boş ekleme satırını yok et
            dgv.AllowUserToAddRows = false;

            // Tabloyu sadece "Okunabilir" yap, içindeki yazıları kimse bozamasın
            dgv.ReadOnly = true;

            // Bir hücreye tıklandığında sadece o kutuyu değil, BÜTÜN SATIRI boydan boya seç
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        // 1. PERSONEL TABLOSUNU YÜKLEME (DataTable ve Dapper ile sıfır hata)
        private void LoadPersonnels()
        {
            dgvPersonel.DataSource = null;

            using (var connection = DbHelper.GetConnection())
            {
                var dt = new System.Data.DataTable();

                // SQL Sorgusu: Sütun isimlerini ekrana basılacak şekilde Türkçe ayarlıyoruz
                string query = "SELECT Id, FullName AS 'Ad Soyad', Department AS 'Departman', HourlyRate AS 'Saatlik Ücret (TL)' FROM Personnels";

                using (var reader = connection.ExecuteReader(query))
                {
                    dt.Load(reader);
                }

                dgvPersonel.DataSource = dt;

                // Id sütununu gizle (Silme işlemi için arkada beklesin)
                if (dgvPersonel.Columns["Id"] != null)
                    dgvPersonel.Columns["Id"].Visible = false;
            }
        }

        // 2. YENİ PERSONEL EKLEME
        private void btnAddPersonnel_Click(object sender, EventArgs e)
        {
            // Boş kutu kontrolü
            if (string.IsNullOrWhiteSpace(txtPerAd.Text) || string.IsNullOrWhiteSpace(txtPerUcret.Text))
            {
                MessageBox.Show("Lütfen en azından Personel Adı ve Saatlik Ücret kısımlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ücret kısmına harf girilmesini engelle
            if (!double.TryParse(txtPerUcret.Text, out double safeUcret))
            {
                MessageBox.Show("Lütfen ücret kısmına sadece rakam giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = DbHelper.GetConnection())
            {
                string query = "INSERT INTO Personnels (FullName, Department, HourlyRate) VALUES (@FullName, @Department, @HourlyRate)";
                connection.Execute(query, new { FullName = txtPerAd.Text, Department = txtPerDepartman.Text, HourlyRate = safeUcret });

                MessageBox.Show("Yeni personel sisteme başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPerAd.Clear();
                txtPerDepartman.Clear();
                txtPerUcret.Clear();

                // Listeyi anında güncelle
                LoadPersonnels();

                // Eğer Ana Sayfada personel sayısını gösteren bir metodun varsa onu da tetikle:
                // LoadDashboardStats(); 
            }
        }

        // 3. SEÇİLİ PERSONELİ SİLME
        private void btnDeletePersonnel_Click(object sender, EventArgs e)
        {
            if (dgvPersonel.CurrentRow == null) return;

            int selectedId = Convert.ToInt32(dgvPersonel.CurrentRow.Cells["Id"].Value);
            string selectedName = dgvPersonel.CurrentRow.Cells["Ad Soyad"].Value.ToString();

            // Kurumsal programlarda silmeden önce mutlaka emin misin diye sorulur!
            DialogResult secim = MessageBox.Show($"{selectedName} adlı personeli sistemden silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (secim == DialogResult.Yes)
            {
                using (var connection = DbHelper.GetConnection())
                {
                    connection.Execute("DELETE FROM Personnels WHERE Id = @Id", new { Id = selectedId });
                    LoadPersonnels();
                }
            }
        }


        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Tabloda veri yoksa boşuna dosya oluşturmayalım
            if (dgvExpenses.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak hiçbir harcama bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıya dosyayı nereye kaydedeceğini soran o havalı Windows penceresi
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Uyumlu Dosya (*.csv)|*.csv";
            sfd.FileName = "EFAS_Gider_Raporu_" + DateTime.Now.ToString("dd_MM_yyyy") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    // 1. Önce Sütun Başlıklarını Alıyoruz
                    var headers = dgvExpenses.Columns.Cast<DataGridViewColumn>()
                                          .Where(c => c.Visible) // Sadece ekranda görünenleri (Id hariç) al
                                          .Select(c => c.HeaderText);
                    sb.AppendLine(string.Join(";", headers));

                    // 2. Şimdi Satırları Tek Tek Dönüp İçindeki Verileri Alıyoruz
                    foreach (DataGridViewRow row in dgvExpenses.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>()
                                       .Where(c => dgvExpenses.Columns[c.ColumnIndex].Visible)
                                       .Select(c => c.Value?.ToString().Replace(";", ",")); // Excel karışmasın diye noktalı virgülleri temizliyoruz
                        sb.AppendLine(string.Join(";", cells));
                    }

                    // 3. Dosyayı Masaüstüne (veya seçilen yere) Türkçe Karakter (UTF8) desteğiyle yaz!
                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), new System.Text.UTF8Encoding(true));

                    MessageBox.Show("Kurumsal Excel Raporu başarıyla masaüstüne kaydedildi!", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya oluşturulurken hata çıktı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Tabloda dışa aktarılacak veri var mı diye kontrol ediyoruz
            if (dgvPersonel.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak personel kaydı bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kullanıcıya dosyayı nereye kaydetmek istediğini soran pencereyi açıyoruz
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Uyumlu Dosya (*.csv)|*.csv";
            sfd.FileName = "Personel_Listesi.csv";
            sfd.Title = "Personel Listesini Kaydet";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. TÜRKÇE KARAKTER KALKANI: System.Text.UTF8Encoding(true) sayesinde İ, Ş, Ğ gibi harfler bozulmaz!
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, new System.Text.UTF8Encoding(true)))
                    {
                        // Başlıkları yazdır (Aralarına noktalı virgül koyarak Excel'in sütunları anlamasını sağlıyoruz)
                        for (int i = 0; i < dgvPersonel.Columns.Count; i++)
                        {
                            sw.Write(dgvPersonel.Columns[i].HeaderText);
                            if (i < dgvPersonel.Columns.Count - 1)
                                sw.Write(";");
                        }
                        sw.WriteLine();

                        // Verileri yazdır
                        foreach (DataGridViewRow row in dgvPersonel.Rows)
                        {
                            for (int i = 0; i < dgvPersonel.Columns.Count; i++)
                            {
                                if (!row.IsNewRow)
                                {
                                    // Eğer verinin içinde noktalı virgül varsa Excel'i bozmasın diye temizliyoruz
                                    string cellValue = row.Cells[i].Value?.ToString().Replace(";", "") ?? "";
                                    sw.Write(cellValue);

                                    if (i < dgvPersonel.Columns.Count - 1)
                                        sw.Write(";");
                                }
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("Personel listesi başarıyla Excel formatında kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Eğer dosya o sırada Excel'de açıksa ve sistem üstüne yazamıyorsa çökmemesi için hata yakalama
                    MessageBox.Show("Aktarım sırasında bir hata oluştu. Lütfen dosyanın açık olmadığından emin olun.\n\nHata: " + ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Boşluğa veya başlığa tıklandıysa hata vermesini engelle
            if (e.RowIndex >= 0 && dgvPersonel.CurrentRow != null)
            {
                // Tıklanan satırdaki verileri alıp yukarıdaki kutulara dolduruyoruz
                txtPerAd.Text = dgvPersonel.CurrentRow.Cells["Ad Soyad"].Value.ToString();
                txtPerDepartman.Text = dgvPersonel.CurrentRow.Cells["Departman"].Value?.ToString() ?? "";
                txtPerUcret.Text = dgvPersonel.CurrentRow.Cells["Saatlik Ücret (TL)"].Value.ToString();
            }
        }

        private void btnUpdatePersonnel_Click(object sender, EventArgs e)
        {
            // 1. Tablodan biri seçili mi kontrol et
            if (dgvPersonel.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için önce tablodan bir personel seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kutular boş mu kontrol et
            if (string.IsNullOrWhiteSpace(txtPerAd.Text) || string.IsNullOrWhiteSpace(txtPerUcret.Text))
            {
                MessageBox.Show("Ad Soyad ve Saatlik Ücret alanları boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Ücret kısmına harf girilmesini engelle
            if (!double.TryParse(txtPerUcret.Text, out double safeUcret))
            {
                MessageBox.Show("Lütfen ücret kısmına sadece rakam giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Seçili olan personelin ID'sini arka plandan (gizli sütundan) al
            int selectedId = Convert.ToInt32(dgvPersonel.CurrentRow.Cells["Id"].Value);

            // 5. Veritabanını Güncelle (UPDATE)
            using (var connection = DbHelper.GetConnection())
            {
                string query = "UPDATE Personnels SET FullName = @FullName, Department = @Department, HourlyRate = @HourlyRate WHERE Id = @Id";

                connection.Execute(query, new
                {
                    FullName = txtPerAd.Text,
                    Department = txtPerDepartman.Text,
                    HourlyRate = safeUcret,
                    Id = selectedId
                });

                MessageBox.Show("Personel bilgileri başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kutuları temizle ve tabloyu yenile
                txtPerAd.Clear();
                txtPerDepartman.Clear();
                txtPerUcret.Clear();
                LoadPersonnels();
            }
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Boşluğa tıklandıysa hata verme
            if (e.RowIndex >= 0 && dgvExpenses.CurrentRow != null)
            {
                // Tıklanan satırdaki verileri Gider kutularına doldur
                txtExpenseTitle.Text = dgvExpenses.CurrentRow.Cells["Harcama Kalemi"].Value.ToString();
                txtExpenseAmount.Text = dgvExpenses.CurrentRow.Cells["Tutar (TL)"].Value.ToString();
            }
        }

        private void btnUpdateExpense_Click(object sender, EventArgs e)
        {
            // 1. Seçim ve Boş Kutu Kontrolleri
            if (dgvExpenses.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için tablodan bir harcama seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExpenseTitle.Text) || string.IsNullOrWhiteSpace(txtExpenseAmount.Text))
            {
                MessageBox.Show("Harcama Adı ve Tutarı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtExpenseAmount.Text, out double safeTutar))
            {
                MessageBox.Show("Lütfen tutar kısmına geçerli bir rakam giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Arka plandan seçili harcamanın ID'sini al
            int selectedId = Convert.ToInt32(dgvExpenses.CurrentRow.Cells["Id"].Value);

            // 3. Veritabanında Güncelle (UPDATE)
            using (var connection = DbHelper.GetConnection())
            {
                // Tarihi değiştirmiyoruz, sadece adı ve tutarı güncelliyoruz
                string query = "UPDATE Expenses SET Title = @Title, Amount = @Amount WHERE Id = @Id";

                connection.Execute(query, new
                {
                    Title = txtExpenseTitle.Text,
                    Amount = safeTutar,
                    Id = selectedId
                });

                MessageBox.Show("Harcama kaydı başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ekranı temizle ve tabloyu yenile
                txtExpenseTitle.Clear();
                txtExpenseAmount.Clear();
                LoadExpenses();
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