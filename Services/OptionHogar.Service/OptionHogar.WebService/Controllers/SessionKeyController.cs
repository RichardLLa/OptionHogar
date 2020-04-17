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
    public class SessionKeyController : ControllerBase
    {

        SessionKeyManager DASessionKey = new SessionKeyManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] SessionKey sessionKey)
        {
            if (DASessionKey.Insert(sessionKey, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] SessionKey sessionKey)
        {
            if (DASessionKey.Update(sessionKey, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{id}/{date}")]
        public ActionResult<bool> Delete(int id,DateTime date)
        {
            if (DASessionKey.Delete(id, date,out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<SessionKey>> Get()
        {
            var sessionKeyList = DASessionKey.SelectAll(out error);
            if (sessionKeyList == null)
            {
                return NotFound(error);
            }
            return Ok(sessionKeyList);
        }

        [HttpGet("{id}/{date}")]
        public ActionResult<SessionKey> Get(int id,DateTime date)
        {
            var sessionKey = DASessionKey.SelectById(id,date, out error);
            if (sessionKey == null)
            {
                return NotFound(error);
            }
            return Ok(sessionKey);
        }

    }
}