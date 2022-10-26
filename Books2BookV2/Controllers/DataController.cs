using Books2BookV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml;

namespace Books2BookV2.Controllers
{
    public class DataController : Controller
    {
        private readonly Book2BookContext _context;
     


        public DataController(Book2BookContext context)
        {
            _context = context;
        }

        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult DataPoints(int count = 10, string type = "json")
        {
            var val1 =  _context.TblBooks.Where(x => x.Category == "Coding").Count();
            var val2 =  _context.TblBooks.Where(x => x.Category == "Fiction").Count();

            _dataPoints.Add(val1);
            _dataPoints.Add(val2);

            return Content(JsonConvert.SerializeObject(_dataPoints, _jsonSetting), "application/json");

          

            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

            private static List<int> _dataPoints = new List<int>();

        
    }
}
