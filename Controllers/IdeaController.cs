using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using beltexam4.Models;
using beltexam4.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using beltexam4.ViewModels;


namespace beltexam4.Controllers
{
    public class IdeaController : Controller
    {
        private readonly UserFactory userFactory;

        private readonly IdeaFactory ideaFactory;

        public IdeaController(UserFactory user, IdeaFactory idea)
        {
            userFactory = user;
            ideaFactory = idea;
        }

        [HttpPost]
        [Route("postidea")]
        public IActionResult PostIdea(IdeaViewModel ideaModel)
        {
            ideaFactory.AddIdea(ideaModel);
            return RedirectToAction("Dashboard", "User");
        }

        [HttpPost]
        [Route("vote_yes")]
        public IActionResult Like(int user_id, int idea_id)
        {
            var alllikes = ideaFactory.AllLikesForUser(user_id);
            foreach(Likes x in alllikes)
            {
                if(x.ideas_id == idea_id)
                {
                    return RedirectToAction("Dashboard", "User");
                }
            }
            ideaFactory.AddLike(user_id, idea_id);
            return RedirectToAction("Dashboard", "User");
        }

        [HttpPost]
        [Route("vote_no")]
        public IActionResult VoteNo(int user_id, int idea_id)
        {
            var alllikes = ideaFactory.AllLikesForUser(user_id);
            foreach(Likes x in alllikes)
            {
                if(x.ideas_id == idea_id)
                {
                    return RedirectToAction("Dashboard", "User");
                }
            }
            ideaFactory.AddVoteNo(user_id, idea_id);
            return RedirectToAction("Dashboard", "User");
        }

        [HttpGet]
        [Route("users/{id}")]
        public IActionResult UserProfile(int id)
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return Redirect("/");
            }
            User userinstance = userFactory.FindByID(id);
            ViewBag.user = userinstance;
            return View("user");
        }

        [HttpGet]
        [Route("bright_ideas/{id}")]
        public IActionResult LikeStatus(int id)
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return Redirect("/");
            }
            Idea idea = ideaFactory.FindByID(id);
            ViewBag.idea = idea;
            var likes = ideaFactory.AllLikesForIdea(id);
            ViewBag.likes = likes;
            return View("like_status");
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(int user_id, int idea_id)
        {
            ideaFactory.Delete(idea_id, user_id);
            return RedirectToAction("Dashboard", "User");
        }




    }
}