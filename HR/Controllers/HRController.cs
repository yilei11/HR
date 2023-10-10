using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class HRController : Controller
    {
        private UsersDAO usersDAO = new UsersDAO();
        // GET: HR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult top()
        {
            return View();
        }

        public ActionResult left()
        {
            return View();
        }

        public ActionResult main()
        {
            return View();
        }


        public ActionResult login()
        {
            return View();
        }

        public async Task<ActionResult> logindl(Users users)
        {
            int a = await usersDAO.SelectAsync(users);
            if (a > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }
    }
}