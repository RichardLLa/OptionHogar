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
    public class InvestmentController : ControllerBase
    {

        InvestmentManager DAInvestment = new InvestmentManager();
        LogError error = null;

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Investment investment)
        {
            if (DAInvestment.Insert(investment, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] Investment investment)
        {
            if (DAInvestment.Update(investment, out error))
            {
                return new CreatedAtRouteResult(null, null, true);
            }
            return BadRequest(error);


        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (DAInvestment.Delete(id, out error))
            {
                return new OkObjectResult(true);
            }
            return NotFound(error);
        }

        [HttpGet]
        public ActionResult<List<Investment>> Get()
        {
            var investments = DAInvestment.SelectAll(out error);
            if (investments == null || investments.Count == 0)
            {
                return NotFound(error);
            }
            return Ok(investments);
        }

        [HttpGet("{id}")]
        public ActionResult<Investment> Get(int id)
        {
            var investment = DAInvestment.SelectById(id, out error);
            if (investment == null)
            {
                return NotFound(error);
            }
            return Ok(investment);
        }

        [HttpGet("byuserid/{user_id}")]
        public ActionResult<List<Investment>> GetByUserId(int user_id)
        {
            var investment = DAInvestment.SelectByUserId(user_id, out error);
            if (investment == null || investment.Count == 0)
            {
                return NotFound(error);
            }
            return Ok(investment);
        }

    }
}