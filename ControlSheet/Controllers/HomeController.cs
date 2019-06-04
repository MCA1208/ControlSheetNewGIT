using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlSheet.Models;
using ControlSheet.Service;
using System.Data;

namespace ControlSheet.Controllers
{
    public class HomeController : Controller
    {
        ResultModel data = new ResultModel();

        UserService Userservice = new UserService();
        SendMailService MailService = new SendMailService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ControlSheet()
        {
            return View();
        }

        public JsonResult LoginUser(string user, string pass)
        {

            try
            {

                DataTable dt =  Userservice.spGetUse(user, pass);

                if(dt.Rows.Count == 0)
                {
                    data.message = "las Credenciales ingresadas no son validas";
                    data.status = "error";
                    return Json(data, JsonRequestBehavior.AllowGet);

                }
                var em = dt.Rows[0]["email"];
                System.Web.HttpContext.Current.Session["email"] = dt.Rows[0]["email"];
                System.Web.HttpContext.Current.Session["idcompany"] = dt.Rows[0]["idcompany"]; 
                System.Web.HttpContext.Current.Session["idUserProfile"] = dt.Rows[0]["idUserProfile"];
                System.Web.HttpContext.Current.Session["active"] = dt.Rows[0]["active"];

                var active = Convert.ToInt32(System.Web.HttpContext.Current.Session["active"]);
                var email = System.Web.HttpContext.Current.Session["email"];
                if (active == 0)
                {
                    data.message = "El usuario se encuentra inactivo";
                    data.status = "error";
                    return Json(data, JsonRequestBehavior.AllowGet);

                }

                int idProfile = (int)System.Web.HttpContext.Current.Session["idUserProfile"];

                DataTable dtPermission = Userservice.spGetPermissionByProfile(idProfile);

                System.Web.HttpContext.Current.Session["permission"] = dtPermission;

                data.message = "las Credenciales validas";

                var perm = System.Web.HttpContext.Current.Session["permission"];

                data.url = Url.Action("Proyect", "ControlSheet") ;//"ControlSheet/Proyect";
            }
            catch(Exception ex)
            {
                data.message = ex.Message;
                data.status = "error";
                return Json(data, JsonRequestBehavior.AllowGet);

            }

            return Json( data, JsonRequestBehavior.AllowGet);
            //return Json(new { url = Url.Action("Proyect", "ControlSheet") });


        }

        public JsonResult CreateUserAdmin(string nameCompany, string eMail, string pass)
        {
            try
            {
                var eMailValid = MailService.IsEmail(eMail);

                if (!eMailValid)
                {
                    data.message = "Se ha ingresado un email no valido";
                    data.status = "error";
                    return Json(data, JsonRequestBehavior.AllowGet); 

                }

                Userservice.CreateUserAdmin(nameCompany, eMail, pass);

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
