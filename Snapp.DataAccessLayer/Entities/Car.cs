using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Snapp.DataAccessLayer.Entities
{
   public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
         [Display(Name = "نام خودرو")]
         [Required]
         [MaxLength(100)]
        public string Name { get; set; }

        //ارتباط بین جداول
        public virtual ICollection<Driver> Drivers { get; set; }

    }
}
