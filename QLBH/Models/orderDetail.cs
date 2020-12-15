using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    [Table ("orderDetails") ]
    public class orderDetail
    {
        [Key]
        public int id { get; set; }
        public int product_id { get; set; }
        [ForeignKey ("product_id")]
        public virtual product product { get; set; }
        public int order_id { get; set; }
        [ForeignKey("order_id")]
        public virtual order order { get; set; }
        public  int price { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
    }
}