using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.DTOs
{
    public class MacroDTO
    {
        public double CarbohydratesAte { get; set; }
        public double FatAte { get; set; }
        public double ProteinAte { get; set; }
        public double CaloriesAte { get; set; }
        public double CarbohydratesDemand { get; set; }
        public double FatDemand { get; set; }
        public double ProteinDemand { get; set; }
        public double CaloriesDemand { get; set; }
        public double CaloriesRatio => Math.Round(CaloriesAte /CaloriesDemand*100);
        public double CarbohydratesRatio => Math.Round(CarbohydratesAte /CarbohydratesDemand*100);
        public double FatRatio => Math.Round(FatAte /FatDemand*100);
        public double ProteinRatio => Math.Round(ProteinAte /ProteinDemand*100);
    }
}
