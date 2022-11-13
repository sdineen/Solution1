
using ClassLibrary.Repository.EF;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Examples.SQL
{
    public class ConnectToDatabase
    {
        public static void Main()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=database.db");
            connection.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connection;
            cmd.CommandText = "create table if not exists accounts(id integer primary key, name text not null, password text not null);";
            bool tableCreated = cmd.ExecuteNonQuery() == 1;
            cmd.CommandText = "insert into accounts (name, password) values ('John Smith', 'test'); ";
            int rowsInserted = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine($"table created {tableCreated}, rows inserted {rowsInserted}");
        }

        public static void Using()
        {
            using SqliteConnection connection = new SqliteConnection("Data Source=database.db");
            connection.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connection;
            cmd.CommandText = "create table if not exists accounts(id integer primary key, name text not null, password text not null);";
            try
            {
                bool tableCreated = cmd.ExecuteNonQuery() == 1;
                cmd.CommandText = "insert into accounts (name, password) values ('John Smith', 'test'); ";
                int rowsInserted = cmd.ExecuteNonQuery();
                Console.WriteLine($"table created {tableCreated}, rows inserted {rowsInserted}");
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex);
            }
        }


        public static void WithTransactions()
        {
            string connectionString = "Data Source=database.db";
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();
            SqliteCommand cmd = new SqliteCommand();
            SqliteTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            try
            {
                //valid expression
                cmd.CommandText = "insert into accounts (name, password) values('John Smith', 'test'); ";
                int rowsInserted = cmd.ExecuteNonQuery();
                //invalid expression (no such table)
                cmd.CommandText = "update account set name = 'Jane Smith' where id = 1; ";
                int rowsUpdated = cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine($"updated");
            }
            catch (SqliteException e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
        public static void Products()
        {
            new ProductRepository(new EcommerceContext()).SelectAll().ToList().ForEach(p => Console.WriteLine(p.Name));
        }


    }
}
