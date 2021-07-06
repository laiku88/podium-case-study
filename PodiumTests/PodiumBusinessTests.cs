using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Podium_Case_Study.Data.Repositories;
using Podium_Case_Study.Domain;
using Podium_Case_Study.Models;

namespace PodiumTests
{
    [TestClass]
    public class PodiumBusinessTests
    {
        private  IMortgageProcessor _mortgageProcessor;
        private  IApplicantProcessor _applicantProcessor;
        private  ValidationEngine _validationEngine;


        [TestInitialize]
        public void Initialize()
        {
            var mockApplicantRepo = new Mock<IApplicantRepository>().Object;
            var mockMortgageProdRepo = new Mock<IMortgageProductRepository>().Object;
            var mockMapper = new Mock<IMapper>().Object;
            _applicantProcessor = new ApplicantProcessor(mockApplicantRepo);
            _mortgageProcessor = new MortgageProcessor(mockMortgageProdRepo,mockMapper );
            _validationEngine = new ValidationEngine(_applicantProcessor, _mortgageProcessor);
        }

        [TestMethod]
        public void GetLoanToValueReturnsCorrectResult()
        {
            double propertyAmount = 100000;
            double deposit = 10000;

            var ltv = _mortgageProcessor.GetLoanToValue(deposit, propertyAmount);
            Assert.IsTrue(ltv == 90.0);
        }
        [TestMethod]
        public void ApplicantIsEighteenOrOverCheckIsTrueWhenApplicantDobIs010174()
        {
            var dob = Convert.ToDateTime("1974-01-01");
            var ltv = _applicantProcessor.ApplicantIsEighteenOrOver(dob);
            Assert.IsTrue(ltv);

        }
        [TestMethod]
        public void ApplicantIsEighteenOrOverCheckIsFalseWhenApplicantDobIs01012020()
        {
            var dob = Convert.ToDateTime("2020-01-01");
            var ltv = _applicantProcessor.ApplicantIsEighteenOrOver(dob);
            Assert.IsFalse(ltv);
        }
        [TestMethod]
        public void ValidationEngineReturnsFalseWhenLtVisLessThan90()
        {
            var vm = new MortgageCheckViewModel
            {
                DepositAmount = 100000000,
                PropertyValue = 1000000,
                Applicant = new ApplicantViewModel
                {
                    FirstName = "Lisa",
                    LastName = "Chan",
                    DateOfBirth = Convert.ToDateTime("1988-01-01"),
                }
            };
            var validationError = "";
            var isValid = _validationEngine.IsValidApplication(vm, ref validationError);
            Assert.IsFalse(isValid,$"validationError is: {validationError}");
        }
        [TestMethod]
        public void ValidationEngineReturnsFalseWhenUnderAge()
        {
            var vm = new MortgageCheckViewModel
            {
                DepositAmount = 10000,
                PropertyValue = 1000000,
                Applicant = new ApplicantViewModel
                {
                    FirstName = "Lisa",
                    LastName = "Chan",
                    DateOfBirth = Convert.ToDateTime("2021-01-01"),
                }
            };
            var validationError = "";
            var isValid = _validationEngine.IsValidApplication(vm, ref validationError);
            Assert.IsFalse(isValid,$"validationError is: {validationError}");
        }
    }
}
