﻿using SimpleFixture.Impl;

namespace SimpleFixture.Conventions
{
    public class DoubleConvention : SimpleTypeConvention<double>
    {
        private readonly IRandomDataGeneratorService _dataGenerator;
        private readonly IConstraintHelper _constraintHelper;

        public static double LocateValue = 5;

        public DoubleConvention(IRandomDataGeneratorService dataGenerator, IConstraintHelper constraintHelper)
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
            
            var minMax = _constraintHelper.GetMinMax(request, double.MinValue, double.MaxValue);

            minMax.Min = _constraintHelper.GetValue(request.Constraints, minMax.Min, "min", "minValue");
            minMax.Max = _constraintHelper.GetValue(request.Constraints, minMax.Max, "max", "maxValue");

            if (minMax.Min.CompareTo(minMax.Max) > 0)
            {
                minMax.Min = minMax.Max;
            }

            return _dataGenerator.NextDouble(minMax.Min, minMax.Max);
        }
    }
}
