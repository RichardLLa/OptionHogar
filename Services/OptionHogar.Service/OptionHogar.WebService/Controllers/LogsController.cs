using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Manager;
using Infrastructure.Entities.Models;
using Infrastructure.Entities.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptionHogar.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        LogManager DALog = new LogManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Log log)
        {
            if (DALog.Insert(log, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Log log)
        {
            if (DALog.Update(log, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (DALog.Delete(id, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Log>> Get()
        {
            var logs = DALog.SelectAll(out error);
            if (logs == null || logs.Count ==0)
            {
                return NotFound(error);
            }
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public ActionResult<Log> Get(int id)
        {
            var log = DALog.SelectById(id, out error);
            if (log == null)
            {
                return NotFound(error);
            }
            return Ok(log);
        }

    }
}