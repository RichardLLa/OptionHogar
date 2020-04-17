using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Manager;
using Infrastructure.Entities.Models;
using Infrastructure.Entities.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Type = Infrastructure.Entities.Models.Type;

namespace OptionHogar.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {

        TypeManager DAType = new TypeManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Type type)
        {
            if (DAType.Insert(type, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Type type)
        {
            if (DAType.Update(type, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{codTable}/{codType}")]
        public ActionResult<bool> Delete(string codTable, string codType)
        {
            if (DAType.Delete(codTable, codType, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Type>> Get()
        {
            var typeList = DAType.SelectAll(out error);
            if (typeList == null)
            {
                return NotFound(error);
            }
            return Ok(typeList);
        }

        [HttpGet("{codTable}/{codType}")]
        public ActionResult<Type> Get(string codTable, string codType)
        {
            var type = DAType.SelectById(codTable, codType, out error);
            if (type == null)
            {
                return NotFound(error);
            }
            return Ok(type);
        }
    }
}