using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MortgageCalculator.Api.Services;
using System;

namespace MortgageCalculator.Api.Controllers
{
    [RoutePrefix("api/MortgageCals")]
    public class MortgageController : ApiController
    {
        private readonly IMortgageService _mortgageService;

        public MortgageController(IMortgageService mortgageService)
        {
            _mortgageService = mortgageService;
        }

        /// <summary>
        /// To get all mortgages to display in Home page.
        /// </summary>
        [HttpGet]
        [Route("AllMortgages")]
        public IHttpActionResult Get()
        {
            try
            {
                var mortgagesLists = _mortgageService.GetAllMortgages();
                if (mortgagesLists != null)
                    return Ok(mortgagesLists);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// To get mortgage by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult GetById(int Id)
        {
            try
            {
                var mortId = _mortgageService.GetMortgageById(Id);

                if (mortId == null)
                {
                    return NotFound();
                }
                return Ok(mortId);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
