using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Podium_Case_Study.Data.Entities;
using Podium_Case_Study.Data.Repositories;
using Podium_Case_Study.Domain;
using Podium_Case_Study.Models;

namespace Podium_Case_Study.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<MortgageProductController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicantProcessor _applicantProcessor;
        private readonly MortgageProcessor _mortgageProcessor;

        public ApplicantController(
            ILogger<MortgageProductController> logger, IMapper mapper, 
            ApplicantProcessor applicantProcessor,
            MortgageProcessor mortgageProcessor)
        {
            _logger = logger;
            _mapper = mapper;
            _applicantProcessor = applicantProcessor;
            _mortgageProcessor = mortgageProcessor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok("hello");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get applicants : {ex}");
                return BadRequest("Failed to get Applicants");
            }
        }
        [HttpGet]
        [Route("{applicantId}")]
        public IActionResult Get(string applicantId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get applicants : {ex}");
                return BadRequest("Failed to get Applicants");
            }
        }

        [HttpPost]
        [Route("FindMortgages")]
        public IActionResult Post([FromBody] MortgageCheckViewModel mortgageCheck)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var validationError = "";
                if (!new ValidationEngine(_applicantProcessor, _mortgageProcessor).IsValidApplication(mortgageCheck,
                    ref validationError))
                {
                    ModelState.AddModelError("", validationError);
                }
                var applicant = _mapper.Map<Applicant>(
                    mortgageCheck.Applicant);
                var saveApplicant = _applicantProcessor.GetOrSaveApplicant(applicant);
                var ltv = _mortgageProcessor.GetLoanToValue(mortgageCheck.DepositAmount, mortgageCheck.PropertyValue);
                var validMortgageProds = _mortgageProcessor.GetValidMortgageProductViewModels(ltv);
                var result = new
                {
                    ApplicantId = saveApplicant.Id.ToString(),
                    ValidMortgageProducts = validMortgageProds
                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save comparisons : {ex}");
                return BadRequest("Failed to get Mortgage comparisons");
            }
        }
    }
}
