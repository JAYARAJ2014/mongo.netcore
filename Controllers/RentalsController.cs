using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using RealEstateListing.Data;
using RealEstateListing.Models;
using RealEstateListing.ViewModels;

namespace RealEstateListing.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public readonly RealEstateContext Context;
        public RentalsController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            Context = new RealEstateContext(_config["ConnectionString"], _config["DatabaseName"]);

        }

        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(PostRental postRental)
        {
            var rental = new Rental(postRental);
            Context.Rentals.InsertOne(rental);
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var rentals = Context.Rentals.Find(r => true).ToList<Rental>();
            return View(rentals);
        }
        private Rental GetRentalById(string id)
        {
            return Context.Rentals.Find<Rental>(r => r.Id == id).FirstOrDefault();
        }
        public ActionResult AdjustPrice(string id)
        {
            var rental = GetRentalById(id);
            return View(rental);
        }

        [HttpPost]
        public ActionResult AdjustPrice(string id, AdjustPrice adjustedPrice)
        {
            Rental rental = GetRentalById(id);
            rental.AdjustPrice(adjustedPrice);
            Context.Rentals.ReplaceOne(r=>r.Id==id, rental);
            return RedirectToAction ("Index");
        }



        // public IActionResult Index()
        // {

        //     // var people = Context.Database.GetCollection<Person>("People");
        //     // return people.Find(p => true).ToList();
        //     // var person = new BsonDocument();
        //     // person.Add("firstName", new BsonString("Knappan"));
        //     // person.Add("age", new BsonInt32(42));
        //     // person.Add("isAlive", true);
        //     // person.Add("address", new BsonArray(new[] { "1 Realestate Dr", "Apartment 512" }));
        //     // person.Add(
        //     //     "contact", new BsonDocument
        //     //     {
        //     //         {"phone", "123-456-7896"},
        //     //         {"email" , "someone@somedomain.com"}
        //     //     }
        //     // );


        //     // return Ok(person["age"].AsInt32);

        //     //    return Ok(person.ToJson());

        //     // var  p = new Person();
        //     // p.Name = "Someone";
        //     // p.Age = 34;
        //     // p.Address.Add("1 Technology Dr");
        //     // p.Address.Add("Unit 256");
        //     // p.Contact.Email="someone@somedomain.com";
        //     // p.Contact.Phone = "123-456-7890";
        //     // return Ok(p.ToBsonDocument());
        // }

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
