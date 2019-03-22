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
        public int O_State { get; set; }//状态   1已处理 2未处理   影院用
        public int CO_State { get; set; }//顾客订单状态  1、订票  2、退票 3、已使用 
        public DateTime O_STime { get; set; }//下单时间

        public SessionS SessionS { get; set; }
        public Custom Custom { get; set; }
    }
}
