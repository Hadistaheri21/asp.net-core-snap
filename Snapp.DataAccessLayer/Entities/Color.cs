using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Snapp.DataAccessLayer.Entities
{
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام رنگ")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "کد رنگ")]
        [MaxLength(20)]
        public string Code { get; set; }

        //ارتباط بین جداول

        public virtual ICollection<Driver> Drivers { get; set; }

    }
}
