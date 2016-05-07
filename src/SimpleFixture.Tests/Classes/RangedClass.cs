﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFixture.Tests.Classes
{
    public class RangedClass
    {
        [Range(100, 200)]
        public int IntValue { get; set; }

        [StringLength(100, MinimumLength = 50)]
        public string TestString { get; set; }
    }
}
