using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repositories
{
    public interface IHrDepartmentRepository : ISynetecRepository<HrDepartment> { }

    public class HrDepartmentRepository : SynetecRepository<HrDepartment>, IHrDepartmentRepository
    {
        public HrDepartmentRepository(MvcInterviewV3Entities1 context) : base(context)
        {
        }
    }
}