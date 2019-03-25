using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecallOnTimeMVC.Models
{
    public class OMCH
    {
        public int OId { get; set; }//编号
        public decimal O_Money { get; set; }//金额
        public int O_State { get; set; }//状态   1已处理 2未处理  
        public string MName { get; set; }
        public string HName { get; set; }
        public string CName { get; set; }
        public DateTime BeginTime { get; set; }
        public string Phone { get; set; }
        public string SeatContent { get; set; }
    }
}