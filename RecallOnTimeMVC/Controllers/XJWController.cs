using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecallOnTimeMVC.Models;
using Newtonsoft.Json;

namespace RecallOnTimeMVC.Controllers
{
    public class XJWController : Controller
    {
        #region 登录
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public void Login(string E_Account, string E_Pwd)
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/WangLuChao/Login?E_Account={E_Account}&E_Pwd={E_Pwd}", "get");
            Employee e = JsonConvert.DeserializeObject<Employee>(jsonResult);
            if (e != null)
            {
                Session["Name"] = e.E_Name;//保存姓名
                Session["DepartmentId"] = e.DepartMentId;//保存所属部门
                Response.Write("<script>alert('登录成功');location.href='/LmqMVC/Index';</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败');</script>");
            }
        }
        #endregion
        #region 顾客列表显示

        //所有顾客
        public ActionResult ShowCustom()
        {
            return View();
        }
        //普通顾客
        public ActionResult ShowCommonCustom()
        {
            return View();
        }
        //会员
        public ActionResult ShowHYCustom()
        {
            return View();
        }
        //列表调用方法
        public string MethodShow(string C_Name = "", string C_Cellphone = "", int C_State = 0)
        {
            string jsonResult = HttpClientHelper.SendRequest("api/Xjw/ShowCustom", "get");
            List<Custom> list = JsonConvert.DeserializeObject<List<Custom>>(jsonResult);
            if (C_Name != "")
            {
                list = list.Where(s => s.C_Name.Contains(C_Name)).ToList();
            }
            if (C_Cellphone != "")
            {
                list = list.Where(s => s.C_Cellphone.Contains(C_Cellphone)).ToList();
            }
            if (C_State != 0)
            {
                list = list.Where(s => s.C_State == C_State).ToList();
            }
            return JsonConvert.SerializeObject(list);
        }
        //充值方法
        public int CZ(float C_integral, int CId)
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/Xjw/CZ?C_integral={C_integral}&CId={CId}", "get");
            int result = JsonConvert.DeserializeObject<int>(jsonResult);
            return result;
        }
        #endregion
    }
}