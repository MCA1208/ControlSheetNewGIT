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
    public class LoginController : Controller
    {
        ResultModel data = new ResultModel();

        UserService service = new UserService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoginUser(string user, string pass)
        {

            try
            {


                service.sendMail("milton.amado10@gmail.com");
                    
               

                data.result = Convert.ToInt16("");

            }
            catch(Exception ex)
            {
                data.message = ex.Message;
                data.status = "error";
                return Json(data, JsonRequestBehavior.AllowGet);

            }

            return Json( data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateUserAdmin(string nameCompany, string eMail, string pass)
        {
            try
            {


                service.CreateUserAdmin(nameCompany, eMail, pass);


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
