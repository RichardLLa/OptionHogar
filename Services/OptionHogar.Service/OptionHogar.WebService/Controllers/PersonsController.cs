using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Manager;
using Infrastructure.Entities.Models;
using Infrastructure.Entities.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptionHogar.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        PersonManager DAPerson = new PersonManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Person person)
        {
            if (DAPerson.Insert(person, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Person person)
        {
            if (DAPerson.Update(person, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (DAPerson.Delete(id, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            var personList = DAPerson.SelectAll(out error);
            if (personList == null)
            {
                return NotFound(error);
            }
            return Ok(personList);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = DAPerson.SelectById(id, out error);
            if (person == null)
            {
                return NotFound(error);
            }
            return Ok(person);
        }

        [HttpGet("bytypedoc/{tabDOC}/{codDOC}")]
        public ActionResult<List<Person>> GetByIdTypeDOC( string tabDOC, string codDOC)
        {
            var person = DAPerson.SelectByIdTypeDOC( tabDOC,  codDOC,out error);
            if (person == null || person .Count ==0)
            {
                return NotFound(error);
            }
            return Ok(person);
        }
        [HttpGet("bytypegen/{tabGEN}/{codGEN}")]
        public ActionResult<List<Person>> GetByIdTypeGEN(string tabGEN, string codGEN)
        {
            var person = DAPerson.SelectByIdTypeGEN(tabGEN, codGEN, out error);
            if (person == null || person .Count ==0)
                {
                return NotFound(error);
            }
            return Ok(person);
        }

    }

}