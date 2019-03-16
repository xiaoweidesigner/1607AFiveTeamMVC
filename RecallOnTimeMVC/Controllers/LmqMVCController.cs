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
        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMovie(Movie movie, HttpPostedFileBase M_Img)
        {

            string ee = Server.MapPath("/MovieImg/");
            string name = DateTime.Now.ToString("yyyyMMddhhmmss") + M_Img.FileName;
            M_Img.SaveAs(ee + name);
            movie.M_Img = ee + name;

            string str = JsonConvert.SerializeObject(movie);
            string i = HttpClientHelper.SendRequest("api/Lmq/AddMovie", "post", str);
            if (i == "1")
            {
                return Content("<script>alert('添加成功')</script>");
            }
            else
            {
                return Content("<script>alert('添加失败')</script>");
            }
        }
        public ActionResult ShowMovie()
        {
            string str = HttpClientHelper.SendRequest("api/Lmq/ShowMovie", "get");
            var list = JsonConvert.DeserializeObject<List<Movie>>(str);
            return View(list);
        }
        public ActionResult ShowMovieById(int Id)
        {
            var str = HttpClientHelper.SendRequest("api/Lmq/ShowByIdMovie?Id=" + Id, "get");
            var movie = JsonConvert.DeserializeObject<Movie>(str);
            return View(movie);
        }

        #endregion
        #region 场次

        #endregion
        #region 影厅
        public ActionResult ShowMovieHall()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddMovieHall() {
            return View();
        }
        [HttpPost]
        public ActionResult AddMovieHall(MovieHall hall)
        {
            return View();
        }
        #endregion
    }
}