using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    [Table ("products") ]
    public class product
    {
        [Key]
        public int id { get; set; }
        [Required, MaxLength(50)]
        public string name { get; set; }
        public int category_id { get; set; }
        [ForeignKey("category_id")]
        public virtual category category { get; set; }
        
        public string image { get; set; }
        public int unitPrice { get; set; }
        public DateTime created_at { get; set; }
        public ICollection<orderDetail> orderDetails { get; set; }
    }
}