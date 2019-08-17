using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Services.Repostiories
{
    public interface IHrDepartmentService : ISynetecService<HrDepartment>
    {

    }
    public class HrDepartmentService : SynetecService<HrDepartment>, IHrDepartmentService
    {
        public HrDepartmentService(IHrDepartmentRepository hrDepartmentRepository) : base(hrDepartmentRepository)
        {
        }
    }
}