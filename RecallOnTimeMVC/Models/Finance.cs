using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecallOnTimeMVC.Models
{
    //财务表
    public class Finance
    {
        [Key]
        public int FId { get; set; }//编号
        public int Money { get; set; }//金额
        public DateTime CreateTime { get; set; }//创建时间
        [NotMapped]
        public float qian { get; set; }
        [NotMapped]
        public float qian2 { get; set; }
        [NotMapped]
        public int shu { get; set; }
        [NotMapped]
        public DateTime S_BeginTime { get; set; }//开始时间
    }
}
