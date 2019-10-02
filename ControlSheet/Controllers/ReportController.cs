using ControlSheet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlSheet.Controllers
{
    public class ReportController : Controller
    {
        ResultModel data = new ResultModel();
        Service.ReportsService ReportService = new Service.ReportsService();
        DataTable dt = null;
        public int? idUser = 0;
        public int idCompany = 0;
        public int idUserProfile = 0;

        [Authorize]
        // GET: Report
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["idUser"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        [Authorize]
        public ActionResult ReportPrincipal()
        {
            if (System.Web.HttpContext.Current.Session["idUser"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        [Authorize]
        public ActionResult ReportSumHour()
        {
            return View();
        }

        [Authorize]
        public ActionResult ReportGraphicByType()
        {
            return View();
        }

        [Authorize]
        public JsonResult LoadReportPrincipal(DateTime? dateBegin, DateTime? dateEnd, int? Estado)
        {
            try
            {
                idUser = (int)System.Web.HttpContext.Current.Session["idUser"];
                idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];
                idUserProfile = (int)System.Web.HttpContext.Current.Session["idUserProfile"];

                if (idUserProfile == 1)
                {
                    idUser = null;
                }

                dt = ReportService.GetLoadReportPrincipal(dateBegin, dateEnd, Estado, idCompany, idUser);
                data.result = JsonConvert.SerializeObject(dt, Formatting.Indented);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = "error";
                return Json(data, JsonRequestBehavior.AllowGet);

            }

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [Authorize]
        public JsonResult LoadReportSumHour(DateTime? dateBegin, DateTime? dateEnd, int? Estado)
        {
            try
            {
                idUser = (int)System.Web.HttpContext.Current.Session["idUser"];
                idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];
                idUserProfile = (int)System.Web.HttpContext.Current.Session["idUserProfile"];

                if (idUserProfile == 1)
                {
                    idUser = null;
                }

                dt = ReportService.GetLoadReportSumHour(dateBegin, dateEnd, Estado, idCompany, idUser);
                data.result = JsonConvert.SerializeObject(dt, Formatting.Indented);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = "error";
                return Json(data, JsonRequestBehavior.AllowGet);

            }

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [Authorize]
        public JsonResult LoadReportGraphicByType(DateTime? dateBegin, DateTime? dateEnd, int? Estado)
        {
            try
            {
                idUser = (int)System.Web.HttpContext.Current.Session["idUser"];
                idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];
                idUserProfile = (int)System.Web.HttpContext.Current.Session["idUserProfile"];

                if (idUserProfile == 1)
                {
                    idUser = null;
                }

                dt = ReportService.GetLoadReportGraphicType(dateBegin, dateEnd, Estado, idCompany, idUser);
                data.result = JsonConvert.SerializeObject(dt, Formatting.Indented);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = "error";
                return Json(data, JsonRequestBehavior.AllowGet);

            }

            return Json(data, JsonRequestBehavior.AllowGet);

        }

    }
}
