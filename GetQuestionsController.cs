using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class GetQuestionsController : ApiController
    {
        // GET api/GetQuestion
        public string Get(int? QuestionID)
        {
            DataBaseMananger dbman = new DataBaseMananger();
            string Question = dbman.GetQuestion(QuestionID);
            return Question;
        }

        //GET api/values/5
        //public string Get(string name)
        //{
        //    //DataBaseMananger dbman = new DataBaseMananger();
        //    //string Name = dbman.GetPlayerName(1);
        //    //return Name;
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
