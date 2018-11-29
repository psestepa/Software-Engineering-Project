namespace Software_Engineering_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserProfile
    {
        public string newUsername { get; set; }
        [DataType(DataType.Password)]
        public string oldPassword { get; set; }
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

    }
}
