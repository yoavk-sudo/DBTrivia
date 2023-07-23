using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class GetAnswersController : ApiController
    {
        // GET api/GetAnswers
        public string[] Get(int? AnswerID)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            string[] Answers = dbman.GetAnswers(AnswerID);
            return Answers;
        }

        // GET api/values/5
        //public string Get()
        //{
            //DataBaseMananger dbman = new DataBaseMananger();
            //string Name = dbman.GetPlayerName(1);
            //return Name;
        //}

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
