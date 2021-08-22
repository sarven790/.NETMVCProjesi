using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPanel.BLL.EntityFramework.DesignPatterns.GenericRepository.ConcreteRepository;
using MVCPanel.BLL.Hashing;
using MVCPanel.Entities.Models;
using MVCPanel.MVC.Models;
using MVCPanel.MVC.Models.Classes;
using MVCPanel.MVC.Models.Enums;

namespace MVCPanel.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home

        UserRepository UserRepository = new UserRepository();
        
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

        public ActionResult GetUserUpdate(int id)
        {

            try
            {

                User data = UserRepository.Find(id);
                return View("GetUserUpdate", data);

            }
            catch (Exception) 
            {
                return View();
            }

           

        }

        [HttpPost]
        public ActionResult UserUpdate(User u)
        {

            try
            {
                String hash = Hashing.CreateMD5(u.PasswordHash);

                u.PasswordHash = hash;

                UserRepository.Update(u);

                return Redirect("/Home/Index");
            }
            catch (Exception)
            {
                return View();
            }

            

        }

        public ActionResult Index()
        {

            try
            {

                List<User> data = UserRepository.GetAll();

                return View(data);

            }
            catch (Exception)
            {

                return View();

            }

          

        }

        public ActionResult DeleteUser(int id)
        {

            try
            {
                User u = UserRepository.Find(id);

                UserRepository.Destroy(u);

                return Redirect("/Home/Index");

            } catch (Exception) 
            {

                return View();

            }

           

        }

    }
}