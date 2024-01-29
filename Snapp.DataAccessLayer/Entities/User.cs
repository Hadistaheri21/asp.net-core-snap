using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "انتخاب نقش")]
        public Guid RoleId { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(11)]
        [Required]
        public string Username { get; set; }

        [Display(Name = "کد ورود")]
        [MaxLength(100)]
        public String Password { get; set; }

        [Display(Name = "توکن")]
        public String Token { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "کیف پول")]
        public long wallet { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public virtual UserDetail UserDetail { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual ICollection<Factor> Factors { get; set; }

        public virtual ICollection<UserAddresse> UserAddresses { get; set; }

        public virtual ICollection<Transact> Transacts { get; set; }
    }
}
