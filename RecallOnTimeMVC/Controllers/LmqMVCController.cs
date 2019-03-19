using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecallOnTimeMVC.Models;
using Newtonsoft.Json;

namespace RecallOnTimeMVC.Controllers
{
    public class LmqMVCController : Controller
    {
        #region 影片
        //添加影片页面
        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }
        //实现添加影片功能
        [HttpPost]
        public ActionResult AddMovie(Movie movie,HttpPostedFileBase file,string[] M_Mold)
        {
            movie.M_State = 1;//影片状态默认为上架1
            var name = Server.MapPath("~/MovieImg/");
            var fileName = DateTime.Now.ToString("yyyyMMddhhmmss")+ file.FileName;
            file.SaveAs(name+fileName);
            movie.M_Img ="/MovieImg/" + fileName;
            movie.M_Mold = string.Join(",", M_Mold);
            string str = JsonConvert.SerializeObject(movie);
            string i = HttpClientHelper.SendRequest("api/Lmq/AddMovie", "post", str);
            if (i == "1")
            {
                return Content("<script>alert('添加成功');location.href='/LmqMVC/AddMovie';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败')location.href='/LmqMVC/AddMovie';</script>");
            }
        }
        [HttpGet]
        //显示影片
        public ActionResult ShowMovie() {
            return View();
        }
        //显示影片
        public string ShowMovieMethod()
        {
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowMovie", "get");
            var list = JsonConvert.DeserializeObject<List<Movie>>(str);
            return JsonConvert.SerializeObject(list);
        }
        //根据Id查询
        public ActionResult ShowMovieById(int Id) {
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowByIdMovie?Id="+Id,"get");
            var movie= JsonConvert.DeserializeObject<Movie>(str);
            return View(movie);
        }
        //修改上下架
        public string UpdJia(int State, int Mid)
        {
            var i = HttpClientHelper.SendRequest($"api/Lmq/UpdJia?State={State}&Mid={Mid}", "put");
            return i;
        }
        #endregion
        #region 场次
        //显示场次页面
        [HttpGet]
        public ActionResult ShowSessionS() {
            return View();
        }
        //实现显示场次功能
        public string ShowSessionSMethod()
        {
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowSessionS", "get");
            var list = JsonConvert.DeserializeObject<List<SessionS>>(str);
            return JsonConvert.SerializeObject(list);
        }
        //添加场次页面
        [HttpGet]
        public ActionResult AddSessionS()
        {
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowMovie", "get");
            var list = JsonConvert.DeserializeObject<List<Movie>>(str);
            var time = DateTime.Parse(DateTime.Now.ToString().Substring(0, 10) + "00:00:00.000");
            var selList = list.Where(l=>l.M_Show==time);
            ViewBag.movie = new SelectList(selList, "MId", "M_Name");
            var str1 = HttpClientHelper.SendRequest("api/Lmq/ShowMovieHall", "get");
            var list1 = JsonConvert.DeserializeObject<List<MovieHall>>(str1);
            var selList2 = list1.Where(l=>l.H_State==1);
            ViewBag.moviehall = new SelectList(selList2, "HId", "H_Name");
            return View();
        }
        //实现添加场次功能
        [HttpPost]
        public ActionResult AddSessionS(SessionS session)
        {
            //查询电影时长
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowMovie", "get");
            var list = JsonConvert.DeserializeObject<List<Movie>>(str);
            var mid = list.Where(l => l.MId == session.MovieId).FirstOrDefault().M_Time;//电影时长
            session.S_EndTime = session.S_BeginTime.AddMinutes(mid);
            string str1 = JsonConvert.SerializeObject(session);
            string i = HttpClientHelper.SendRequest("api/Lmq/AddSessionS", "post", str1);
            if (i == "1")
            {
                return Content("<script>alert('添加成功');location.href='/LmqMVC/AddSessionS';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');location.href='/LmqMVC/AddSessionS';</script>");
            }
        }

        #endregion
        #region 影厅
        //显示影厅页面
        public ActionResult ShowMovieHall()
        {
            return View();
        }
        //实现显示影厅功能
        public string ShowMovieHallMethod()
       {
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowMovieHall", "get");
            var list = JsonConvert.DeserializeObject<List<MovieHall>>(str);
            return JsonConvert.SerializeObject(list);
        }
        //添加影厅
        public string AddMovieHall(MovieHall hall, HttpPostedFileBase file)
        {
            hall.H_State = 1;//影厅状态默认为未使用1  
            var name = Server.MapPath("/MovieHallImg/");
            var fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + file.FileName;
            file.SaveAs(name + fileName);
            hall.H_Photo = "/MovieHallImg/" + fileName;
            string str = JsonConvert.SerializeObject(hall);
            string i = HttpClientHelper.SendRequest("api/Lmq/AddMovieHall", "post", str);
            if (i == "1")
            {
                return "<script>alert('添加成功');location.href='/LmqMVC/AddMovieHall';</script>";
            }
            else
            {
                return "<script>alert('添加失败');location.href='/LmqMVC/AddMovieHall';</script>";
            }
        }

        #endregion
        #region 订单
        public ActionResult ShowOrder() {
            return View();
        }
        public string ShowOrderMethod() {
            var str = HttpClientHelper.SendRequest("api/Zhizhi/ShowOrder", "get");
            var list = JsonConvert.DeserializeObject<List<Order>>(str);
            return JsonConvert.SerializeObject(list);
        }
        //已处理订单 1
        public ActionResult ShowDisposedOrder() {
            return View();
        }
        public string ShowDisposedOrderM()
        {
            var str = HttpClientHelper.SendRequest("api/Zhizhi/ShowOrder", "get");
            var list = JsonConvert.DeserializeObject<List<Order>>(str);
            var showList = list.Where(l=>l.O_State==1);
            return JsonConvert.SerializeObject(showList);
        }
        //未处理订单 2
        public ActionResult ShowUndisposedOrder() {
            return View();
        }
        public string ShowUndisposedOrderM()
        {
            var str = HttpClientHelper.SendRequest("api/Zhizhi/ShowOrder", "get");
            var list = JsonConvert.DeserializeObject<List<Order>>(str);
            var showList = list.Where(l => l.O_State == 2);
            return JsonConvert.SerializeObject(showList);
        }
        //处理订单状态
        public string DisposeOrder(int Oid) {
            var i = HttpClientHelper.SendRequest($"api/Zhizhi/DisposedOrder?Oid={Oid}", "put");
            return i;
        }
        #endregion
    }
}
