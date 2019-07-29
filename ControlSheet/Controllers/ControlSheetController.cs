using ControlSheet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControlSheet.Controllers
{
    public class ControlSheetController : Controller
    {
        
        ResultModel data = new ResultModel();
        Service.ProyectService ProyectService = new Service.ProyectService();
        DataTable dt = null;
        public int  idUser = (int)System.Web.HttpContext.Current.Session["idUser"];
        public int idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];

        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Proyect()
        {
            
            return View();
        }

        public ActionResult ProyectAdmin()
        {
            return View();
        }

        public ActionResult Report()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Home");
        }

        public JsonResult LoadProyectActive()
        {
            try
            {
                int? idUs = null;
                var idP = (int)System.Web.HttpContext.Current.Session["idUserProfile"];

                if (idP != 1)
                {
                    idUs = idUser;
                }

                dt =  ProyectService.GetLoadProyectActive(idCompany, idUs);
                dt.Columns.Add("idProfile", typeof(System.Int32));
                dt.Columns["idProfile"].Expression = idP.ToString();
                data.result = JsonConvert.SerializeObject(dt, Formatting.Indented);
            }
            catch(Exception ex)
            {
                data.message = ex.Message;
                data.status = "error";
                return Json(data, JsonRequestBehavior.AllowGet);

            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateNewProyect(string proyectName)
        {
            try
            {

                dt = ProyectService.CreateNewProyect(proyectName, idUser, idCompany);
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

        public JsonResult LoadProyectDetail(int id)
        {
            try
            {
                dt = ProyectService.LoadProyectDetail(id);
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

        public JsonResult InsertProyectDetail(string moduleName, string proyectDescription, string hourEstimated, DateTime dateEstimatedEnd, int idProyect)
        {
            try
            {
                int idUser = Convert.ToInt32(System.Web.HttpContext.Current.Session["idUser"]);
                dt = ProyectService.InsertProyectDetail(moduleName, proyectDescription, hourEstimated,dateEstimatedEnd, idProyect, idUser);
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

        public JsonResult LoadEditProyectDetail(int idProyect, int idProyectDetail)
        {
            try
            {
               
                dt = ProyectService.LoadEditProyectDetail(idProyect, idProyectDetail);
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
        public JsonResult EditProyectDetail(int idProyect, int idProyectDetail, string moduleName, string descriptions, DateTime? dateEstimated , float? hourEstimated, float? hourDedicated)
        {
            try
            {
                dt = ProyectService.EditProyectDetail(idProyect, idProyectDetail, moduleName, descriptions, dateEstimated, hourEstimated, hourDedicated);
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

        public JsonResult DeleteProyect (int idProyect)
        {
            try
            {
                dt = ProyectService.DeleteProyect(idProyect);
                data.result = JsonConvert.SerializeObject(dt.Rows[0]["result"], Formatting.Indented);
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