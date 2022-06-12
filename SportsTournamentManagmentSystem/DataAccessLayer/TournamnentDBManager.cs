using MySql.Data.MySqlClient;
using Entities;
using System.Data;
using System.Text;

namespace DataAccessLayer
{
    public class TournamnentDBManager : ICUDTournament, IAutoIncrement, ITournamentReader, ITournamentManager
    {
        MySqlConnection conn = DBConnection.Conn;

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
                cmd.Parameters.AddWithValue("start", t.Info.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("end", t.Info.EndDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("min", t.Info.MinPlayers);
                cmd.Parameters.AddWithValue("max", t.Info.MaxPlayers);
                cmd.Parameters.AddWithValue("location", t.Info.Location);
                cmd.Parameters.AddWithValue("system", t.Info.System.ToString());
                cmd.Parameters.AddWithValue("status", t.Status.ToString());

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

        public void AddUser(Tournament t, User u)
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
                cmd.Parameters.AddWithValue("start", t.Info.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("end", t.Info.EndDate.ToString("yyyy-MM-dd"));
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
                    sql.Append($"SELECT tp.user_id, u.first_name FROM `a_tournament_players` tp INNER JOIN a_user u ON tp.user_id = u.id WHERE tournament_id = @id;");
                }
                else
                {
                    sql.Append($"SELECT tg.game_id, tg.round_id, tg.player_one_id, u.first_name, " +
                        $"tg.player_one_score, tg.player_two_id, us.first_name, tg.player_two_score, tg.winner " +
                        $"FROM a_tournament_game tg " +
                        $"INNER JOIN a_user u ON tg.player_one_id = u.id " +
                        $"INNER JOIN a_user us ON tg.player_two_id = us.id " +
                        $"WHERE tournament_id = @id;");
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
                        PlayerContainer p1 = new PlayerContainer();
                        p1.User = new User(Convert.ToInt32(ds.Tables[1].Rows[i][2]), ds.Tables[1].Rows[i][3].ToString());

                        PlayerContainer p2 = new PlayerContainer();
                        p2.User = new User(Convert.ToInt32(ds.Tables[1].Rows[i][5]), ds.Tables[1].Rows[i][6].ToString());

                        //Game newGame = new Game(Convert.ToInt32(ds.Tables[1].Rows[i][0]), Convert.ToInt32(ds.Tables[1].Rows[i][1]), new User(Convert.ToInt32(ds.Tables[1].Rows[i][2]), ds.Tables[1].Rows[i][3].ToString()), new User(Convert.ToInt32(ds.Tables[1].Rows[i][5]), ds.Tables[1].Rows[i][3].ToString()));
                        Game newGame = new Game(Convert.ToInt32(ds.Tables[1].Rows[i][0]), Convert.ToInt32(ds.Tables[1].Rows[i][1]), p1, p2);


                        if (ds.Tables[1].Rows[i][7] != DBNull.Value)
                        {
                            newGame.AssignResults(Convert.ToInt32(ds.Tables[1].Rows[i][4]), Convert.ToInt32(ds.Tables[1].Rows[i][7]), t);
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
                        users.Add(new User(Convert.ToInt32(ds.Tables[1].Rows[i][0]), ds.Tables[1].Rows[i][1].ToString()));
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