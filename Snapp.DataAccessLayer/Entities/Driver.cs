using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Snapp.DataAccessLayer.Entities
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

      //  guid?=یک جی یو آیدی نال پذیر
        public Guid? CarId { get; set; }

        public Guid? ColorId { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(10)]
        public string NationalCode { get; set; }

        [Display(Name = "شماره ثابت")]
        [MaxLength(30)]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "شماره پلاک")]
        [MaxLength(30)]
        public string CarCode { get; set; }

        [Display(Name = "تصویر گواهینامه")]
        public string Img { get; set; }

        [Display(Name = "تصویر راننده")]

        public string Avatar { get; set; }

        [Display(Name = "تایید")]
        public bool IsConfirm { get; set; }


       // ارتباط بین جداول
        public virtual User User { get; set; }

        [ForeignKey("CarId")]

        public virtual Car Car { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }
}
