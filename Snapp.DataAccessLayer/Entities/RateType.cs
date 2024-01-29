using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entities
{
    public class RateType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Guid Id { get; set; }

        [Display(Name = "گزینه امتیاز")]
        [MaxLength(40)]
        public string Name { get; set; }

        //ترو بود مثبت نبود منفی
        [Display(Name = "مثبت")]
        public bool Ok { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int ViewOrder { get; set; }

        public virtual ICollection<TransactRate> TransactRates { get; set; }

    }
}
