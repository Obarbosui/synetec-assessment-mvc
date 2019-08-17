using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Services;
using InterviewTestTemplatev2.Services.Repostiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Helpers.Controllers
{
    public interface IBonusPoolControllerHelper
    {
        BonusPoolCalculatorModel PrepareBonusPoolCalculatorModel();
        BonusPoolCalculatorResultModel PrepareBonusPoolCalculatorResultModel(int selectedEmployeeId, decimal bonusPoolAmount);
    }
    public class BonusPoolControllerHelper : IBonusPoolControllerHelper
    {
        private readonly IHrEmployeesService hrEmployeesService;
        private readonly IBonusPoolService bonusPoolService;

        public BonusPoolControllerHelper(IHrEmployeesService hrEmployeesService, IBonusPoolService bonusPoolService)
        {
            this.hrEmployeesService = hrEmployeesService;
            this.bonusPoolService = bonusPoolService;
        }

        public BonusPoolCalculatorModel PrepareBonusPoolCalculatorModel()
        {
            var model = new BonusPoolCalculatorModel();
            model.AllEmployees = hrEmployeesService.GetAll();
            return model;
        }

        public BonusPoolCalculatorResultModel PrepareBonusPoolCalculatorResultModel(int selectedEmployeeId, decimal bonusPoolAmount)
        {
            var model = new BonusPoolCalculatorResultModel();

            var hrEmployee = hrEmployeesService.FindById(selectedEmployeeId);
            if (hrEmployee == null)
                return model;

            var hrDepartment = hrEmployee.HrDepartment; //hrDepartmentService.FindById(hrEmployee.HrDepartmentId);
            if (hrDepartment == null)
                return model;

            //get all employees
            var hrEmployees = hrEmployeesService.GetAll();
            //employees filtered by selected employee's hr department
            var hrFilteredEmployees = hrEmployeesService.FilterByDepartment(hrEmployees, hrEmployee.HrDepartmentId);

            //get company salary budget
            int totalSalary = bonusPoolService.CalculateSalaryBudget(hrEmployees);
            //get department salary budget
            int totalSalaryByHrDepartment = bonusPoolService.CalculateSalaryBudget(hrFilteredEmployees);

            var hrEmployeeSalary = hrEmployee.Salary;

            //calculate bonus allocation without HrDepartment allocation
            decimal bonusAllocation = bonusPoolService.CalculateBonusAllocation(hrEmployeeSalary, totalSalary, bonusPoolAmount);
            //calculate bonus allocation considering HrDepartment allocation
            decimal? bonusAllocationByHrDepartment = bonusPoolService.CalculateBonusAllocationByHrDepartment(hrEmployeeSalary, totalSalaryByHrDepartment, bonusPoolAmount, hrDepartment.BonusPoolAllocationPerc);

            model.HrEmployee = hrEmployee;
            model.BonusPoolAllocation = bonusAllocation;
            model.BonusPoolAllocationHrDepartment = bonusAllocationByHrDepartment;
            model.HrDepartmentAllocationPercentage = hrDepartment.BonusPoolAllocationPerc;
            model.EmployeeHrDepartmentName = hrDepartment.Title;

            return model;
        }
    }
}