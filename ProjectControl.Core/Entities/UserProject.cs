using System;
using System.Collections.Generic;

namespace ProjectControl.Core.Entities
{
    public partial class UserProject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
