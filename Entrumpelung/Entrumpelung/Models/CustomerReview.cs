using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entrumpelung.Models
{
    public class CustomerReview 
    {
        [Key]
        public int ReviewID { get; set; }

        public int Rating { get; set; }

        public string CustomerName { get; set; }

        public string CustomerCity { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}