using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthCircleApp.Models
{
    internal static class GeometricCalculation
    {
        public static double? GetCircumference(double? radius)
        {
            if (radius.HasValue)
            {
                return Math.Round(2 * Math.PI * (double)radius, 2, MidpointRounding.AwayFromZero);
            }
            return null;
        }
    }
}
