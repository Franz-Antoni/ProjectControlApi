using System;
using System.Collections.Generic;

namespace ProjectControl.Core.Entities
{
    public partial class UserActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public bool TypeCollaboration { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Activity Activity { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
