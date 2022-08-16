using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Order
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PkgName { get; set; }
        public string pkgDescription { get; set; }
        public double price { get; set; }
        public string regNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public string pinCode { get; set; }

        public string instructions { get; set; }

        public string date { get; set; }

        public string Status { get; set; }

        public string userEmail { get; set; }




    }
}
