using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Podium_Case_Study.Data.Entities;

namespace Podium_Case_Study.Domain
{
    public interface IApplicantProcessor
    {
        Applicant GetOrSaveApplicant(Applicant app);
        bool ApplicantIsEighteenOrOver(DateTime dob);
    }

}
