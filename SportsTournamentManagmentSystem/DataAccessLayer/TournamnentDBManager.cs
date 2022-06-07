using MySql.Data.MySqlClient;
using Entities;
using System.Data;
using System.Text;

namespace DataAccessLayer
{
    public class TournamnentDBManager : ICUDTournament, IAutoIncrement, ITournamentReader, ITournamentManager
    {
        MySqlConnection conn = DBConnection.Conn;


        //Gets the tournaments for the users in the web application
        public void Read(List<Tournament> t, int limit, int offset)
        {
            try
            {
                string sql = $"SELECT * FROM a_tournament  WHERE status IN ('open') ORDER BY start_date ASC LIMIT {limit} OFFSET {offset}; SELECT * FROM a_tournament_players WHERE tournament_id IN (SELECT id FROM a_tournament WHERE status = 'open' ORDER BY start_date ASC);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                using (DataSet ds = new DataSet())
                {
                    adapter.Fill(ds);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //Getting the current number of participants without loading all their information
                        //int nr = Convert.ToInt32(ds.Tables[1].Select($"tournament_id = {Convert.ToInt32(ds.Tables[0].Rows[i][0])}"));

                        Tournament tr = new Tournament(Convert.ToInt32(ds.Tables[0].Rows[i][0]), ds.Tables[0].Rows[i][1].ToString(), (Status)Enum.Parse(typeof(Status), ds.Tables[0].Rows[i][10].ToString()), new TournamentInfo(SportType.GetST(ds.Tables[0].Rows[i][2].ToString()), ds.Tables[0].Rows[i][3].ToString(), ds.Tables[0].Rows[0][4].ToString(), ds.Tables[0].Rows[0][5].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString()), Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString()), ds.Tables[0].Rows[0][6].ToString(), TournamentSystem.GetTS(ds.Tables[0].Rows[0][9].ToString())));
                        t.Add(tr);
                    }
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



        //Getting all the tournaments for the staff to access
        public void Read(List<Tournament> t)
        {
            try
            {
                string sql = $"SELECT id, title, status FROM a_tournament;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    t.Add(new Tournament(Convert.ToInt32(reader["id"]), reader["title"].ToString(), (Status)Enum.Parse(typeof(Status), reader["status"].ToString())));
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







        public void Add(Tournament t)
        {

            try
            {
                string sql = "INSERT INTO a_tournament (title, sport_type, description, start_date, end_date, min_players, max_players, location, tournament_system, status) VALUES (@title, @sport, @description, @start, @end, @min, @max, @location, @system, @status);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("sport", t.Info.Sport);
                cmd.Parameters.AddWithValue("title", t.Title);
                cmd.Parameters.AddWithValue("description", t.Info.Description);
                cmd.Parameters.AddWithValue("start", t.Info.StartDate);
                cmd.Parameters.AddWithValue("end", t.Info.EndDate);
                cmd.Parameters.AddWithValue("min", t.Info.MinPlayers);
                cmd.Parameters.AddWithValue("max", t.Info.MaxPlayers);
                cmd.Parameters.AddWithValue("location", t.Info.Location);
                cmd.Parameters.AddWithValue("system", t.Info.System.ToString());
                cmd.Parameters.AddWithValue("status", t.Status);

                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (result != 1)
                {
                    throw new ArgumentException("The insertion in the database was not successfull");
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("Database problem");
            }
            finally
            {
                conn.Close();
            }

        }

        public void AddPlayer(Tournament t, User u)
        {

            try
            {
                string sql = "INSERT INTO a_tournament_players (tournament_id, user_id) VALUES (@t, @u);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("t", t.Id);
                cmd.Parameters.AddWithValue("u", u.Id);

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

        public void Update(Tournament t)
        {
            try
            {
                string sql = "UPDATE a_tournament SET title = @title, location = @location, description = @descr, start_date = @start, end_date = @end, min_players = @min, max_players = @max, sport_type = @sport, tournament_system = @system WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("descr", t.Info.Description);
                cmd.Parameters.AddWithValue("title", t.Title);
                cmd.Parameters.AddWithValue("sport", t.Info.Sport);
                cmd.Parameters.AddWithValue("start", t.Info.StartDate);
                cmd.Parameters.AddWithValue("end", t.Info.EndDate);
                cmd.Parameters.AddWithValue("min", t.Info.MinPlayers);
                cmd.Parameters.AddWithValue("max", t.Info.MaxPlayers);
                cmd.Parameters.AddWithValue("location", t.Info.Location);
                cmd.Parameters.AddWithValue("system", t.Info.System.ToString());
                cmd.Parameters.AddWithValue("id", t.Id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                {
                    throw new ArgumentException("Database problem");
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

        //Canceling a tournament
        public void Cancel(int id)
        {
            try
            {
                string sql = "UPDATE a_tournament SET status = 'canceled' WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Id", id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                {
                    throw new ArgumentException("Database problem");
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

        public void Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM a_tournament WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Id", id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                {
                    throw new ArgumentException("Database problem");
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

        //Getting the next autoincremented id from a table
        public int GetId()
        {
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbi478897' AND TABLE_NAME = 'a_tournament';";

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






        public void GetInfo(Tournament t)
        {
            try
            {
                StringBuilder sql = new StringBuilder();


                sql.Append($"SELECT sport_type, description, start_date, end_date, min_players, max_players, location, tournament_system FROM a_tournament WHERE id = @id;");


                if (t.Status == Status.open || t.Status == Status.closed || t.Status == Status.canceled)
                {
                    sql.Append($"SELECT * from a_tournament_players WHERE tournament_id = @id;");
                }
                else
                {
                    sql.Append($"SELECT * from a_tournament_game WHERE tournament_id = @id;");
                }

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);
                cmd.Parameters.AddWithValue("id", t.Id);
                conn.Open();


                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet ds = new DataSet();


                    adapter.Fill(ds);

                t.AssignTournamentInfo(new TournamentInfo(SportType.GetST(ds.Tables[0].Rows[0][0].ToString()), ds.Tables[0].Rows[0][1].ToString(), ds.Tables[0].Rows[0][2].ToString(), ds.Tables[0].Rows[0][3].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0][4]), Convert.ToInt32(ds.Tables[0].Rows[0][5]), ds.Tables[0].Rows[0][6].ToString(), TournamentSystem.GetTS(ds.Tables[0].Rows[0][7].ToString())));

                //Depending on the status the method either retrieves a list of users of list of games for the tournament
                if (t.Status == Status.scheduled || t.Status == Status.finished)
                {
                    List<Game> games = new List<Game>();


                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        Game newGame = new Game(Convert.ToInt32(ds.Tables[1].Rows[i][1]), Convert.ToInt32(ds.Tables[1].Rows[i][2]), new Player(new User(Convert.ToInt32(ds.Tables[1].Rows[i][3]))), new Player(new User(Convert.ToInt32(ds.Tables[1].Rows[i][5]))));


                        if (ds.Tables[1].Rows[i][7] != DBNull.Value)
                        {
                            newGame.AssignResults(Convert.ToInt32(ds.Tables[1].Rows[i][4]), Convert.ToInt32(ds.Tables[1].Rows[i][6]), t);
                        }

                        games.Add(newGame);
                    }

                    t.AssignGames(games);
                }
                else
                {
                    List<User> users = new List<User>();

                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        users.Add(new User(Convert.ToInt32(ds.Tables[1].Rows[i][1])));
                    }
                    t.AssignUsers(users);
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
    }
}