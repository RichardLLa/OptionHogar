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
    public class ParamsController : ControllerBase
    {

        ParamManager DAParam = new ParamManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Param param)
        {
            if (DAParam.Insert(param, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Param param)
        {
            if (DAParam.Update(param, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (DAParam.Delete(id, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Param>> Get()
        {
            var paramList = DAParam.SelectAll(out error);
            if (paramList == null || paramList.Count == 0)
            {
                return NotFound(error);
            }
            return Ok(paramList);
        }

        [HttpGet("{id}")]
        public ActionResult<Param> Get(int id)
        {
            var param = DAParam.SelectById(id, out error);
            if (param == null)
            {
                return NotFound(error);
            }
            return Ok(param);
        }

    }
}