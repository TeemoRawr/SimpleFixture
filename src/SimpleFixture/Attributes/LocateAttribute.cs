﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFixture.Attributes
{
    public class LocateAttribute : Attribute
    {
        public virtual object Value { get; set; }
    }
}
