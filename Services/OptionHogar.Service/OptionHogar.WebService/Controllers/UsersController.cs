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
    public class UsersController : ControllerBase
    {
        UserManager DAUser = new UserManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] User user)
        {
            if (DAUser.Insert(user, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] User user)
        {
            if (DAUser.Update(user, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{USER_ID}")]
        public ActionResult<bool> Delete(int USER_ID)
        {
            if (DAUser.Delete(USER_ID, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var userList = DAUser.SelectAll(out error);
            if (userList == null)
            {
                return NotFound(error);
            }
            return Ok(userList);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = DAUser.SelectById(id, out error);
            if (user == null)
            {
                return NotFound(error);
            }
            return Ok(user);
        }

        [HttpGet("bypersonid/{PERS_ID}")]
        public ActionResult<User> GetByIdPerson(int PERS_ID)
        {
            var user = DAUser.SelectByIdPerson(PERS_ID, out error);
            if (user == null)
            {
                return NotFound(error);
            }
            return Ok(user);
        }

    }
}