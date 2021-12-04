using CoffeePicker.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePicker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CoffeeController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        // Read
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var coffee = applicationDbContext.Coffee.FirstOrDefault(x => x.Id == id);
            
            if (coffee is not null)
            {
                return Ok(coffee);
            }
            return NotFound("Coffeee not found");
        }

        //Create
        //backend logic
        [HttpPost]
        public ActionResult Create(Coffee coffee)
        {
            applicationDbContext.Coffee.Add(coffee);
            applicationDbContext.SaveChanges();

            //coffee.Id = Coffees.Count + 1; //Coffees.Count: get count of all coffees 
            //Coffees.Add(coffee); //add coffee to the list

            //var newCoffee = Coffees.Find(o => o.Id == coffee.Id); //find me a coffee with id that's matching above
            return Ok();
        }

        // Read
        //[HttpGet("List")]
        //public ActionResult List()
        //{
        //    return Ok(Coffees);
        //}


        [HttpGet]
        public IEnumerable<Coffee> Get()
        {
            return  applicationDbContext.Coffee.ToArray();
        }




        // Update
        [HttpPut]
        public ActionResult Update(Coffee newCoffee)
        {
            var oldcoffee = applicationDbContext.Coffee.FirstOrDefault(o => o.Id == newCoffee.Id);
            //if we have found a coffee that's matching (Coffee newCoffee)
            //then go ahead and do the update, if we didn't find a coffee
            //then return a notfound
            if (oldcoffee is not null) 
            {                   
                //updated by properties 
                oldcoffee.Title = newCoffee.Title;
                oldcoffee.Description = newCoffee.Description;
                return Ok(newCoffee);
            }
            return NotFound("Coffee not found.");

        }

        // Delete
        [HttpDelete("{id}")]
        //if we have more del methods: [HttpDelete("delete/{id}")] or [HttpDetele]
        public ActionResult Delete(int id)
        {
            var coffee = applicationDbContext.Coffee.FirstOrDefault(o => o.Id == id);
            if (coffee is not null)
            {
                applicationDbContext.Coffee.Remove(coffee);
                return Ok();
            }
            return NotFound("Coffee not found.");
        }


    }
}