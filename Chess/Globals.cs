using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public readonly struct Account(Guid id, string username, string password)
    {
        private readonly Guid id = id;
        private readonly string username = username;
        private readonly string password = password;

        public readonly Guid ID { get { return id; } }
        public readonly string Username { get { return username; } }
        public readonly string Password { get { return password; } }

        public static bool UsernameAndPasswordAreValid(string username, string password)
        {
            if (!username.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Your username is not valid. Only ASCII letters and numbers are allowed", "Invalid username");
                return false;
            }

            if (!password.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Your password is not valid. Only ASCII letters and numbers are allowed", "Invalid password");
                return false;
            }

            return true;
        }
    }

    internal static class Globals
    {
        public const string IconPath = "assets/icon.ico";

        public const string ConnectionStringFilePath = "assets/sql_connection_string.txt";

        private static readonly string connectionString = "";
        public static string ConnectionString { get { return connectionString; } }

        private static Account? account = null;
        public static Account? Account { get { return account; } set { account = value; } }

        static Globals()
        {
            try
            {
                connectionString = File.ReadAllText(ConnectionStringFilePath);
            }
            catch
            {
                MessageBox.Show("Couldn't find " + ConnectionStringFilePath + ", which means you won't be able to play online", "Error");
            }
        }

        public static void SetAccountToNull()
        {
            account = null;
        }

        //public static bool SetAccount(Guid id, string username, string password)
        //{
        //    account = new Account(id, username, password);

        //    return false;
        //}
    }
}
