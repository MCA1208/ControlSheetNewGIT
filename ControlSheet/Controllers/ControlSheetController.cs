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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Proyect()
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
                dt =  ProyectService.GetLoadProyectActive();
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
                var userId = (int)System.Web.HttpContext.Current.Session["idUser"];

                dt = ProyectService.CreateNewProyect(proyectName, userId);
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
        public JsonResult EditProyectDetail(int idProyect, int idProyectDetail, string moduleName, string descriptions, float hourDedicated)
        {
            try
            {
                dt = ProyectService.EditProyectDetail(idProyect, idProyectDetail, moduleName, descriptions, hourDedicated);
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