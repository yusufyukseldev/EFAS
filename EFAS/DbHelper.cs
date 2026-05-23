using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography; // Şifreleme kütüphanesi
using System.Text;
using Dapper;

namespace CorporateFinanceManager
{
    public static class DbHelper
    {
        private const string DbFileName = "FinanceManager.db";
        public static string ConnectionString = $"Data Source={DbFileName};Version=3;";

        // Şifreleri SHA-256 ile geri döndürülemez şekilde şifreleyen (Hash) fonksiyon
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString(); // Örn: 1234 -> 03ac674216f3e15c...
            }
        }

        public static void InitializeDatabase()
        {
            // Dosya hiç yoksa fiziki olarak yarat
            if (!File.Exists(DbFileName))
            {
                SQLiteConnection.CreateFile(DbFileName);
            }

            // Her halükarda bağlan ve tabloların durumunu kontrol et
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Tablolar yoksa oluştur (IF NOT EXISTS hayat kurtarır)
                string createUsersTable = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL,
                PasswordHash TEXT NOT NULL, 
                HourlyRate REAL NOT NULL
            );";

                string createExpensesTable = @"
            CREATE TABLE IF NOT EXISTS Expenses (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Amount REAL NOT NULL,
                Date TEXT NOT NULL
            );";

                connection.Execute(createUsersTable);
                connection.Execute(createExpensesTable);

                // Sisteme daha önce admin eklenmemişse ekle (Çift kayıt olmasını engeller)
                var adminExists = connection.QueryFirstOrDefault("SELECT * FROM Users WHERE Username = 'admin'");
                if (adminExists == null)
                {
                    string adminPassword = "admin123";
                    string hashedPassword = HashPassword(adminPassword);

                    connection.Execute("INSERT INTO Users (Username, PasswordHash, HourlyRate) VALUES ('admin', @Hash, 500)",
                                        new { Hash = hashedPassword });
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}