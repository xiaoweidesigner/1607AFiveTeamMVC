
using RecallOnTimeMVC.html5_canvas_chart_js;
using RecallOnTimeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace RecallOnTimeMVC.Controllers
{
    public class ZhiController : Controller
    {
        // GET: Zhi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public ActionResult GuanYu()
        {
            return View();
        }

        /// <summary>
        /// 财务报表
        /// </summary>
        /// <returns></returns>
        public ActionResult CaiWu()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

           string json=  GetApi.Getapiresult("get", "ShowCaiwuRi/?year=" + year + "&month=" + month + "&day=" + day + "&state=0");
            List<Finance> list = JsonConvert.DeserializeObject<List<Finance>>(json);
            ViewBag.jiaoyijine = list.FirstOrDefault().qian;
            ViewBag.dingdanshuliang = list.FirstOrDefault().shu;
            string json1 = GetApi.Getapiresult("get", "ShowCaiwuRi/?year=" + year + "&month=" + month + "&day=" + day + "&state=1");
            List<Finance> list1 = JsonConvert.DeserializeObject<List<Finance>>(json1);
            ViewBag.jiaoyichenggong = list1.FirstOrDefault().qian;
            
            string json2 = GetApi.Getapiresult("get", "ShowCaiwuRi/?year=" + year + "&month=" + month + "&day=" + day + "&state=2");
            List<Finance> list2 = JsonConvert.DeserializeObject<List<Finance>>(json2);
            ViewBag.tuikuanjine = list2.FirstOrDefault().qian;


            string json3 = GetApi.Getapiresult("get", "ShowTuBiaoRi/?year=" + year + "&month=" + month + "&day=" + day);
            List<Finance> list3 = JsonConvert.DeserializeObject<List<Finance>>(json3);

            string s ="";
            string ss = "'";
            foreach (var item in list3)
            {
                s+= "'"+ item.S_BeginTime+"',";
            }
            
            ViewBag.shijian =s;


            string q ="";
          
            foreach (var item in list3)
            {
                q += item.qian2+",";
            }
            ViewBag.qian2 = q;


            return View(list3);
        }


        public ActionResult shuju(int nian,int yue,int ri)
        {
            string json = GetApi.Getapiresult("get", "ShowCaiwuRi/?year=" + nian + "&month=" + yue + "&day=" + ri + "&state=0");
            List<Finance> list = JsonConvert.DeserializeObject<List<Finance>>(json);
            ViewBag.jiaoyijine = list.FirstOrDefault().qian;
            ViewBag.dingdanshuliang = list.FirstOrDefault().shu;
            string json1 = GetApi.Getapiresult("get", "ShowCaiwuRi/?year=" + nian + "&month=" + yue + "&day=" + ri + "&state=1");
            List<Finance> list1 = JsonConvert.DeserializeObject<List<Finance>>(json1);
            ViewBag.jiaoyichenggong = list1.FirstOrDefault().qian;

            string json2 = GetApi.Getapiresult("get", "ShowCaiwuRi/?year=" + nian + "&month=" + yue + "&day=" + ri + "&state=2");
            List<Finance> list2 = JsonConvert.DeserializeObject<List<Finance>>(json2);
            ViewBag.tuikuanjine = list2.FirstOrDefault().qian;


            string json3 = GetApi.Getapiresult("get", "ShowTuBiaoRi/?year=" + nian + "&month=" + yue + "&day=" + ri);
            List<Finance> list3 = JsonConvert.DeserializeObject<List<Finance>>(json3);

            string s = "";
            string ss = "'";
            foreach (var item in list3)
            {
                s += "'" + item.S_BeginTime + "',";
            }

            ViewBag.shijian = s;


            string q = "";

            foreach (var item in list3)
            {
                q += item.qian2 + ",";
            }
            ViewBag.qian2 = q;
            return View(CaiWu());
        }





    }
}