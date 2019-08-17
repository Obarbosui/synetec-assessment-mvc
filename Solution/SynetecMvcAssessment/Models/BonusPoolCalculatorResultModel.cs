using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorResultModel
    {
        public Data.HrEmployee HrEmployee { get; set; }
        public decimal BonusPoolAllocation { get; set; }
        public decimal? BonusPoolAllocationHrDepartment { get; set; }
        public string EmployeeHrDepartmentName { get; set; }
        public int? HrDepartmentAllocationPercentage { get; set; }

    }
}