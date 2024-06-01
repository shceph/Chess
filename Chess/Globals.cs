using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal static class Globals
    {
        public const string IconPath = "assets/icon.ico";

        public const string ConnectionStringFilePath = "assets/sql_connection_string.txt";

        private static readonly string connectionString = "";
        public static string ConnectionString { get { return connectionString; } }

        private static string username = "";
        public static string Username { get { return username; } }

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

        public static bool SetUsername(string usrname)
        {
            if (usrname.All(char.IsLetterOrDigit))
            {
                username = usrname;
                return true;
            }

            return false;
        }
    }
}
