using System.Data.SQLite;

namespace AddressManagerApp.Database
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=address_manager.db;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public static void InitializeDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string createOrganizations = @"
                    CREATE TABLE IF NOT EXISTS Organizations (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Street TEXT,
                        Zip TEXT,
                        City TEXT,
                        Country TEXT
                    );";

                string createStaff = @"
                    CREATE TABLE IF NOT EXISTS Staff (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        PhoneNumber TEXT,
                        Email TEXT,
                        OrganizationId INTEGER,
                        FOREIGN KEY (OrganizationId) REFERENCES Organizations(Id)
                    );";

                using (var command = new SQLiteCommand(createOrganizations, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createStaff, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
