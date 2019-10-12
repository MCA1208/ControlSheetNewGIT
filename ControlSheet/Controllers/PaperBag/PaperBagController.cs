using ControlSheet.Helper;
using ControlSheet.Models;
using ControlSheet.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

                if (!Directory.Exists(Server.MapPath("~/Pictures")))
                    Directory.CreateDirectory(Server.MapPath("~/Pictures"));

                if (_filePerfil != null)
                {
                    

                    var namePathPerfil = Path.GetFileName(_filePerfil.FileName).Replace(_filePerfil.FileName, idUser.ToString() + "_perfil.jpg");
                    System.IO.File.Delete(Server.MapPath("~/Pictures") + "\\" + namePathPerfil);
                     _filePerfil.SaveAs(Server.MapPath("~/Pictures") +"\\" + namePathPerfil);


                }


                if (_filePasion != null)
                {
                    var namePathPasion = Path.GetFileName(_filePasion.FileName).Replace(_filePasion.FileName, idUser.ToString() + "_pasion.jpg");
                    System.IO.File.Delete(Server.MapPath("~/Pictures") + "\\" + namePathPasion);
                    _filePasion.SaveAs(Server.MapPath("~/Pictures") + "\\" + namePathPasion);


                }


                if (_fileAlgo != null)
                {
                    var namePathAlgo = Path.GetFileName(_fileAlgo.FileName).Replace(_fileAlgo.FileName, idUser.ToString() + "_algo.jpg");
                    System.IO.File.Delete(Server.MapPath("~/Pictures") + "\\" + namePathAlgo);
                    _fileAlgo.SaveAs(Server.MapPath("~/Pictures") + "\\" + namePathAlgo);

                }

                Service.InsertModifyProfile( _name, _profession, _academyData, _experience, _contact, idUser);

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

                string imgB64Perfil = string.Empty;
                string imgB64Pasion = string.Empty;
                string imgB64Algo = string.Empty;

                foreach (DataRow row in dt.Rows)
                {

                    string filePerfil = Directory.GetFiles(Server.MapPath("~/Pictures"), row[10] + "_perfil.jpg").FirstOrDefault(x => x.Contains(row[10] + "_perfil.jpg"));
                    string filePasion = Directory.GetFiles(Server.MapPath("~/Pictures"), row[10] + "_pasion.jpg").FirstOrDefault(x => x.Contains(row[10] + "_pasion.jpg"));
                    string fileAlgo = Directory.GetFiles(Server.MapPath("~/Pictures"), row[10] + "_algo.jpg").FirstOrDefault(x => x.Contains(row[10] + "_algo.jpg"));


                    if (!string.IsNullOrWhiteSpace(filePerfil))
                    {
                        imgB64Perfil = ImageHelper.ImageFileToB64(filePerfil);

                        row[0] = imgB64Perfil;
                    }

                    if (!string.IsNullOrWhiteSpace(filePasion))
                    {
                        imgB64Pasion = ImageHelper.ImageFileToB64(filePasion);

                        row[1] = imgB64Pasion;
                    }

                    if (!string.IsNullOrWhiteSpace(fileAlgo))
                    {
                        imgB64Algo = ImageHelper.ImageFileToB64(fileAlgo);

                        row[2] = imgB64Algo;
                    }

                }



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
                var pathCombinePerfil = Path.Combine(Server.MapPath("~/Pictures"), Id.ToString() + "_perfil.jpg");
                var pathCombinePasion = Path.Combine(Server.MapPath("~/Pictures"), Id.ToString() + "_pasion.jpg");
                var pathCombineAlgo = Path.Combine(Server.MapPath("~/Pictures"), Id.ToString() + "_algo.jpg");

                string imgB64Perfil = string.Empty;

                if (System.IO.File.Exists(pathCombinePerfil))
                    imgB64Perfil = ImageHelper.ImageFileToB64(pathCombinePerfil);
                
                string imgB64Pasion = string.Empty;

                if (System.IO.File.Exists(pathCombinePasion))
                    imgB64Pasion = ImageHelper.ImageFileToB64(pathCombinePasion);

                string imgB64Algo = string.Empty;

                if (System.IO.File.Exists(pathCombineAlgo))
                    imgB64Algo = ImageHelper.ImageFileToB64(pathCombineAlgo);


                dt.Rows[0][0] = imgB64Perfil;
                dt.Rows[0][1] = imgB64Pasion;
                dt.Rows[0][2] = imgB64Algo;
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