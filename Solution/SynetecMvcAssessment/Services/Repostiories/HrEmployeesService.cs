using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Services.Repostiories
{
    public interface IHrEmployeesService : ISynetecService<HrEmployee>
    {
        IEnumerable<HrEmployee> FilterByDepartment(IEnumerable<HrEmployee> hrEmployees, int departmentId);
    }
    public class HrEmployeesService : SynetecService<HrEmployee>, IHrEmployeesService
    {
        public HrEmployeesService(IHrEmployeesRepository hrEmployeesRepository) : base(hrEmployeesRepository)
        {

        }
        public IEnumerable<HrEmployee> FilterByDepartment(IEnumerable<HrEmployee> hrEmployees, int departmentId)
        {
            return hrEmployees.Where(employee => employee.HrDepartmentId == departmentId);
        }

    }
}