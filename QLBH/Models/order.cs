using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    [Table ("orders")]
    public class order
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual user user { get; set; }
        public string status { get; set; }
        public string node { get; set; }
        public int total { get; set; }
        public DateTime created_at { get; set; }
        public ICollection<orderDetail> orderDetails { get; set; }
    }
}