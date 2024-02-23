using System;
using System.Collections.Generic;

namespace ProjectControl.Core.Entities
{
    public partial class Activity
    {
        public Activity()
        {
            UserActivities = new HashSet<UserActivity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int ActivityTypeId { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public int ActivityStatusTypeId { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ActivityStatusType ActivityStatusType { get; set; } = null!;
        public virtual ActivityType ActivityType { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public virtual ICollection<UserActivity> UserActivities { get; set; }
    }
}
