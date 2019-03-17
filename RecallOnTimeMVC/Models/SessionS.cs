using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecallOnTimeMVC.Models
{
    //场次表
    public class SessionS
    {
        [Key]
        public int SId { get; set; }//编号
        [ForeignKey("Movie")]
        public int MovieId { get; set; }//电影外键

        [ForeignKey("MovieHall")]
        public int MovieHallId { get; set; }//放映厅外键
        public DateTime S_BeginTime { get; set; }//开始时间
        public DateTime S_EndTime { get; set; }//结束时间

        public Movie Movie { get; set; }

        public MovieHall MovieHall { get; set; }
    }
}
