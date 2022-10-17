namespace CHESSGAME.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManageUser")]
    public partial class ManageUser
    {
        [Key]
        [StringLength(30)]
        public string Username { get; set; }

        [StringLength(10)]
        public string Password { get; set; }
    }
}
