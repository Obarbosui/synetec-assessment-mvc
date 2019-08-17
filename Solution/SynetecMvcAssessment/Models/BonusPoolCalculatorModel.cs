using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorModel
    {
        public decimal BonusPoolAmount { get; set; }
        public List<Data.HrEmployee> AllEmployees { get; set; }        
        public int SelectedEmployeeId { get; set; }

    }
}