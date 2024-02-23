using System;
using System.Collections.Generic;

namespace ProjectControl.Core.Entities
{
    public partial class Project
    {
        public Project()
        {
            Activities = new HashSet<Activity>();
            UserProjects = new HashSet<UserProject>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
