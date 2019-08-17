using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repositories
{
    public interface IHrEmployeesRepository : ISynetecRepository<HrEmployee>
    {

    }
    public class HrEmployeesRepository : SynetecRepository<HrEmployee>, IHrEmployeesRepository
    {
        public HrEmployeesRepository(MvcInterviewV3Entities1 context):base(context)
        {

        }

    }
}