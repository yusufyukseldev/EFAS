using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Dapper;

namespace CorporateFinanceManager
{
    public static class DbHelper
    {
        private const string DbFileName = "FinanceManager.db";
        public static string ConnectionString = $"Data Source={DbFileName};Version=3;";

        // hash
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
                return builder.ToString();
            }
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(DbFileName))
            {
                SQLiteConnection.CreateFile(DbFileName);
            }

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // 1. KULLANICILAR TABLOSU
                string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    PasswordHash TEXT NOT NULL, 
                    HourlyRate REAL NOT NULL
                );";

                // 2. GİDERLER TABLOSU
                string createExpensesTable = @"
                CREATE TABLE IF NOT EXISTS Expenses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Amount REAL NOT NULL,
                    Date TEXT NOT NULL
                );";

                // 3. PERSONELLER TABLOSU 
                string createPersonnelsTable = @"
                CREATE TABLE IF NOT EXISTS Personnels (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL,
                    Department TEXT,
                    HourlyRate REAL NOT NULL
                );";

                // Tabloları veritabanına işle
                connection.Execute(createUsersTable);
                connection.Execute(createExpensesTable);
                connection.Execute(createPersonnelsTable);

                // Admin hesabı kontrolü
                var adminExists = connection.QueryFirstOrDefault("SELECT * FROM Users WHERE Username = 'admin'");
                if (adminExists == null)
                {
                    string adminPassword = "admin123";
                    string hashedPassword = HashPassword(adminPassword);

                    connection.Execute("INSERT INTO Users (Username, PasswordHash, HourlyRate) VALUES ('admin', @Hash, 500)",
                                        new { Hash = hashedPassword });
                }

                // Sistem her açıldığında 'engin' adında bir kullanıcı var mı diye kontrol eder.
                var hocaExists = connection.QueryFirstOrDefault("SELECT * FROM Users WHERE Username = 'engin'");
                if (hocaExists == null)
                {
                    string hocaPassword = "engin123";
                    string hashedPassword = HashPassword(hocaPassword);

                    // Hocanın hesabı için varsayılan saatlik ücreti (HourlyRate) 500 TL olarak ayarlıyoruz
                    connection.Execute("INSERT INTO Users (Username, PasswordHash, HourlyRate) VALUES ('engin', @Hash, 500)",
                                        new { Hash = hashedPassword });
                }
            }

        }

        // VERİ ÇEKMEK İÇİN KULLANILAN BAĞLANTI
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}