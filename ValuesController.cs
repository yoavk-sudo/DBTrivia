using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using System.Xml.Linq;

namespace Server.Controllers
{
    public class ValuesController : ApiController
    {
        //GET api/values
        public string Get(string name1)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            string result = dbman.SetPlayer(name1);
            return result;
        }

        public string Get1(string name2)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            string result = dbman.SetPlayer1(name2);
            return result;
        }

        //GET api/values/5
        public int Get(int Score, int IdPlayers)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.UpdateScore(Score, IdPlayers);
            return result;
        }

        //GET api/values/6
        public int Get(int PlayerState)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.UpdatePlayer1State(PlayerState);
            return result;
        }

        public int Get3(int PlayerState1)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.UpdatePlayer1State(PlayerState1);
            return result;
        }

        public int Get4(int PlayerState2)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.UpdatePlayer2State(PlayerState2);
            return result;
        }

        public int Get(int? IdPlayers)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.CheckPlayerState((int)IdPlayers);
            return result;
        }

        public int Get1(int A)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.GetScorePlayer1(A);
            return result;
        }

        public int Get2(int B)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.GetScorePlayer2(B);
            return result;
        }

        public int GetTime(int Id, int T)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.UpdatePlayerTime(Id, T);
            return result;
        }

        public int GetTimeNumber(int Id)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.GetPlayerTime(Id);
            return result;
        }

        public int GetFinish1(int Update_NumberId)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.UpdatePlayerFinished(Update_NumberId);
            return result;
        }

        public int GetFinish2(int Set_NumberId)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.CheckPlayerFinished(Set_NumberId);
            return result;
        }


        //GET api/values/5
        //public string Get()
        //{
        //    DataBaseMananger dbman = new DataBaseMananger();
        //    string Name = dbman.GetPlayerName(1);
        //    return Name;
        //}

        public void Set(int IdPlayer, string Name)
        {
            //DataBaseMananger dbman = new DataBaseMananger();
            //dbman.SetPlayerName(IdPlayer, Name);
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
