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
        public int Money { get; set; }//金额
        public DateTime CreateTime { get; set; }//创建时间
    }
}
