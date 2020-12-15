using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    [Table ("categories") ]
    public class category
    {
        [Key]
        public int id { get; set; }
        [Required, MaxLength(30)]
        public string name { get; set; }
        public string content { get; set; }
        public DateTime created_at { get; set; }
        public ICollection<product> products { get; set; }
    }
}