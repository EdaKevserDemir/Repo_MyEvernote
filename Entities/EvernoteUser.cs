using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("EvernoteUsers")]
    public class EvernoteUser : MyEntityBase
    {
        [StringLength(25)]
        public string Name { get; set; }

        [Required,StringLength(25)]
        public string Surname { get; set; }

        [Required, StringLength(25)]
        public string Username { get; set; }

        [Required, StringLength(70)]
        public string Email { get; set; }

        [Required, StringLength(25)]
        public string Password { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsAdmin { get; set; }

        public virtual List<Note> Notes { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual  List<Liked> Likes{ get; set; }


    }
}
