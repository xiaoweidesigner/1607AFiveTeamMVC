using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecallOnTimeMVC.Models
{
    //订单表
    public class Order
    {
        [Key]
        public int OId { get; set; }//编号
        [ForeignKey("SessionS")]
        public int SessionSId { get; set; }//场次表外键
        public decimal O_Money { get; set; }//金额
        [ForeignKey("Custom")]
        public int CustomId { get; set; }//顾客表外键
        public int O_State { get; set; }//状态

        public SessionS SessionS { get; set; }
        public Custom Custom { get; set; }
    }
}
