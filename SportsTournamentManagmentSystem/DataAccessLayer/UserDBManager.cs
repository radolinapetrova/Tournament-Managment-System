using MySql.Data.MySqlClient;
using Entities;


namespace DataAccessLayer
{
    public class UserDBManager : IUser, IAutoIncrement
    {
        MySqlConnection conn = DBConnection.Conn;

        public User Read(string email, string pass)
        {
            try
            {
                string sql = "SELECT * FROM a_user WHERE email = @email AND password = @pass;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("pass", pass);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                User user = null;

                while (reader.Read())
                {
                    if (reader["id"].Equals(DBNull.Value))
                    {
                        return null;
                    }
                    user = new User(Convert.ToInt32(reader["id"]), reader["first_name"].ToString(), reader["last_name"].ToString(), reader["phone_number"].ToString(), new Account(reader["email"].ToString(), reader["password"].ToString(), reader["salt"].ToString()));
                }
                return user;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Add(User user)
        {
            try
            {
                string sql = "INSERT INTO a_user (first_name, last_name, phone_number, email, password, salt) VALUES (@fname, @lname, @number, @email, @pass, @salt);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("fname", user.FisrtName);
                cmd.Parameters.AddWithValue("lname", user.FamilyName);
                cmd.Parameters.AddWithValue("number", user.Phone);
                cmd.Parameters.AddWithValue("email", user.Account.Email);
                cmd.Parameters.AddWithValue("pass", user.Account.Password);
                cmd.Parameters.AddWithValue("salt", user.Account.Salt);

                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (result != 1)
                {
                    throw new ArgumentException("The insertion in the database was not successfull");
                }

            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);
            }
            finally
            {
                conn.Close();
            }

        }

        public int GetId()
        {
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbi478897' AND TABLE_NAME = 'a_user';";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Database problem", ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
