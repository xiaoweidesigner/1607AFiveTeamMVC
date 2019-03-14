using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecallOnTimeMVC.Models
{
    //财务表
    public class Finance
    {
        [Key]
        public int FId { get; set; }//编号
        public int SessionSId{ get; set; }//场次表外键
        public string F_Content { get; set; }//活动内容
        public DateTime F_BeginTime { get; set; }//开始时间
        public DateTime F_EndTime { get; set; }//结束时间
    }
}
