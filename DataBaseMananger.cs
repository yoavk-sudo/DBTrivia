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
                QuestionID = 1;
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
                AnswerID = 1;
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
                    return new string[] { CorrectAnswer, Answer2, Answer3, Answer4 };
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

        internal string SetPlayer(string name1, string name2)
        {
            string result;
            try
            {
                Connect();
                string query1 = "UPDATE players SET name = '" + name1 + "' WHERE IdPlayers = 1";
                string query2 = "UPDATE players SET name = '" + name2 + "' WHERE IdPlayers = 2";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query1;
                cmd.Parameters.AddWithValue("@name1", name1);
                cmd.ExecuteNonQuery();

                cmd.CommandText = query2;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name2", name2);
                cmd.ExecuteNonQuery();

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