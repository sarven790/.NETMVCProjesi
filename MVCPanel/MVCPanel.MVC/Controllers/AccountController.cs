using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCPanel.BLL.EntityFramework.DesignPatterns.GenericRepository.ConcreteRepository;
using MVCPanel.BLL.Hashing;
using MVCPanel.Entities.Models;

namespace MVCPanel.MVC.Controllers
{
    public class AccountController : Controller
    {

        UserRepository UserRepository = new UserRepository();
        Hashing Hashing = new Hashing();

        // GET: Account
        [Authorize]
        [HttpGet]
        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {

            try
            {
                String hash = Hashing.CreateMD5(u.PasswordHash);

                u.PasswordHash = hash;

                UserRepository.Add(u);
            }
            catch (Exception) { }
           

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Login(User u)
        {

            try
            {

                String hash = Hashing.CreateMD5(u.PasswordHash);

                bool type = UserRepository.Any(x => x.PasswordHash == hash && x.FirstName == u.FirstName);

                User user = UserRepository.FirstOrDefault(x => x.FirstName == u.FirstName && x.PasswordHash == hash);

                Entities.Enums.UserRole roles = user.Role;

                if (type == true)
                {

                    FormsAuthentication.SetAuthCookie(user.Role.ToString(), false);


                    if (roles == Entities.Enums.UserRole.Admin)
                    {
                        return Redirect("/Home/Index?Yetki=1");
                    }
                    else
                    {

                        return Redirect("/Home/Index?Yetki=2");

                    }

                }
                else
                {

                    return View();

                }

            }
            catch (Exception) 
            {
                return View();
            }

        }

        public ActionResult Logout() 
        {
            try
            {
 
                FormsAuthentication.SignOut();           
                return RedirectToAction("Login", "Account");

            }
            catch (Exception)
            {

                return View();

            }

           
        }

    }
}