using System;
using System.Collections.Generic;

namespace ProjectControl.Core.Entities
{
    public partial class User
    {
        public User()
        {
            UserActivities = new HashSet<UserActivity>();
            UserImages = new HashSet<UserImage>();
            UserProfiles = new HashSet<UserProfile>();
            UserProjects = new HashSet<UserProject>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<UserActivity> UserActivities { get; set; }
        public virtual ICollection<UserImage> UserImages { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
