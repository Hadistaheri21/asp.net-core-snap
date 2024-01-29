using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Snapp.DataAccessLayer.Entities
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [MaxLength(10)]
        public string Date { get; set; }

        [Display(Name = "ساعت عضویت")]
        [MaxLength(10)]
        public string Time { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(10)]
        public string BirthDate { get; set; }

        public virtual User User { get; set; }
    }
}
