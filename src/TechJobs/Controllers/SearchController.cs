using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 

        public IActionResult Results(string searchType, string searchTerm)
        {

                 if (searchType == "all")
            {
                List<Dictionary<string, string>> word = JobData.FindByValue(searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = word;
                return View("Index");
            }
            else if (searchType != "all")
            {
                List<Dictionary<string, string>> word = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = word;
                return View("Index");
            }
            else
            {
                string Notfound = "Search Term Error. Give proper term";
                ViewBag.jobs = Notfound;
                return View("Index");
            }


        }


    }
}
