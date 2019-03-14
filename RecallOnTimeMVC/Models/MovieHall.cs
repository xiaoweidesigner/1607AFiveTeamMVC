using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecallOnTimeMVC.Models
{
    //放映厅表
     public class MovieHall
    {
        [Key]
        public int HId { get; set; }//编号
        public string H_Name { get; set; }//影厅名称
        public string H_Photo { get; set; }//影厅照片
        public int H_State { get; set; }//状态
    }
}
