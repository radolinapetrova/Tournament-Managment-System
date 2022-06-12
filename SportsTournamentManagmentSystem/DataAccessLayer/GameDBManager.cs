using MySql.Data.MySqlClient;
using Entities;
using System.Data;
using System.Text;

namespace DataAccessLayer
{
    public class GameDBManager : IGame
    {
        MySqlConnection conn = DBConnection.Conn;

        //Adding the scheduled games and setting ste status of the tournament to scheduled
        public void Add(Tournament t)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                for (int i = 0; i < t.Games.Count; i++)
                {
                    sql.Append($"INSERT INTO a_tournament_game (tournament_id, round_id, game_id, player_one_id, player_two_id) VALUES (@tr, @r{i}, @g{i}, @plOne{i}, @plTwo{i});");
                }

                sql.Append("UPDATE a_tournament SET status = 'scheduled' WHERE id = @tr;");

                MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);


                cmd.Parameters.AddWithValue($"tr", t.Id);

                for (int i = 0; i < t.Games.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"r{i}", t.Games[i].RoundNr);
                    cmd.Parameters.AddWithValue($"g{i}", t.Games[i].Id);
                    if (t.Games[i].PlayerOne.User == null && t.Games[i].PlayerTwo.User == null)
                    {
                        cmd.Parameters.AddWithValue($"plOne{i}", null);
                        cmd.Parameters.AddWithValue($"plTwo{i}", null);
                    }
                    else
                    {
                        if (t.Games[i].PlayerOne.User == null)
                        {
                            cmd.Parameters.AddWithValue($"plOne{i}", null);
                            cmd.Parameters.AddWithValue($"plTwo{i}", t.Games[i].PlayerTwo.User.Id);
                        }
                        else if (t.Games[i].PlayerTwo.User == null)
                        {
                            cmd.Parameters.AddWithValue($"plOne{i}", t.Games[i].PlayerOne.User.Id);
                            cmd.Parameters.AddWithValue($"plTwo{i}", null);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue($"plOne{i}", t.Games[i].PlayerOne.User.Id);
                            cmd.Parameters.AddWithValue($"plTwo{i}", t.Games[i].PlayerTwo.User.Id);
                        }

                    }
                }


                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (result != t.Games.Count + 1)
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



        private int GetWinner(Game g)
        {
            if (g.PlayerOneScore > g.PlayerTwoScore)
            {
                return g.PlayerOne.User.Id;
            }
            return g.PlayerTwo.User.Id;
        }

        public void Result(Tournament t, Game game)
        {
            try
            {
                string sql = "UPDATE a_tournament_game SET player_one_score = @1score, player_one_id = @1id,player_two_score = @2score, player_two_id = @2id, winner = @win WHERE tournament_id = @tid AND round_id = @rid AND game_id = @gid;";
                if (t.Status == Status.finished)
                {
                    sql += "UPDATE a_tournament SET status = 'finished' WHERE id = @tid";
                }
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                int first = game.PlayerOneScore;
                int second = game.PlayerTwoScore;

                cmd.Parameters.AddWithValue("1score", first);
                cmd.Parameters.AddWithValue("1id", game.PlayerOne.User.Id);
                cmd.Parameters.AddWithValue("2score", second);
                cmd.Parameters.AddWithValue("2id", game.PlayerTwo.User.Id);
                cmd.Parameters.AddWithValue("win", GetWinner(game));
                cmd.Parameters.AddWithValue("tid", t.Id);
                cmd.Parameters.AddWithValue("rid", game.RoundNr);
                cmd.Parameters.AddWithValue("gid", game.Id);

                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 1 && result != 2)
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


        public void GetRanking()
        {
            Dictionary<int, int> ranking = new Dictionary<int, int>();

            try
            {
                string sql = "SELECT winner, COUNT(*) as count FROM `a_tournament_game` WHERE tournament_id = 1 GROUP BY winner ORDER BY count DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                   // ranking.Add();
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
