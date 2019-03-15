using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecallOnTimeMVC.Models
{
    //顾客表
    public class Custom
    {
        [Key]
        public int CId { get; set; }//编号
        public string C_Name { get; set; }//名称
        public string C_Cellphone { get; set; }//手机号
        public int C_EndTime { get; set; }//积分
        public float C_integral { get; set; }//金额
        public string C_Phote { get; set; }//头像
        public int C_State { get; set; }//状态  1会员  2游客
    }
}
