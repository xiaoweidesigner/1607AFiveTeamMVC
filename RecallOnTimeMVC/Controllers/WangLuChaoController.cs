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
        public ActionResult ShowDepartMent()
        {
            string result = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowDepartMent", null);
            List<DepartMent> jias = JsonConvert.DeserializeObject<List<DepartMent>>(result);
            return View(jias);
        }
        [HttpGet]
        public ActionResult AddDepartMent()
        {
            return View();
        }
        [HttpPost]
        public void AddDepartMent(DepartMent mm)
        {
            mm.Num = 0;
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
            string result = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowEmployee", null);
            List<Employee> jias = JsonConvert.DeserializeObject<List<Employee>>(result);
            return View(jias);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            ShopName();
            return View();
        }
        public void ShopName()
        {
            string sn = HttpClientHelpers.Send("get", "api/WangLuChao/ShowDepartMent", null);

            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(sn);

            ViewBag.Gid = new SelectList(list, "DId", "D_Name");
        }
        [HttpPost]
        public string AddEmployees(Employee mm, HttpPostedFileBase file)
        {
            ShopName();
            string ee = Server.MapPath("/employImg/");
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
            file.SaveAs(ee + filename);

            mm.E_Img = ee + filename;
            mm.E_State = 1;//状态为空闲中
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
            return "1";
        }
        public ActionResult CeShi()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UpdEmployee(int Id)
        {
            ViewBag.EId = Id;
            return View();
        }
        [HttpPost]
        public string UpdEmployees(Employee mm, HttpPostedFileBase file)
        {

            string ee = Server.MapPath("/employImg/");
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
            file.SaveAs(ee + filename);

            mm.E_Img = ee + filename;
            string json = JsonConvert.SerializeObject(mm);
            string result = HttpClientHelpers.Send("post", "/api/WangLuChao/UpdEmployee", json);
            if (Convert.ToInt32(result) > 0)
            {
                Response.Write("<script>alert('ok')</script>");
            }
            else
            {
                Response.Write("<script>alert('bu ok')</script>");
            }
            return "1";
        }
    }
}