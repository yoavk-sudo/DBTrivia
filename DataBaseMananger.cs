using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Server
{
    public class DataBaseMananger
    {
        string con_str = "Server=localhost; database=game; UID=root; password=noga0000";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        private void Disconnect()
        {
            con.Close();
        }
        private void Connect()
        {
            con = new MySqlConnection(con_str);
            try
            {
                con.Open();
            }
            catch
            {
                con.Close();
            }
        }

        public string GetPlayerName(int IdPlayers)
        {
            try
            {
                Connect();
                string query = "SELECT Name FROM players WHERE IdPlayers =" + IdPlayers;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader.GetString("Name");
                    Disconnect();
                    return name;
                }
                else
                {
                    Disconnect();
                    return null;
                }
            }
            catch
            {
                Disconnect();
                return null;
            }

        }

        public string GetQuestion(int? QuestionID)
        {
            try
            {
                Connect();
                string query = "SELECT questions FROM questions_table WHERE Id =" + QuestionID;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string Question = reader.GetString("questions");
                    Disconnect();
                    return Question;
                }
                else
                {
                    Disconnect();
                    return null;
                }
            }
            catch
            {
                Disconnect();
                return null;
            }

        }

        public string[] GetAnswers(int? AnswerID)
        {
            try
            {
                Connect();
                string query = "SELECT CorrectAnswer, Answer2, Answer3, Answer4 FROM questions_table WHERE Id = " + AnswerID;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string CorrectAnswer = reader.GetString("CorrectAnswer");
                    string Answer2 = reader.GetString("Answer2");
                    string Answer3 = reader.GetString("Answer3");
                    string Answer4 = reader.GetString("Answer4");
                    Disconnect();
                    return new string[] { CorrectAnswer, Answer2, Answer3, Answer4};
                }
                else
                {
                    Disconnect();
                    return null;
                }
            }
            catch
            {
                Disconnect();
                return null;
            }

        }

        internal string SetPlayer(string name1)
        {
            string result;
            try
            {
                Connect();
                string query1 = "UPDATE players SET name = '" + name1 + "' WHERE IdPlayers = 1";
                //string query2 = "UPDATE players SET name = '" + name2 + "' WHERE IdPlayers = 2";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query1;
                cmd.Parameters.AddWithValue("@name1", name1);
                cmd.ExecuteNonQuery();

                //cmd.CommandText = query2;
                //cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@name2", name2);
                //cmd.ExecuteNonQuery();

                result = "Success";
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Disconnect();
                return result;
            }
            return result;
        }

        internal string SetPlayer1(string name2)
        {
            string result;
            try
            {
                Connect();
                string query2 = "UPDATE players SET name = '" + name2 + "' WHERE IdPlayers = 2";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query2;
                cmd.Parameters.AddWithValue("@name2", name2);
                cmd.ExecuteNonQuery();

                //cmd.CommandText = query2;
                //cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@name2", name2);
                //cmd.ExecuteNonQuery();

                result = "Success";
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Disconnect();
                return result;
            }
            return result;
        }

        public int UpdateScore(int newScore, int playerId)
        {
            try
            {
                Connect();
                string query = "UPDATE players SET score = @newScore WHERE IdPlayers = @playerId";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@newScore", newScore);
                cmd.Parameters.AddWithValue("@playerId", playerId);
                int rowsAffected = cmd.ExecuteNonQuery();

                Disconnect();

                if (rowsAffected > 0)
                {
                    // Update successful, no need to read data, just return the new score.
                    return newScore;
                }
                else
                {
                    // No rows were updated, player with specified IdPlayers not found.
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        public int UpdatePlayer1State(int PlayerState)
        {
            try
            {
                Connect();
                string query = "UPDATE players SET Login = @PlayerState WHERE IdPlayers =1";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PlayerState", PlayerState);
                int rowsAffected = cmd.ExecuteNonQuery();

                Disconnect();

                if (rowsAffected > 0)
                {
                    // Update successful, no need to read data, just return the new score.
                    return PlayerState;
                }
                else
                {
                    // No rows were updated, player with specified IdPlayers not found.
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        public int UpdatePlayer2State(int PlayerState2)
        {
            try
            {
                Connect();
                string query = "UPDATE players SET Login = @PlayerState WHERE IdPlayers =2";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PlayerState", PlayerState2);
                int rowsAffected = cmd.ExecuteNonQuery();

                Disconnect();

                if (rowsAffected > 0)
                {
                    // Update successful, no need to read data, just return the new score.
                    return PlayerState2;
                }
                else
                {
                    // No rows were updated, player with specified IdPlayers not found.
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        public int CheckPlayerState(int IdPlayer)
        {
            try
            {
                Connect();
                string query = "SELECT Login FROM game.players where IdPlayers =" + IdPlayer;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int Login = reader.GetInt32("Login");
                    Disconnect();
                    return Login;
                }
                else
                {
                    Disconnect();
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }


        public int GetScorePlayer1(int PlayerId)
        {
            try
            {
                Connect();
                string query = "SELECT score FROM players WHERE IdPlayers =" + PlayerId;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int Score = reader.GetInt32("score");
                    Disconnect();
                    return Score;
                }
                else
                {
                    Disconnect();
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }

        }

        public int GetScorePlayer2(int PlayerId)
        {
            try
            {
                Connect();
                string query = "SELECT score FROM players WHERE IdPlayers =" + PlayerId;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int Score = reader.GetInt32("score");
                    Disconnect();
                    return Score;
                }
                else
                {
                    Disconnect();
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }

        }

        public int UpdatePlayerTime(int PlayerId, int Time)
        {
            try
            {
                Connect();
                string query = "UPDATE players SET Time = @Time WHERE IdPlayers =" + PlayerId;
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Time", Time);
                int rowsAffected = cmd.ExecuteNonQuery();

                Disconnect();

                if (rowsAffected > 0)
                {
                    // Update successful, no need to read data, just return the new score.
                    return 0;
                }
                else
                {
                    // No rows were updated, player with specified IdPlayers not found.
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        public int GetPlayerTime(int PlayerId)
        {
            try
            {
                Connect();
                string query = "Select Time from players WHERE IdPlayers =" + PlayerId;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int Time = reader.GetInt32("Time");
                    Disconnect();
                    return Time;
                }
                else
                {
                    Disconnect();
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        public int UpdatePlayerFinished(int PlayerState)
        {
            try
            {
                Connect();
                string query = "UPDATE players SET Finished = 1 WHERE IdPlayers ="  + PlayerState;
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PlayerState", PlayerState);
                int rowsAffected = cmd.ExecuteNonQuery();

                Disconnect();

                if (rowsAffected > 0)
                {
                    // Update successful, no need to read data, just return the new score.
                    return PlayerState;
                }
                else
                {
                    // No rows were updated, player with specified IdPlayers not found.
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        public int CheckPlayerFinished(int IdPlayer)
        {
            try
            {
                Connect();
                string query = "Select Finished from players WHERE IdPlayers =" + IdPlayer;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int Login = reader.GetInt32("Finished");
                    Disconnect();
                    return Login;
                }
                else
                {
                    Disconnect();
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        //public int UpdateScore(int Score, int IdPlayers)
        //{
        //    try
        //    {
        //        Connect();
        //        Score = 1;
        //        string query = "UPDATE players SET score '" + Score +"' = WHERE IdPlayers =" + IdPlayers;
        //        cmd = new MySqlCommand(query, con);
        //        reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            int score = reader.GetInt32(query);
        //            Disconnect();
        //            return score;
        //        }
        //        else
        //        {
        //            Disconnect();
        //            return 0;
        //        }
        //    }
        //    catch
        //    {
        //        Disconnect();
        //        return 0;
        //    }

        //}

        //public void SetPlayerName(string Name)
        //{
        //    try
        //    {
        //        Connect();
        //        int IdPlayer = 1;
        //        string query = "update players set name = " + Name + "WHERE IdPlayers = " + IdPlayer;
        //        cmd = new MySqlCommand(query, con);
        //        reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            Disconnect();
        //        }
        //        else
        //        {
        //            Disconnect();
        //        }
        //    }
        //    catch
        //    {
        //        Disconnect();
        //    }

        //}
    }
}