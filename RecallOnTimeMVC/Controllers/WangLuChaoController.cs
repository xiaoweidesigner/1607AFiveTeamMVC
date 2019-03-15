using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RecallOnTimeMVC.Controllers;
using RecallOnTimeMVC.Models;

namespace RecallOnTimeMVC.Controllers
{
    public class WangLuChaoController : Controller
    {
        // GET: WangLuChao
        //显示部门
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddDepartMent()
        {
            return View();
        }
        [HttpPost]
        public void AddDepartMent(DepartMent mm)
        {
           
            string json = JsonConvert.SerializeObject(mm);
            string result = HttpClientHelpers.Send("post", "/api/WangLuChao/AddDepartMent", json);
            if (Convert.ToInt32(result) > 0)
            {
                Response.Write("<script>alert('ok')</script>");
            }
            else
            {
                Response.Write("<script>alert('bu ok')</script>");
            }
        }
        public ActionResult ShowEmployee()
        {
            return View();
        }
        public void ShopXia()
        {
            string sn = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowDepartMent", null);

            List<DepartMent> list = JsonConvert.DeserializeObject<List<DepartMent>>(sn);

            ViewBag.DId = new SelectList(list, "DId", "D_Name");
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            ShopXia();
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee mm, HttpPostedFileBase file)
        {
            string ee = Server.MapPath("/employImg/");
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
            file.SaveAs(ee + filename);
            mm.E_Img = ee + filename;

            mm.E_State = 1;//状态为
            string json = JsonConvert.SerializeObject(mm);
            string result = HttpClientHelpers.Send("post", "/api/WangLuChao/AddEmployee", json);
            if (Convert.ToInt32(result) > 0)
            {
                Response.Write("<script>alert('ok')</script>");
            }
            else
            {
                Response.Write("<script>alert('bu ok')</script>");
            }
            return View();
        }
    }
}