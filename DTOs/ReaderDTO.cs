﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReaderDTO
    {
        public int ReaderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gmail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
