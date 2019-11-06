using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrete;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        IUserRepository userRepository;

        public AccountController(IAuthProvider auth, IUserRepository userRepository)
        {
            authProvider = auth;
            this.userRepository = userRepository;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                //if (authProvider.Authenticate(model.UserName, model.Password))
                //{
                //    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                //}
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (authProvider.ValidateUser(model.UserName, model.Password))
                {
                    Session["UserIsValidated"] = true;
                    Session["Username"] = model.UserName;
                    return RedirectToAction("List", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["UserIsValidated"] = null;
            return RedirectToAction("List", "Product");
        }
        public ActionResult Registration()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.SaveUser(user);
                return RedirectToAction("List","Product");
            }
            else
            {
                return View(user);
            }
        }
    }
}