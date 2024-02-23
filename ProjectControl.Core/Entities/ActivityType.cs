using System;
using System.Collections.Generic;

namespace ProjectControl.Core.Entities
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
