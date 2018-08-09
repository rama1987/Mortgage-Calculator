using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MortgageCalculator.Dto;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MortgageCalculator.Web.Models;
using MortgageCalculator.Web.Singleton;
using MortgageCalculator.Web.BusinessLayer;
using System.Configuration;

namespace MortgageCalculator.Web.Controllers
{
    [HandleError(View = "Error")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Index method.
        /// </summary>        
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Mortgage home page navigation.
        /// </summary>        
        /// <returns>ActionResult</returns>
        public ActionResult MortgageCalsHome()
        {
            return PartialView("_MortgageHome");
        }

        /// <summary>
        /// Mortgage Calculation page navigation.
        /// </summary>        
        /// <returns>ActionResult</returns>
        public ActionResult MortgageCals()
        {
            return PartialView("_MortgageCals");
        }

        /// <summary>
        /// To mortgage calculation changes.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult MortgageCals(MortgageModel model)
        {
            return Json(MortgageBL.CalculateMorgage(model), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// To get all mortgages.
        /// </summary>        
        /// <returns>Task<ActionResult></returns>
        public async Task<ActionResult> AllMortgages()
        {
            List<MortgageModels> MortgageList = new List<MortgageModels>();

            HttpResponseMessage clientRes = await ServiceCall("api/mortgagecals/allMortgages");
            
            if (clientRes.IsSuccessStatusCode)
            {
                var EmpResponse = clientRes.Content.ReadAsStringAsync().Result;

                MortgageList = JsonConvert.DeserializeObject<List<MortgageModels>>(EmpResponse);
                MortgageCalsSingleton.CreateInstance.MortgageList = MortgageList;
            }
            return Json(MortgageList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// To get all mortgage types.
        /// </summary>        
        /// <returns>Task<ActionResult></returns>
        public ActionResult GetMortgagetype()
        {
            SelectList SelectList = null;
            if (MortgageCalsSingleton.CreateInstance.MortgageList != null && MortgageCalsSingleton.CreateInstance.MortgageList.Count > 0)
            {
                SelectList = new SelectList(MortgageCalsSingleton.CreateInstance.MortgageList.ToList(), "InterestRate", "Name");
            }
            return Json(SelectList, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// To make service call
        /// </summary>
        /// <param name="serviceURL"></param>
        /// <returns>Task<HttpResponseMessage></returns>
        public async Task<HttpResponseMessage> ServiceCall(string serviceURL)
        {
            using (var client = new HttpClient())
            {
                string Baseurl = ConfigurationManager.AppSettings["Service_Url"];
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(serviceURL);
                return Res;
            }

        }


    }
}