using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecallOnTimeMVC.Models
{
    //部门表
    public class DepartMent
    {
        [Key]
        public int DId { get; set; }//编号
        public string D_Name { get; set; }//部门名称
        public int Num { get; set; }//部门人数
    }
}
