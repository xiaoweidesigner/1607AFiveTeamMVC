using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecallOnTimeMVC.Models
{
    //员工
    public class Employee
    {
        [Key]
        public int EId { get; set; }//编号
        public string E_Name { get; set; }//姓名
        [ForeignKey("DepartMent")]
        public int DepartMentId { get; set; }//部门外键
        public string E_Account { get; set; }//账号
        public string E_Pwd { get; set; }//密码
        public string E_Img { get; set; }//头像
        public string E_Sex { get; set; }//性别
        public string E_Phone { get; set; }//手机
        public int E_State { get; set; }//状态 1工作中 2空闲中

        public DepartMent DepartMent { get; set; }
        public int DId { get; set; }//编号
        public string D_Name { get; set; }//部门名称
    }
}
