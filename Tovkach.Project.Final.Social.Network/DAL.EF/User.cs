namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Messages1 = new HashSet<Message>();
            Posts = new HashSet<Post>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Message> Messages1 { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual Role Role { get; set; }
    }
}
