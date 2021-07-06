using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Podium_Case_Study.Data.Entities;
using Podium_Case_Study.Data.Repositories;

namespace Podium_Case_Study.Domain
{
    public class ApplicantProcessor:IApplicantProcessor
    {
        private readonly IApplicantRepository _repository;

        public ApplicantProcessor(IApplicantRepository repository)
        {
            _repository = repository;
        }

        public Applicant GetOrSaveApplicant(Applicant app)
        {
            var existingApplicant = _repository.GetApplicant(app.FirstName, app.LastName, app.Email, app.Dob);
            if (existingApplicant != null) return existingApplicant;

            var saveApplicant = _repository.SaveApplicant(app);
            return saveApplicant;
        }

        public bool ApplicantIsEighteenOrOver(DateTime dob)
        {
            var ageInDays = DateTime.Now.Subtract(dob).TotalDays;
            var age = ageInDays / 365;
            return age >= 18;
        }
    }
}
