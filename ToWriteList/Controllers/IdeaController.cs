using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToWriteList.Context;

namespace ToWriteList.Controllers
{
    [EnableCors("MyPolicy")]
    public class IdeaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Idea/SaveIdea")]
        public IActionResult SaveIdea([FromQuery] string ideaText)
        {
            using (ToWriteDbContext dbContext = new ToWriteDbContext())
            {
                Idea ideaToSave = new Idea()
                {
                    IdeaBlock = ideaText,
                    User = dbContext.Users.First(u => u.Email == HttpContext.User.Identity.Name)
                };
                dbContext.Add(ideaToSave);
                dbContext.SaveChanges();
            }
                return Ok();
        }

        [Route("Idea/SaveText")]
        public IActionResult SaveText([FromQuery] string text)
        {
            using (ToWriteDbContext dbContext = new ToWriteDbContext())
            {
                Text textToSave = new Text()
                {
                    TextBlock = text,
                    User = dbContext.Users.First(u => u.Email == HttpContext.User.Identity.Name)
                };
                dbContext.Add(textToSave);
                dbContext.SaveChanges();
            }
            return Ok();
        }

        [Route("Idea/GetRandomIdea")]
        public string GetRandomIdea()
        {
            using (ToWriteDbContext dbContext = new ToWriteDbContext())
            {
                Random random = new Random();
                var randomIdea = dbContext.Ideas.Skip(random.Next(0, dbContext.Ideas.Count())).Take(1);
                return randomIdea.First().IdeaBlock;
            }          
        }

        [Route("Idea/Save")]
        public IActionResult Save()
        {
            System.Console.WriteLine("ea");
            return Ok();
        }
    }
}
