﻿using SimpleFixture.Impl;

namespace SimpleFixture.Conventions
{
    public class ShortConvention : SimpleTypeConvention<short>
    {
        private readonly IConstraintHelper _constraintHelper;
        private readonly IRandomDataGeneratorService _dataGenerator;

        public static short LocateValue = 5;

		public ShortConvention(IRandomDataGeneratorService dataGenerator, IConstraintHelper constraintHelper)
        {
            _dataGenerator = dataGenerator;
            _constraintHelper = constraintHelper;
        }

        public override object GenerateData(DataRequest request)
        {
            if (!request.Populate)
            {
                return LocateValue;
            }

            var minMax = _constraintHelper.GetMinMax(request, short.MinValue, short.MaxValue);

            minMax.Min = _constraintHelper.GetValue(request.Constraints, minMax.Min, "min", "minValue");
            minMax.Max = _constraintHelper.GetValue(request.Constraints, minMax.Max, "max", "maxValue");

            if (minMax.Min.CompareTo(minMax.Max) > 0)
            {
                minMax.Min = minMax.Max;
            }

            return _dataGenerator.NextShort(minMax.Min, minMax.Max);
        }
    }
}
