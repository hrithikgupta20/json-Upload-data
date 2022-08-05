using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace json_Upload_data.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult uploadjson(HttpPostedFileBase filejson)
        {
            using (SampleDBEntities db = new SampleDBEntities())
            {
                if (!filejson.FileName.EndsWith(".json"))
                {
                    ViewBag.Errmsg = "Invalid file type(Only JSON file allowed)";
                }
                else
                {
                    
                    filejson.SaveAs(Server.MapPath("~/empfolder/" + Path.GetFileName(filejson.FileName)));
                    StreamReader reader = new StreamReader(Server.MapPath("~/empfolder/" + Path.GetFileName(filejson.FileName)));
                    string jsondata = reader.ReadToEnd();
                   empjsondata doc = JsonConvert.DeserializeObject<empjsondata>(jsondata);


                    //doc.ForEach(p =>
                    //{
                    //    @p.numFound.ToString();
                    //    @p.start.ToString();
                    //    @p.id.ToString();
                    //    @p.journal.ToString();
                    //    @p.publication_date.ToString();
                    //    @p.article_type.ToString();
                    //    @p.author_display.ToString();
                    //    @p.@abstract.ToString();
                    //    @p.title_display.ToString();
                    //    @p.score.ToString();
                    //    db.empjsondatas.Add(p);
                    //    db.SaveChanges();
                    //});
                    
                    ViewBag.message = "Selected" + Path.GetFileName(filejson.FileName) + "File uploaded Successfully..";
                }

            }
            return View("Index");
        }
    }
}