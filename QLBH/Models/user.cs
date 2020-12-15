using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    [Table ("users")]
    public class user
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string ConfirmPassword { get; set; }
        [Required, MinLength(9), MaxLength(13)]
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public ICollection<order> orders { get; set; }

    }
}