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
    public class ZhaoPController : Controller
    {
        private Major_releaseDAO major_ReleaseDAO = new Major_releaseDAO();
        private Engage_resumeDAO resumeDAO = new Engage_resumeDAO();
        private Public_charDAO public_CharDAO = new Public_charDAO();
        private MajorDAO majorDAO = new MajorDAO();
        private Engage_interviewDAO engage=new Engage_interviewDAO();
        // GET: ZhaoP
        public ActionResult ZYD()
        {
            return View();
        }

        public async Task<ActionResult> ZYDTJf(Major_release major)
        {
            int cg = await major_ReleaseDAO.TianAsync(major);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(major);
            }
        }


        public ActionResult ZYG()
        {
            return View();
        }

        public async Task<ActionResult> ZYGCX(int pageSize, int currentPage)
        {
            Fenye<Major_release> fenye = await major_ReleaseDAO.SelectAsync(pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ZYGSc(int id)
        {
            int cg = await major_ReleaseDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        public async Task<ActionResult> ZYGXiu(int id)
        {
            ViewBag.s = await major_ReleaseDAO.ChaYiAsync(id);
            return View();
        }


        public async Task<ActionResult> ZYGXiuu(Major_release major_Release)
        {
            int cg = await major_ReleaseDAO.Xiu(major_Release);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }


        public ActionResult ZYC()
        {
            return View();
        }

        public async Task<ActionResult> ZYCXiu(int id)
        {
            ViewBag.s = await major_ReleaseDAO.ChaYiAsync(id);
            return View();
        }

        public  ActionResult JLD()
        {
            string engageType = Request.QueryString["engage_type"];
            string majorKindName = Request.QueryString["major_kind_name"];
            string majorName = Request.QueryString["major_name"];

            // 使用参数值进行后续处理

            return View();
        }

        public async Task<ActionResult> JLDCXList(string name)
        {
            IEnumerable<Public_char> ie = await public_CharDAO.SelectListAsync(name);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> JLDTJf(Engage_resume er)
        {
            int cg = await resumeDAO.TianAsync(er);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(er);
            }
        }


        public ActionResult JLC()
        {
            return View();
        }


        public async Task<ActionResult> JLCCXList(string name)
        {
            IEnumerable<Major> ie = await majorDAO.SelectListAsync(name);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JLCCX()
        {
            string fenl = Request.QueryString["fenl"];
            string namemc = Request.QueryString["namemc"];
            string Gjz = Request.QueryString["Gjz"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }

        public async Task<ActionResult> JLCCXf(int pageSize, int currentPage, string Zyf, string Zwm, string Gjc, string Djq, string Djz)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectAsync(pageSize, currentPage,Zyf, Zwm, Gjc, Djq, Djz);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> JLCXiuu(int id)
        {
            int cg = await resumeDAO.Xiu(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }


        public ActionResult JLCX()
        {
            return View();
        }

        public ActionResult JLCflC()
        {
            string fenl = Request.QueryString["fenl"];
            string namemc = Request.QueryString["namemc"];
            string Gjz = Request.QueryString["Gjz"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }

        public async Task<ActionResult> JLCXf(int pageSize, int currentPage, string Zyf, string Zwm, string Gjc, string Djq, string Djz)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectAsync2(pageSize, currentPage, Zyf, Zwm, Gjc, Djq, Djz);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> JLYCXAsync(int id)
        {
            ViewBag.s = await resumeDAO.ChaYiAsync(id);
            return View();
        }


        public ActionResult MSD()
        {
            return View();
        }

        public ActionResult MSDC()
        {
            string fenl = Request.QueryString["fenl"];
            string namemc = Request.QueryString["namemc"];
            string Gjz = Request.QueryString["Gjz"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }

        public async Task<ActionResult> MSDCXf(int pageSize, int currentPage, string Zyf, string Zwm, string Gjc, string Djq, string Djz)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectAsync2(pageSize, currentPage, Zyf, Zwm, Gjc, Djq, Djz);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

       

        public async Task<ActionResult> MSDXAsync(int id,string name)
        {
            var task1 = resumeDAO.ChaYiAsync(id);
            var task2 = engage.ChaYiAsync(name);

            await Task.WhenAll(task1, task2);

            ViewBag.s1 = await task1;
            ViewBag.s2 = await task2;

            return View();
        }

    }
}