using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        static private List<Dictionary<string, string>> Jobs = new List<Dictionary<string, string>>();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.jobs = Jobs;
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {

            if (searchType == "all")
            {
                if (searchTerm == null)
                {
                    Jobs = JobData.FindAll();
                }
                else
                {
                    Jobs = JobData.FindByValue(searchTerm);
                }
            }
            else
            {
                Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            return Redirect("/Search/Index");
        }

    }
}
