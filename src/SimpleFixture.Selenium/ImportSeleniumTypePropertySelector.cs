﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleFixture.Impl;

namespace SimpleFixture.Selenium
{
    public class ImportSeleniumTypePropertySelector : SeleniumTypePropertySelector
    {
        public ImportSeleniumTypePropertySelector(IConstraintHelper helper)
            : base(helper)
        {

        }

        public override IEnumerable<PropertyInfo> SelectProperties(object instance, DataRequest request, ComplexModel model)
        {
            return base.SelectProperties(instance, request, model).Where(p => p.GetCustomAttributes(true).Any(o => o.GetType() == typeof(ImportAttribute)));
        }
    }
}
