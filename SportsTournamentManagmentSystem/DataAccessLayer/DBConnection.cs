using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public static class DBConnection
    {
        static MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;uid=dbi478897;database=dbi478897;password=R@d!0252;");

        public static MySqlConnection Conn { get { return conn; } }
    }
}
