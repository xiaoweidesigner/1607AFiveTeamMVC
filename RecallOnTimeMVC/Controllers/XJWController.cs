using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecallOnTimeMVC.Models;
using Newtonsoft.Json;
using System.IO;

namespace RecallOnTimeMVC.Controllers
{
    public class XJWController : Controller
    {
        #region 首页显示所需数据
        //获取清洁部员工的订单数量   指放映厅状态为需打扫的数量(不包括正在打扫的放映厅)
        public int ShowMovieHallIs3Num()
        {
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowMovieHall", "get");
            var list = JsonConvert.DeserializeObject<List<MovieHall>>(str);
            list = list.Where(s => s.H_State == 3).ToList();
            return list.Count;
        }
        //获取未处理订单的数量
        public int ShowOrderNum()
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/Zhizhi/ShowOrder", "get");
            List<Order> list = JsonConvert.DeserializeObject<List<Order>>(jsonResult);
            return list.Count;
        }
        #endregion

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
                Session["EId"] = e.EId;//用于修改密码   
                Session["User"] = e;//用于显示个人资料
                ViewBag.MovieHallNum = ShowMovieHallIs3Num();//放映厅为需打扫状态的数量
                ViewBag.OrderNum = ShowOrderNum();//未处理订单的数量
                Response.Write("<script>alert('登录成功');location.href='/XJW/ShowCustom';</script>");
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
        public void CZ(float C_integral, int CId)
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/Xjw/CZ?C_integral={C_integral}&CId={CId}", "get");
            int result = JsonConvert.DeserializeObject<int>(jsonResult);
            if (result > 0)
            {
                Response.Write("<script>alert('充值成功');location.href='/XJW/ShowHYCustom';</script>");
            }
            else
            {
                Response.Write("<script>alert('充值失败');location.href='/XJW/ShowHYCustom';</script>");
            }
        }
        //加入会员
        public void JoinHY(int CId, string C_Name, HttpPostedFileBase file)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/CustomImg/", file.FileName);
            file.SaveAs(path);
            string Img = Server.MapPath("/CustomImg/") + file.FileName;
            string jsonResult = HttpClientHelper.SendRequest($"api/Xjw/Join?CId={CId}&C_Name={C_Name}&Img={Img}", "get");
            int result = JsonConvert.DeserializeObject<int>(jsonResult);
            if (result > 0)
            {
                Response.Write("<script>alert('恭喜你，成为我们的尊贵会员，积分会让你享受更好的优惠');location.href='/XJW/ShowCustom';</script>");
            }
            else
            {
                Response.Write("<script>alert('对不起，没能成为会员');location.href='/XJW/ShowCustom';</script>");
            }
        }
        #endregion
        #region 个人信息展示页面
        [HttpGet]
        public ActionResult EditPerpon()
        {
            var employee = Session["User"];
            Employee em = employee as Employee;
            return View(em);
        }
        #endregion
        #region 员工登录功能
        //视图
        public ActionResult ShowSHMovieHall()
        {
            int EId = Convert.ToInt32(Session["EId"]);
            ViewBag.EId = EId;
            return View();
        }
        //获取需打扫放映厅的列表  方法
        public string ShowMovieHall()
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/Xjw/SH", "get");
            List<MovieHall> list = JsonConvert.DeserializeObject<List<MovieHall>>(jsonResult);
            return JsonConvert.SerializeObject(list);
        }
        //改变清洁工员工状态为工作中  放映厅为打扫中
        public void ChangeEMStatus(int EId, int HId)
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/Xjw/UpdEmployeeStatus?EId={EId}&HId={HId}", "get");
            int Result = JsonConvert.DeserializeObject<int>(jsonResult);
            if (Result > 0)
            {
                Response.Write("<script>alert('已成功接收工作,望亲加油');location.href='/XJW/ShowSHMovieHall'</script>");
            }
            else
            {
                Response.Write("<script>alert('接收工作失败,请稍等片刻');location.href='/XJW/ShowSHMovieHall'</script>");
            }
        }
        //改变清洁工员工状态为空闲中  放映厅为空闲中
        public void ChangeEMStatusAndMovieHallStatus(int EId, int HId)
        {
            string jsonResult = HttpClientHelper.SendRequest($"api/Xjw/UpdEmployeeStatus2?EId={EId}&HId={HId}", "get");
            int Result = JsonConvert.DeserializeObject<int>(jsonResult);
            if (Result > 0)
            {
                Response.Write("<script>alert('工作交接完成，亲，辛苦了！');location.href='/XJW/ShowSHMovieHall'</script>");
            }
            else
            {
                Response.Write("<script>alert('交接失败，请稍等重试！');location.href='/XJW/ShowSHMovieHall'</script>");
            }
        }
        //场次开始时  改变放映厅状态为放映中
        //场次结束时   改变放映厅状态为需打扫   sql server作业完成
        #endregion
    }
}