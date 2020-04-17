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
    public class MediaController : ControllerBase
    {

        MediaManager DAMedia = new MediaManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Media media)
        {
            if (DAMedia .Insert(media, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Media media)
        {
            if (DAMedia .Update(media, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (DAMedia.Delete(id, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Media>> Get()
        {
            var medias = DAMedia.SelectAll(out error);
            if (medias == null)
            {
                return NotFound(error);
            }
            return Ok(medias);
        }

        [HttpGet("{id}")]
        public ActionResult<Media> Get(int id)
        {
            var media = DAMedia.SelectById(id, out error);
            if (media == null)
            {
                return NotFound(error);
            }
            return Ok(media);
        }

        [HttpGet("byeventid/{idEvent}")]
        public ActionResult<List<Media>> GetByIdEvent(int idEvent)
        {
            var media = DAMedia.SelectByIdEvent(idEvent, out error);
            if (media == null || media.Count ==0)
            {
                return NotFound(error);
            }
            return Ok(media);
        }

        [HttpGet("byprojectid/{idProject}")]
        public ActionResult<List<Media>> GetByIdProject(int idProject)
        {
            var media = DAMedia.SelectByIdProject(idProject, out error);
            if (media == null || media.Count ==0)
                {
                return NotFound(error);
            }
            return Ok(media);
        }

        [HttpGet("byidtypemed/{tabMED}/{codMED}")]
        public ActionResult<List<Media>> GetByIdTypeMED(string tabMED, string codMED)
        {
            var media = DAMedia.SelectByIdTypeMED(tabMED, codMED, out  error);
            if (media == null || media.Count ==0)
                {
                return NotFound(error);
            }
            return Ok(media);
        }
    }
}