using System;
using Core.Models;
using Common.Enums;

namespace UI.Infrastructure
{
    public class SessionManager
    {
        private static SessionManager? _instance;
        private static readonly object _lock = new object();

        private User? _currentUser;
        private Student? _currentStudent;
        private Instructor? _currentInstructor;
        private Admin? _currentAdmin;

        private SessionManager()
        {
        }

        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SessionManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Login(User user)
        {
            _currentUser = user;

            // Cast to specific role type based on user role
            switch (user.RoleEnum)
            {
                case Common.Enums.UserRoleEnum.Student:
                    _currentStudent = user as Student;
                    break;
                case Common.Enums.UserRoleEnum.Instructor:
                    _currentInstructor = user as Instructor;
                    break;
                case Common.Enums.UserRoleEnum.Admin:
                    _currentAdmin = user as Admin;
                    break;
            }
        }

        public void Logout()
        {
            _currentUser = null;
            _currentStudent = null;
            _currentInstructor = null;
            _currentAdmin = null;
        }

        public bool IsAuthenticated()
        {
            return _currentUser != null;
        }

        public bool HasRole(Common.Enums.UserRoleEnum role)
        {
            return _currentUser?.RoleEnum == role;
        }

        public User? GetCurrentUser()
        {
            return _currentUser;
        }

        public Student? GetCurrentStudent()
        {
            return _currentStudent;
        }

        public Instructor? GetCurrentInstructor()
        {
            return _currentInstructor;
        }

        public Admin? GetCurrentAdmin()
        {
            return _currentAdmin;
        }

        // Convenience properties
        public int? UserId => _currentUser?.UserId;
        public string? UserName => _currentUser?.Username;
        public string? Email => _currentUser?.Email;
        public Common.Enums.UserRoleEnum? Role => _currentUser?.RoleEnum;
        public int? TrackId => _currentStudent?.TrackId;
        public int? BranchId => _currentStudent?.BranchId ?? _currentInstructor?.BranchId;

        // Role-specific properties
        public int? StudentId => _currentStudent?.UserId;
        public int? InstructorId => _currentInstructor?.UserId;
        public int? AdminId => _currentAdmin?.UserId;

        // Helper methods for role checking
        public bool IsStudent() => HasRole(Common.Enums.UserRoleEnum.Student);
        public bool IsInstructor() => HasRole(Common.Enums.UserRoleEnum.Instructor);
        public bool IsAdmin() => HasRole(Common.Enums.UserRoleEnum.Admin);
        public bool IsBranchManager() => IsAdmin() && BranchId.HasValue;
    }
}
