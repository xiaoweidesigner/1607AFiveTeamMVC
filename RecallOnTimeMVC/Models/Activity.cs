using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecallOnTimeMVC.Models
{
    //活动表
    public class Activity
    {
        [Key]
        public int AId { get; set; }//编号
        public string A_Title { get; set; }//活动标题
        public string A_Content { get; set; }//活动内容
        [ForeignKey("Movie")]
        public int MovieId { get; set; }//电影表外键
        [ForeignKey("MovieHall")]
        public int MovieHallId { get; set; }//放映厅表外键

        public Movie Movie { get; set; }
        public MovieHall MovieHall { get; set; }
    }
}
