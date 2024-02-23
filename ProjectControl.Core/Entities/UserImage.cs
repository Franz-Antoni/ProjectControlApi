using System;
using System.Collections.Generic;

namespace ProjectControl.Core.Entities
{
    public partial class UserImage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
