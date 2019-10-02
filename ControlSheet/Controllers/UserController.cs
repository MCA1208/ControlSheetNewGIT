using ControlSheet.Models;
using ControlSheet.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlSheet.Controllers
{
    public class UserController : Controller
    {
        ResultModel data = new ResultModel();
        UserService UserService = new UserService();
        SendMailService mailService = new SendMailService();
        Encrypting ServiceEncryp = new Encrypting();
        DataTable dt = null;
        public int idUser = 0;
        public int idCompany = 0;
        public string EncryptPass = "";

        [Authorize]
        // GET: User
        public ActionResult CreateUserOperator()
        {
            if(System.Web.HttpContext.Current.Session["idUser"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        [Authorize]
        public ActionResult Profiler()
        {
            return View();
        }

        [Authorize]
        public JsonResult CreateNewUserOperator(string EMail)
        {
            try
            {
                if (!mailService.IsEmail(EMail))
                {

                    data.message = "El EMail ingresado no es valido";
                    data.status = "error";
                   
                }
                else
                {
                    idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];

                    var countLic = (int)UserService.SpCountLicense(idCompany).Rows[0][0];

                    if (countLic == 0)
                    {
                        data.message = "Se puede crear hasta 4 usuarios";
                        data.status = "error";
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }

                    
                    var GeneratePass =  UserService.GenerateCode();
                    EncryptPass = ServiceEncryp.Encryp(GeneratePass);

                    dt = UserService.SpCreateUserOperator(EMail, idCompany, EncryptPass);


                    //mailService.SendMail(EMail, "Nuevo usuario", "Nueva Contraseña: " + EncryptPass);
                    data.message = "Se creo el Usuario con exito";
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

        [Authorize]
        public JsonResult ChangePassword(string Pass)
        {
            try
            {

                idUser = (int)System.Web.HttpContext.Current.Session["idUser"];

                EncryptPass = ServiceEncryp.Encryp(Pass);

                dt = UserService.SpChangePassword(idUser, EncryptPass);

                data.message = "Se cambió la contraseña con exito";
              
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
        public JsonResult LoadUser()
        {
            try
            {
                idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];

                dt = UserService.spGetUserForIdCompany(idCompany);
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
        public JsonResult DeleteUser(int idUser)
        {
            try
            {


                dt = UserService.SpdeleteUser(idUser);

                data.message = "Se eliminó el usuario con exito";

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
