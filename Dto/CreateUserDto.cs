﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
    }
}
