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
    public class UserController : Controller
    {
        private readonly UserFactory userFactory;

        private readonly IdeaFactory ideaFactory;

        public UserController(UserFactory user, IdeaFactory idea)
        {
            userFactory = user;
            ideaFactory = idea;
        }

        [HttpGet]
        [Route("main")]
        public IActionResult Index()
        {
            return View("login");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Register()
        {
            return View("register");
        }

        [HttpGet]
        [Route("bright_ideas")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return Redirect("main");
            }
            int id = (int)HttpContext.Session.GetInt32("id");
            User userinstance = userFactory.FindByID(id);
            ViewBag.user = userinstance;
            var ideas = ideaFactory.FindAll();
            ViewBag.ideas = ideas;
            return View("dashboard");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public IActionResult Register(RegisterViewModel regModel)
        {
            if(ModelState.IsValid)
            {
                User newUser = userFactory.Add(regModel);
                if(newUser == null){
                    ViewBag.register_error = "Email address already in use.";
                    return View("register");
                }                
                HttpContext.Session.SetInt32("id", newUser.id);
                return Redirect("bright_ideas");
            }
            return View("register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if(ModelState.IsValid)
            {
            User userinstance = userFactory.FindByEmail(loginModel.email);

            if (userinstance != null && loginModel.password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if (0 != Hasher.VerifyHashedPassword(userinstance, userinstance.password, loginModel.password))
                {
                    int id = userinstance.id;
                    HttpContext.Session.SetInt32("id", id);
                    return Redirect("bright_ideas");
                }
            }
            }
            ViewBag.login_error = "Invalid Login Credentials";
            ModelState.Clear();
            return View("login");
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("main");
        }

    }
}

