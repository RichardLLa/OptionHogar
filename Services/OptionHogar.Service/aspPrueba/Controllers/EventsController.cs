using Infrastructure.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Type = Infrastructure.Entities.Models.Type;

namespace aspPrueba.Controllers
{
    public class EventsController : ApiController
    {
        // GET: api/Events
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Events/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Events
        //public void Postevent([FromBody]Event value)
        //{
        //}

        //public void Postinvestment([FromBody]Investment value)
        //{
        //}

        //public void get([FromBody]Log value)
        //{
        //}

        //public void delete([FromBody]Media value)
        //{
        //}


        //public void Post([FromBody]Param value)
        //{
        //}


        //public void Get([FromBody]Project value)
        //{
        //}
        //public void Post([FromBody]SessionKey value)
        //{
        //}
        public void Get([FromBody]Type value)
        {
        }
        public void Delete([FromBody]User value)
        {
        }




    }
}
