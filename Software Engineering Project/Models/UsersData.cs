namespace Software_Engineering_Project.Models
{
    using System;
    using System.Collections.Generic;

    public class UsersData
    {
        public string Username  { get; set; }
        public string Role_Name { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return this.Username;
        }
    }
}
