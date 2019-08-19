using ControlSheet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlSheet.Controllers.PaperBag
{
    public class PaperBagController : Controller
    {

        ResultModel data = new ResultModel();
        Service.ProyectService ProyectService = new Service.ProyectService();
        DataTable dt = null;
        public int idUser = 0;
        public int idCompany = 0;
        // GET: PaperBag
        public ActionResult Principal()
        {
            return View();
        }

        public JsonResult ModifyPerfil(HttpPostedFileBase filePerfil)
        {
            try
            {
                idUser = (int)System.Web.HttpContext.Current.Session["idUser"];
                idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];

                int? idUs = null;
                var idP = (int)System.Web.HttpContext.Current.Session["idUserProfile"];

                if (idP != 1)
                {
                    idUs = idUser;
                }

                dt = ProyectService.GetLoadProyectActive(idCompany, idUs);
                dt.Columns.Add("idProfile", typeof(System.Int32));
                dt.Columns["idProfile"].Expression = idP.ToString();
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
