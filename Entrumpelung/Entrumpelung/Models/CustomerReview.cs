using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entrumpelung.Models
{
    [Serializable]
    public class CustomerReview 
    {
        public int ReviewID { get; set; }

        public int Rating { get; set; }

        public string CustomerName { get; set; }

        public string CustomerCity { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; }

        public override bool Equals(object obj)
        {
            return this.ReviewText.Equals(((CustomerReview)obj).ReviewText);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}