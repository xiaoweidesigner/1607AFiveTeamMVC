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
        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowDepartMent()
        {
            return View();
        }
        public string showdeparMent()
        {
            string result = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowDepartMent", null);
            List<DepartMent> jias = JsonConvert.DeserializeObject<List<DepartMent>>(result);
            return JsonConvert.SerializeObject(jias);
        }
        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        /// 
        public string HHer()
        {
            string result = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowDepartMent", null);
            List<DepartMent> jias = JsonConvert.DeserializeObject<List<DepartMent>>(result);
            return JsonConvert.SerializeObject(jias);
        }

        public void AddDepartMent(DepartMent mm)
        {
            mm.Num = 0;
            string json = JsonConvert.SerializeObject(mm);
            string result = HttpClientHelpers.Send("post", "/api/WangLuChao/AddDepartMent", json);
            if (Convert.ToInt32(result) > 0)
            {
                Response.Write("<script><script>alert('ok');location.href='/WangLuChao/ShowDepartMent'</script>");
            }
            else
            {
                Response.Write("<script>alert('bu ok')</script>");
            }
        }
        /// <summary>
        /// 显示员工
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ShowEmployee()
        {
            return View();
        }
        
        public string Show()
        {
            string result = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowEmployee", null);
            List<Employee> jias = JsonConvert.DeserializeObject<List<Employee>>(result);
            return JsonConvert.SerializeObject(jias);
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public string AddEmployees(Employee mm, HttpPostedFileBase E_Img)
        {
            string ee = Server.MapPath("/employImg/");
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + E_Img.FileName;
            E_Img.SaveAs(ee + filename);
            mm.E_Img = "/employImg/" + filename;
            mm.E_State = 1;//状态为
            string json = JsonConvert.SerializeObject(mm);
            string result = HttpClientHelpers.Send("post", "/api/WangLuChao/AddEmployee", json);
            if (Convert.ToInt32(result) > 0)
            {
                Response.Write("<script>alert('ok');location.href='/WangLuChao/ShowEmployee'</script>");
            }
            else
            {
                Response.Write("<script>alert('bu ok')</script>");
            }
            return "1";
        }
        /// <summary>
        /// 测试信息
        /// </summary>
        /// <returns></returns>
        public ActionResult CeShi()
        {
            return View();
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdEmployee(int Id)
        {
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
        /// <summary>
        /// 显示评论信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowComment()
        {
            return View();
        }
        public string comment()
        {
            string result = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowComments", null);
            List<Comment> jias = JsonConvert.DeserializeObject<List<Comment>>(result);
            return JsonConvert.SerializeObject(jias);
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="CoId"></param>
        /// <returns></returns>
        public int delcc(int CoId)
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/WangLuChao/DelComments/{CoId}", "get");
             int result = JsonConvert.DeserializeObject<int>(jsonResult);
            return result;
        }
        /// <summary>
        /// 显示金额
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowFinace()
        {
            return View();
        }
        public string finace()
        {
            string fin = HttpClientHelpers.Send("get", "/api/WangLuChao/ShowFinances", null);
            List<Finance> ss = JsonConvert.DeserializeObject<List<Finance>>(fin);
            return JsonConvert.SerializeObject(ss);
        }
        public int updee(int EId)
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/WangLuChao/ShowEmployeeId/{EId}", "get");
            int result = JsonConvert.DeserializeObject<int>(jsonResult);
            return result;
        }
    }
}