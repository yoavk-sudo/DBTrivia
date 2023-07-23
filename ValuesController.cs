using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace Server.Controllers
{
    public class ValuesController : ApiController
    {
        //GET api/values
        public string Get(string name1, string name2)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            string result = dbman.SetPlayer(name1, name2);
            return result;
        }

        //GET api/values/5
        public int Get(int Score, int IdPlayers)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            int result = dbman.UpdateScore(Score, IdPlayers);
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
