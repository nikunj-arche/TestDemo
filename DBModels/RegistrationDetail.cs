using System;
using System.Collections.Generic;

namespace TestProject.DBModels
{
    public partial class RegistrationDetail
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? FullName { get; set; }
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
