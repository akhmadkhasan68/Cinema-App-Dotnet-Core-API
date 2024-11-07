using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Utils.Constans
{
    public class Regex
    {
        public const string Email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"; // Email must be in the correct format

        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,20}$"; // Password must contain at least one uppercase letter, one lowercase letter, and one number

        public const string Name = @"^[a-zA-Z\s]*$"; // Name must contain only letters and spaces
    }
}
