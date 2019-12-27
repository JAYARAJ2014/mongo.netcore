using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using RealEstateListing.Data;
using RealEstateListing.Models;

namespace RealEstateListing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public RealEstateContext Context;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            Context = new RealEstateContext(_config["ConnectionString"], _config["DatabaseName"]);

        }

        public IActionResult Index()
        {

            // var people = Context.Database.GetCollection<Person>("People");
            // return people.Find(p => true).ToList();
            // var person = new BsonDocument();
            // person.Add("firstName", new BsonString("Knappan"));
            // person.Add("age", new BsonInt32(42));
            // person.Add("isAlive", true);
            // person.Add("address", new BsonArray(new[] { "1 Realestate Dr", "Apartment 512" }));
            // person.Add(
            //     "contact", new BsonDocument
            //     {
            //         {"phone", "123-456-7896"},
            //         {"email" , "someone@somedomain.com"}
            //     }
            // );


            // return Ok(person["age"].AsInt32);

            //    return Ok(person.ToJson());

            // var  p = new Person();
            // p.Name = "Someone";
            // p.Age = 34;
            // p.Address.Add("1 Technology Dr");
            // p.Address.Add("Unit 256");
            // p.Contact.Email="someone@somedomain.com";
            // p.Contact.Phone = "123-456-7890";
            // return Ok(p.ToBsonDocument());
            return Ok("");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
