using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entities
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Display(Name = "نقش سیستمی")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Display(Name = "نقش")]
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
