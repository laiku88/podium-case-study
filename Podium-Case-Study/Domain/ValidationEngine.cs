using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Podium_Case_Study.Models;

namespace Podium_Case_Study.Domain
{
    public class ValidationEngine
    {
        private readonly IApplicantProcessor _applicantProcessor;
        private readonly IMortgageProcessor _mortgageprocessor;

        public ValidationEngine(IApplicantProcessor applicantProcessor, IMortgageProcessor mortgageProcessor)
        {
            _applicantProcessor = applicantProcessor;
            _mortgageprocessor = mortgageProcessor;
        }

        public bool IsValidApplication(MortgageCheckViewModel vm, ref string validationError)
        {
            validationError = null;
            if (!_applicantProcessor.ApplicantIsEighteenOrOver(vm.Applicant.DateOfBirth))
            {
                validationError = "Applicant is underage";
                return false;
            }
            if (!_mortgageprocessor.DepositIsLessThanPropertyValue(vm.DepositAmount, vm.PropertyValue))
            {
                validationError = "Deposit is more than property value";
                return false;
            }
            if (!(_mortgageprocessor.GetLoanToValue(vm.DepositAmount, vm.PropertyValue) > 90)) return true;
            validationError = "LTV is not less than 90%";
            return false;

        }
    }
}
