﻿using CoffeePicker.Shared;
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

        //private List<Coffee> Coffees = new()
        //{
        //    new() { Id = 1, Title = "Black", Description = "Black coffee is as simple as it gets with ground coffee beans steeped in hot water, served warm. And if you want to sound fancy, you can call black coffee by its proper name: cafe noir." },
        //    new() { Id = 2, Title = "Latte", Description = "As the most popular coffee drink out there, the latte is comprised of a shot of espresso and steamed milk with just a touch of foam. It can be ordered plain or with a flavor shot of anything from vanilla to pumpkin spice." },
        //    new() { Id = 3, Title = "Cappuccino", Description = "Cappuccino is a latte made with more foam than steamed milk, often with a sprinkle of cocoa powder or cinnamon on top. Sometimes you can find variations that use cream instead of milk or ones that throw in flavor shot, as well." },
        //    new() { Id = 4, Title = "Americano", Description = "With a similar flavor to black coffee, the americano consists of an espresso shot diluted in hot water." },
        //    new() { Id = 5, Title = "Espresso", Description = "An espresso shot can be served solo or used as the foundation of most coffee drinks, like lattes and macchiatos." },
        //    new() { Id = 6, Title = "Doppio", Description = "A double shot of espresso, the doppio is perfect for putting extra pep in your step." },
        //    new() { Id = 7, Title = "Cortado", Description = "Like yin and yang, a cortado is the perfect balance of espresso and warm steamed milk. The milk is used to cut back on the espresso’s acidity." },
        //    new() { Id = 8, Title = "Red Eye", Description = "Named after those pesky midnight flights, a red eye can cure any tiresome morning. A full cup of hot coffee with an espresso shot mixed in, this will definitely get your heart racing." },
        //    new() { Id = 9, Title = "Galão", Description = "Originating in Portugal, this hot coffee drink is closely related to the latte and cappuccino. Only difference is it contains about twice as much foamed milk, making it a lighter drink compared to the other two." },
        //    new() { Id = 10, Title = "Lungo", Description = "A lungo is a long-pull espresso. The longer the pull, the more caffeine there is and the more ounces you can enjoy." }
        //};

        // Create
        //

        // Read
        //[HttpGet("{id}")]
        //public ActionResult Get(int id)
        //{
        //    var coffee = Coffees.Find(o => o.Id == id);

        //    if (coffee is not null)
        //    {
        //        return Ok(coffee);
        //    }

        //    return NotFound("Coffeee not found");
        //}

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
            return  applicationDbContext.Coffee.ToList();
        }

        


        //    // Update
        //    [HttpPut]
        //    public ActionResult Update(Coffee newCoffee)
        //    {
        //        var oldcoffee = Coffees.FirstOrDefault(o => o.Id == newCoffee.Id);
        //        if (oldcoffee is not null) //if we have found a coffee that's matching (Coffee newCoffee) then go ahead and do the update, if we didn't find a coffee then return a notfound
        //        {                   //updated by properties 
        //            oldcoffee.Title = newCoffee.Title;
        //            oldcoffee.Description = newCoffee.Description;
        //            return Ok(newCoffee);
        //        }
        //        return NotFound("Coffee not found.");

        //    }

        //    // Delete
        //    [HttpDelete("{id}")]
        //    //if we have more del methods: [HttpDelete("delete/{id}")] or [HttpDetele]   [Route("{id}")]


        //    public ActionResult Delete(int id)
        //    {
        //        var coffee = Coffees.FirstOrDefault(o => o.Id == id);
        //        if (coffee is not null)
        //        {
        //            Coffees.Remove(coffee);
        //            return Ok();
        //        }
        //        return NotFound("Coffee not found."); 

        //}


    }
}