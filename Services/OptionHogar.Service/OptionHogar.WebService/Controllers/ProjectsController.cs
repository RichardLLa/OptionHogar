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
    public class ProjectsController : ControllerBase
    {

        ProjectManager DAProject = new ProjectManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Project project)
        {
            if (DAProject.Insert(project, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Project project)
        {
            if (DAProject.Update(project, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (DAProject.Delete(id, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Project>> Get()
        {
            var projectList = DAProject.SelectAll(out error);
            if (projectList == null || projectList.Count ==0)
            {
                return NotFound(error);
            }
            return Ok(projectList);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var project = DAProject.SelectById(id, out error);
            if (project == null   )
            {
                return NotFound(error);
            }
            return Ok(project);
        }

        [HttpGet("byidinvestment/{INVE_ID}")]
        public ActionResult<List<Project>> GetByIdInvestment(int INVE_ID)
        {
            var projectList = DAProject.SelectByIdInvestment(INVE_ID, out error);
            if (projectList == null || projectList.Count == 0)
            {
                return NotFound(error);
            }
            return Ok(projectList);
        }
       

    }
}