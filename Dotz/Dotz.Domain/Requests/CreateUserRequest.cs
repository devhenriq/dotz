﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
