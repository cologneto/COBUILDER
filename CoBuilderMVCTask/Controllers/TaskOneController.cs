using CoBuilderMVCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoBuilderMVCTask.Controllers
{
    public class TaskOneController : Controller
    {
        private const int listLength = 10;
        // GET: TaskOne
        public static NumbersRange nr;


        private List<int> CreateListOfRandomNumbers(int minNumber, int maxNumber)
        {
            Random rand = new Random();
            List<int> list = new List<int>();

            for (int i = 0; i < listLength; i++)
            {
                list.Add(rand.Next(minNumber, maxNumber));
            }

            return list;
        }


        //The easiest way to select 
        //private List<int> RemoveNegativeNumbers(List<int> listOfIntegers)
        //{
        //    return listOfIntegers.Where(x => x > 0).ToList();
        //}


        //Most interesting way 
        private List<int> RemoveNegativeNumbers(List<int> listOfIntegers)
        {
            foreach (var item in new List<int>(listOfIntegers))
            {
                if (item < 0)
                {
                    listOfIntegers.Remove(item);
                }
            }

            return listOfIntegers;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(NumbersRange post)
        {
            if (ModelState.IsValid)
            {
                nr = post;

                return RedirectToAction("ListView");

            }
           

            return View(new NumbersRange());
        }

        [HttpGet]
        public ActionResult ListView()
        {
            var result = new ListsOfNumbers();
            var post1 = nr;

            var randomList = CreateListOfRandomNumbers(post1.min, post1.max);
            var currentList = new List<int>(randomList);

            result.randomList = randomList;
            result.positiveNumberList = RemoveNegativeNumbers(currentList);

            return View(result);
        }
    }
}