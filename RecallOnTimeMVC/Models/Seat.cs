using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecallOnTimeMVC.Models
{
    //座位表
    public class Seat
    {
        [Key]
        public int SeId { get; set; }//编号
        public string Number { get; set; }//座位号
        [ForeignKey("MovieHall")]
        public int MovieHallId { get; set; }//放映厅表外键

        public MovieHall MovieHall { get; set; }
    }
}
