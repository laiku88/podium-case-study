using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Podium_Case_Study.Data.DbContext;
using Podium_Case_Study.Data.Entities;

namespace Podium_Case_Study.Data.Repositories
{
    public class ApplicantRepository:IApplicantRepository
    {
        private readonly MortgageAppContext _ctx;

        public ApplicantRepository(MortgageAppContext ctx)
        {
            _ctx = ctx;
        }
        public Applicant SaveApplicant(Applicant applicant)
        {
            var guid = Guid.NewGuid();
            applicant.Id = guid;
            _ctx.Applicants.Add(applicant);
            var result = _ctx.SaveChanges();
            return result > 0 ? applicant : null;
        }
        public Applicant GetApplicant(string firstName, string lastName, string email, DateTime dob)
        {
            var matching =  _ctx.Applicants.FirstOrDefault(x => x.Dob == dob
                                                       && x.Email.ToLower().Trim()==email.ToLower().Trim()
                                                       && x.FirstName.ToLower().Trim()==firstName.ToLower().Trim()
                                                       && x.LastName.ToLower().Trim() ==lastName.ToLower().Trim());
            return matching;
        }
    }
}
