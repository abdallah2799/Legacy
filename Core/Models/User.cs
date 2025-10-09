using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public partial class User
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        // Discriminator Column in DB
        public string Role { get; private set; }

        public string Email { get; set; }

        [NotMapped]
        public string GenderDisplay => Gender.ToString();
        public GenderEnum Gender { get; set; }

        [Range(22, 60)]
        public int Age { get; set; }

        public string Address { get; set; }
        
        public string Phone { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Helper Enum Property
        [NotMapped]
        public UserRoleEnum RoleEnum
        {
            get
            {
                return Enum.TryParse<UserRoleEnum>(Role, true, out var result)
                    ? result
                    : throw new InvalidOperationException($"Invalid User Role: {Role}");
            }
            set
            {
                Role = value.ToString();
            }
        }
        public virtual ICollection<CoursePolicy> CoursePolicies { get; set; } = new List<CoursePolicy>();

        public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    }
   
}
