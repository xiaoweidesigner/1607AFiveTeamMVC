using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecallOnTimeMVC.Models
{
    //电影表
    public class Movie
    {
        [Key]
        public int MId { get; set; }//编号
        public string M_Name { get; set; }//电影名称
        public string M_Img { get; set; }//电影图片
        public int M_Time { get; set; }//电影时长
        public string M_Plot { get; set; }//剧情介绍
        public string M_Mold { get; set; }//所属类型
        public string M_FilmProducer { get; set; }//制片人
        public string M_Company { get; set; }//制片公司
        public string M_FileStar { get; set; }//影星
        public DateTime M_Show { get; set; }//上映时间
        public float M_Grade { get; set; }//评分
        public string M_Region { get; set; }//版本   2D/3D 中文版/英文版
        public decimal M_Price { get; set; }//单价
        public string M_Edition { get; set; }//地区
        public DateTime M_Year { get; set; }//年份
        public int M_State { get; set; }//状态 1上架  2下架
    }
}
