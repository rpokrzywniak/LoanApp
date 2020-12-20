using LoanApp.DTOs;
using LoanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<AmortizationMethodDTO> EnumNameValues<T>() where T : Enum
        {
            var result = new List<AmortizationMethodDTO>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
            {
                result.Add(new AmortizationMethodDTO { Key = Enum.GetName(typeof(T), item), Value = item });
            }
            return result;
        }
    }
}
