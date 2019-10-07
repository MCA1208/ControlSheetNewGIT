using ControlSheet.Models;
using ControlSheet.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlSheet.Controllers.PaperBag
{
    public class PaperBagController : Controller
    {

        ResultModel data = new ResultModel();
        Service.paperBag.ProfileDetailService Service = new Service.paperBag.ProfileDetailService();

        DataTable dt = null;
        public int idUser = 0;
        public int idCompany = 0;
        // GET: PaperBag
        public ActionResult Principal()
        {
            return View();
        }

        [Authorize]
        public JsonResult ModifyPerfil(HttpPostedFileBase filePerfil)
        {
            try
            {
                idUser = (int)System.Web.HttpContext.Current.Session["idUser"];

                HttpPostedFileBase _filePerfil = Request.Files["filePerfil"];
                HttpPostedFileBase _filePasion = Request.Files["filePasion"];
                HttpPostedFileBase _fileAlgo = Request.Files["fileAlgo"];
                string _name = Request.Form["name"];
                string _profession = Request.Form["profession"];
                string _academyData = Request.Form["academyData"];
                string _experience = Request.Form["experience"];
                string _contact = Request.Form["contact"];

                byte[] imgPerfil = null;

                if (_filePerfil != null)
                {
                    Stream myStreamPerfil = _filePerfil.InputStream;
                    MemoryStream ms = new MemoryStream();
                    myStreamPerfil.CopyTo(ms);
                    imgPerfil = ms.ToArray();
                }


                byte[] imgPasion = null;

                if (_filePasion != null)
                {
                    Stream myStreamPasion = _filePasion.InputStream;
                    MemoryStream msPasion = new MemoryStream();
                    myStreamPasion.CopyTo(msPasion);
                    imgPasion = msPasion.ToArray();
                 }


                byte[] imgAlgo = null;

                if (_fileAlgo != null)
                {
                    Stream myStreamAlgo = _fileAlgo.InputStream;
                    MemoryStream msAlgo = new MemoryStream();
                    myStreamAlgo.CopyTo(msAlgo);
                    imgAlgo = msAlgo.ToArray();
                }


                Service.InsertModifyProfile(imgPerfil, imgPasion, imgAlgo, _name, _profession, _academyData, _experience, _contact, idUser);

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
        public JsonResult LoadAllProfile()
        {

            try
            {
                dt = Service.GetAllProfile();


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
        public JsonResult GetProfileForId(int? Id)
        {
            try
            {
                if (Id == null)
                    Id = (int)System.Web.HttpContext.Current.Session["idUser"];

                dt = Service.GetProfileForId(Id);

                var imageFile = File(dt.Columns[1].ToString(), "image/png");

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
        public JsonResult HasProfile()
        {
            try
            {

                var Id = (int)System.Web.HttpContext.Current.Session["idUser"];


                dt = Service.GetProfileForId(Id);

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