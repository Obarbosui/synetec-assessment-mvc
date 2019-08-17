using FluentAssertions;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecMvcAssessmentTest.Services
{
    [TestClass]
    public class BonusPoolServiceTest
    {
        #region CalculateSalaryBudget
        [TestMethod]
        public void Test_CalculateSalaryBudget_ListHrEmployees_ShouldReturnTotal()
        {
            var employee1 = new HrEmployee {Salary = 50000 };
            var employee2 = new HrEmployee { Salary = 60000 };
            var employee3 = new HrEmployee { Salary = 70000 };
            var employees = new List<HrEmployee> { employee1, employee2, employee3 };

            var result = TestCalculateSalaryBudget(employees);
            result.Should().Be(180000);
        }
        [TestMethod]
        public void Test_CalculateSalaryBudget_NoHrEmployees_ReturnZero()
        {
            var employees = new List<HrEmployee>();

            var result = TestCalculateSalaryBudget(employees);
            result.Should().Be(0);
        }
        [TestMethod]
        public void Test_CalculateSalaryBudget_NullList_ReturnZero()
        {
            var result = TestCalculateSalaryBudget(null);
            result.Should().Be(0);
        }
        #endregion

        #region CalculateBonusAllocation
        [TestMethod]
        public void Test_CalculateBonusAllocation_15PercentTotal_ReturnResult()
        {
            //employee with 15% of total salary budget 
            var employeeSalary = 15000;
            var totalSalary = 100000;
            var bonusPool = 123456m;

            var result = TestCalculateBonusAllocation(employeeSalary, totalSalary, bonusPool);
            result.Should().Be(18518.40m);
        }
        [TestMethod]
        public void Test_CalculateBonusAllocation_0Pool_Return0()
        {
            //employee with 15% of total salary budget 
            var employeeSalary = 15000;
            var totalSalary = 100000;
            var bonusPool = 0m;

            var result = TestCalculateBonusAllocation(employeeSalary, totalSalary, bonusPool);
            result.Should().Be(0m);
        }
        [TestMethod]
        public void Test_CalculateBonusAllocation_0TotalSalary_Return0()
        {
            //employee with 15% of total salary budget 
            var employeeSalary = 15000;
            var totalSalary = 0;
            var bonusPool = 0m;

            var result = TestCalculateBonusAllocation(employeeSalary, totalSalary, bonusPool);
            result.Should().Be(0m);
        }
        #endregion

        #region CalculateBonusAllocationByHrDepartment
        [TestMethod]
        public void Test_CalculateBonusAllocationByHrDepartment_15Percent_OfHrDepartmentSalary_()
        {
            //employee with 15% of department salary budget 
            var employeeSalary = 15000;
            var totalSalaryDepartment = 100000;
            //30% of 411520 is 123456(same as per pdf intructions)
            var bonusPool = 411520m;
            var bonusPoolDepartmentAllocation = 30;

            var result = TestCalculateBonusAllocationByHrDepartment(employeeSalary, totalSalaryDepartment, bonusPool, bonusPoolDepartmentAllocation);
            result.Should().Be(18518.40m); //same result
        }

        [TestMethod]
        public void Test_CalculateBonusAllocationByHrDepartment_NoHrDepartmentAllocation_Return0()
        {
            var employeeSalary = 15000;
            var totalSalaryDepartment = 100000;
            var bonusPool = 123456m;
            int? bonusPoolDepartmentAllocation = null;

            var result = TestCalculateBonusAllocationByHrDepartment(employeeSalary, totalSalaryDepartment, bonusPool, bonusPoolDepartmentAllocation);
            result.Should().BeNull(); 
        }
        [TestMethod]
        public void Test_CalculateBonusAllocationByHrDepartment_HrDepartmentAllocation0_Return0()
        {
            var employeeSalary = 15000;
            var totalSalaryDepartment = 100000;
            var bonusPool = 123456m;
            var bonusPoolDepartmentAllocation = 0;

            var result = TestCalculateBonusAllocationByHrDepartment(employeeSalary, totalSalaryDepartment, bonusPool, bonusPoolDepartmentAllocation);
            result.Should().Be(0m);
        }
        #endregion

        #region private
        private int TestCalculateSalaryBudget(IEnumerable<HrEmployee> hrEmployees)
        {
            var mocker = new AutoMocker();

            var subject = mocker.CreateInstance<BonusPoolService>();
            var result = subject.CalculateSalaryBudget(hrEmployees);
            mocker.VerifyAll();
            return result;
        }
        private decimal TestCalculateBonusAllocation(int employeeSalary, int totalSalary, decimal totalBonusPool)
        {
            var mocker = new AutoMocker();

            var subject = mocker.CreateInstance<BonusPoolService>();
            var result = subject.CalculateBonusAllocation(employeeSalary, totalSalary, totalBonusPool);
            mocker.VerifyAll();
            return result;
        }
        private decimal? TestCalculateBonusAllocationByHrDepartment(int employeeSalary, int totalSalaryByDepartment, decimal totalBonusPool, int? bonusPoolAllocationPerc)
        {
            var mocker = new AutoMocker();

            var subject = mocker.CreateInstance<BonusPoolService>();
            var result = subject.CalculateBonusAllocationByHrDepartment(employeeSalary, totalSalaryByDepartment, totalBonusPool, bonusPoolAllocationPerc);
            mocker.VerifyAll();
            return result;
        }
        #endregion
    }
}
