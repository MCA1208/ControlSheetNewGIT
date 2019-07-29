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
        public int? idUser = (int)System.Web.HttpContext.Current.Session["idUser"];
        public int idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];
        public int idUserProfile = (int)System.Web.HttpContext.Current.Session["idUserProfile"];
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportPrincipal()
        {
            return View();
        }
        public ActionResult ReportSumHour()
        {
            return View();
        }

        public JsonResult LoadReportPrincipal(DateTime? dateBegin, DateTime? dateEnd, int? Estado)
        {
            try
            {
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

        public JsonResult LoadReportSumHour(DateTime? dateBegin, DateTime? dateEnd, int? Estado)
        {
            try
            {
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


    }
}
