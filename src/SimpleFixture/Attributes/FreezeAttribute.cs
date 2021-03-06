﻿using System;

namespace SimpleFixture.Attributes
{
    public class FreezeAttribute : Attribute
    {
        public virtual object Min { get; set; }

        public virtual object Max { get; set; }

        public virtual string ConstraintName { get; set; }

        public virtual Type For { get; set; }

        public virtual object Value { get; set; }
    }
}
