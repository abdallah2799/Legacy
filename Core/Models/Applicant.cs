using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class Applicant
    {
        public int Id { get; set; }
        public List<int> SelectedBranches { get; set; }
        public List<int> SelectedTracks { get; set; }
        public int? AcceptedBranchId { get; set; }
        public int? AcceptedTrackId { get; set; }
        public string FullName { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }

        [NotMapped]
        public string GenderDisplay => Gender.ToString();
        public int Age { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }
        public string ApplicationCode { get; set; }
        public ApplicationStatus Status { get; set; }
        public string ApplicationPasswordHash { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool ToBeDeleted { get; set; } = false;
    }
}
