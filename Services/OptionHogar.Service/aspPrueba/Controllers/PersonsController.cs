using Infrastructure.DataAccess.Manager;
using Infrastructure.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspPrueba.Controllers
{
    public class PersonsController : ApiController
    {

        PersonManager DAPerson = new PersonManager();


        // GET api/values
        public List<Person> Get()
        {
            var persons = DAPerson.SelectAll();

            return persons;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public bool Post([FromBody] Person person)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = DAPerson.Insert(person, out _);
            }
            return result;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
