using ControlSheet.Models;
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
        public int idUser = 1;
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
                //idUser = (int)System.Web.HttpContext.Current.Session["idUser"];
                //idCompany = (int)System.Web.HttpContext.Current.Session["idcompany"];

                HttpPostedFileBase _filePerfil = Request.Files["filePerfil"];
                HttpPostedFileBase _filePasion = Request.Files["filePasion"];
                HttpPostedFileBase _fileAlgo = Request.Files["fileAlgo"];
                string _personaData = Request.Form["personalData"];
                string _academyData = Request.Form["academyData"];
                string _experience = Request.Form["experience"];
                string _contact = Request.Form["contact"];

                byte[] imgPerfil = null;
                Stream myStreamPerfil = _filePerfil.InputStream;
                MemoryStream ms = new MemoryStream();
                myStreamPerfil.CopyTo(ms);
                imgPerfil = ms.ToArray();

                byte[] imgPasion = null;
                Stream myStreamPasion = _filePasion.InputStream;
                MemoryStream msPasion = new MemoryStream();
                myStreamPerfil.CopyTo(msPasion);
                imgPasion = msPasion.ToArray();

                byte[] imgAlgo = null;
                Stream myStreamAlgo = _filePasion.InputStream;
                MemoryStream msAlgo = new MemoryStream();
                myStreamAlgo.CopyTo(msAlgo);
                imgAlgo = msAlgo.ToArray();

                //string result = Convert.ToBase64String(imgPerfil);

                Service.InsertModifyProfile(imgPerfil, imgPasion, imgAlgo, _personaData, _academyData, _experience, _contact, idUser);

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

        public JsonResult LoadAllProfile()
        {
            try
            {
                dt = Service.GetAllProfile();

                var Imag = dt.Rows[0][1];

                //Convert.ToBase64String((byte[])dt.Rows[0][1]);
                //Convert.ToBase64String((byte[])dt.Rows[0][2]);
                //Convert.ToBase64String((byte[])dt.Rows[0][3]);

                var base64 = Convert.ToBase64String((byte[])dt.Rows[0][1]);
                var imgSrc = String.Format("data:image/png;base64,{0}", base64);

                MemoryStream ms = new MemoryStream((byte[])dt.Rows[0][1]);
                Image returnImage = Image.FromStream(ms);

                //dt.Columns.Add("newColum", typeof(System.String));
                //dt.Columns["newColum"].Expression = returnImage;

                Bitmap imagen = null;

                Byte[] bytes = (Byte[])((byte[])dt.Rows[0][1]);

                MemoryStream ms2 = new MemoryStream(bytes);

                imagen = new Bitmap(ms);

                ViewBag.Image = imagen;

                //Image img = Image.FromStream(ms);
                //dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = img;



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
