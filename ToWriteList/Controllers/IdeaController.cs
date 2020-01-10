using Entities.Db;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Texts;

namespace ToWriteList.Controllers
{
    [EnableCors("MyPolicy")]
    public class IdeaController : Controller
    {
        //private IRepositoryWrapper _repoWrapper;

        //public IdeaController(IRepositoryWrapper repoWrapper)
        //{
        //    _repoWrapper = repoWrapper;
        //}

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


            //Idea ideaToSave = new Idea()
            //{
            //    IdeaBlock = ideaText,
            //    User = _repoWrapper.User.FindByCondition(u => u.Email == HttpContext.User.Identity.Name).FirstOrDefault()
            //};
            //_repoWrapper.Idea.Create(ideaToSave);
            //_repoWrapper.Save();

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


            //Text textToSave = new Text()
            //{
            //    TextBlock = text,
            //    User = _repoWrapper.User.FindByCondition(u => u.Email == HttpContext.User.Identity.Name).FirstOrDefault()
            //};
            //_repoWrapper.Text.Create(textToSave);
            //_repoWrapper.Save();


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

            //Idea randomIdea = _repoWrapper.Idea.TakeRandom();
            //return randomIdea.IdeaBlock;

        }

        [Route("Idea/Save")]
        public IActionResult Save()
        {
            System.Console.WriteLine("ea");
            return Ok();
        }
    }
}
