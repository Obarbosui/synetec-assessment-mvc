using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Services
{
    public interface IBonusPoolService
    {
        int CalculateSalaryBudget(IEnumerable<HrEmployee> hrEmployees);
        decimal CalculateBonusAllocation(int employeeSalary, int totalSalary, decimal totalBonusPool);
        decimal? CalculateBonusAllocationByHrDepartment(int employeeSalary, int totalSalaryByDepartment, decimal totalBonusPool, int? bonusPoolAllocationPerc);
    }
    public class BonusPoolService : IBonusPoolService
    {
        public BonusPoolService()
        {
        }

        public int CalculateSalaryBudget(IEnumerable<HrEmployee> hrEmployees)
        {
            if (hrEmployees == null)
                return 0;
            //get the total salary budget for the company
            return hrEmployees.Sum(employee => employee.Salary);
        }
        public decimal CalculateBonusAllocation(int employeeSalary, int totalSalary, decimal totalBonusPool)
        {
            //avoid throwing unhandled exception. cant divide by 0
            if (totalSalary == 0)
                return 0m;
            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;
            decimal bonusAllocation = bonusPercentage * totalBonusPool;
            return Math.Round(bonusAllocation, 2);
        }
        public decimal? CalculateBonusAllocationByHrDepartment(int employeeSalary, int totalSalaryByDepartment, decimal totalBonusPool, int? bonusPoolAllocationPerc)
        {
            if (!bonusPoolAllocationPerc.HasValue)
                return null;
            
            //calculate department pool by extracting hrdepartment percentage from total pool
            var bonusPoolByHrDepartment = totalBonusPool * bonusPoolAllocationPerc.Value / 100;
                
            return CalculateBonusAllocation(employeeSalary, totalSalaryByDepartment, bonusPoolByHrDepartment);
        }
    }
}