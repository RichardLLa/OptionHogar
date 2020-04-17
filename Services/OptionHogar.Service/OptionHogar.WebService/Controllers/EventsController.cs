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
    public class EventsController : ControllerBase
    {

        EventManager DAEvent = new EventManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Event _event)
        {
            if (DAEvent.Insert(_event, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Event _event)
        {
            if (DAEvent.Update(_event, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (DAEvent.Delete(id,out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Event>> Get()
        {
            var _events = DAEvent.SelectAll(out error);
            if (_events == null || _events.Count==0)
            {
                return NotFound(error);
            }
            return Ok(_events);
        }

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            var _event = DAEvent.SelectById(id,out error);
            if (_event == null)
            {
                return NotFound(error);
            }
            return Ok(_event);
        }

        [HttpGet("byprojectid/{project_id}")]
        public ActionResult<List<Event>> GetByProjectId(int project_id)
        {
            var _event = DAEvent.SelectByProjectId(project_id,out error);
            if (_event == null || _event.Count ==0)
            {   
                return NotFound(error);
            }
            return Ok(_event);
        }
        

    }
}