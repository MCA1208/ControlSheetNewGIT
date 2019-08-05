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

        UserService UserService = new UserService();
        SendMailService MailService = new SendMailService();
        Encrypting ServiceEncryp = new Encrypting();
        public string EncryptPass = null;
        public string DesCryptPass = null;


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
                EncryptPass = ServiceEncryp.Encryp(pass);

                DataTable dt =  UserService.spGetUse(user);

                if(dt.Rows.Count == 0)
                {
                    data.message = "las Credenciales ingresadas no son validas";
                    data.status = "error";
                    return Json(data, JsonRequestBehavior.AllowGet);

                }
                var PassDB = dt.Rows[0]["password"].ToString();
                var descripPassDB = ServiceEncryp.Decrypt(PassDB);

                if(pass == PassDB || pass == descripPassDB)
                {

                    var em = dt.Rows[0]["email"];
                    System.Web.HttpContext.Current.Session["idUser"] = dt.Rows[0]["id"];
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

                    DataTable dtPermission = UserService.spGetPermissionByProfile(idProfile);

                    System.Web.HttpContext.Current.Session["permission"] = dtPermission;

                    data.message = "las Credenciales validas";

                    var perm = System.Web.HttpContext.Current.Session["permission"];

                    data.url = Url.Action("Proyect", "ControlSheet") ;

                }
                else
                {
                    data.message = "Contraseña Invalida";
                    data.status = "error";
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
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

                if ( UserService.spGetUse(eMail).Rows.Count > 0)
                {
                    data.message = "Ya existe una cuenta con el mail ingresado";
                    data.status = "error";
                    return Json(data, JsonRequestBehavior.AllowGet);

                }

                EncryptPass = ServiceEncryp.Encryp(pass);

                UserService.CreateUserAdmin(nameCompany, eMail, EncryptPass);

            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = "error";
                return Json(data, JsonRequestBehavior.AllowGet);

            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendRecoveryPassword(string EMail)
        {
            try
            {
                int longitud = 4;
                Guid miGuid = Guid.NewGuid();
                string token = Convert.ToBase64String(miGuid.ToByteArray());
                token = token.Replace("=", "").Replace("+", "");
                token = token.Substring(0, longitud);

                if (MailService.IsEmail(EMail))
                {
                    EncryptPass = ServiceEncryp.Encryp(token);

                    DataTable recPass = UserService.SpRecoveryPassword(EMail, EncryptPass);

                    if (recPass.Rows[0][0].ToString() == "OK")
                    {
                        MailService.SendMail(EMail,"Recuperación de contraseña","Nueva Contraseña: " + EncryptPass);
                    }
                    else
                    {
                        data.message = recPass.Rows[0][0].ToString();
                        data.status = "error";
                        return Json(data, JsonRequestBehavior.AllowGet);

                    }

                    data.message = recPass.Rows[0][0].ToString();
                }
                else
                {
                    data.message = "Se ha ingresado un email no valido";
                    data.status = "error";
                    return Json(data, JsonRequestBehavior.AllowGet);

                }


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
