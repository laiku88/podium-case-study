using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Podium_Case_Study.Data.Entities;
using Podium_Case_Study.Data.Repositories;
using Podium_Case_Study.Models;

namespace Podium_Case_Study.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MortgageProductController : ControllerBase
    {
        private readonly IMortgageProductRepository _repository;
        private readonly ILogger<MortgageProductController> _logger;
        private readonly IMapper _mapper;

        public MortgageProductController(IMortgageProductRepository repository, 
            ILogger<MortgageProductController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var mortgageProds = _repository.GetMortgageProducts();
                if (mortgageProds.Any())
                {
                    return Ok(
                        _mapper.Map<IEnumerable<MortgageProductViewModel>>(
                            mortgageProds));

                }

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Mortgage products: {ex}");
                return BadRequest("Failed to get Mortgage products");
            }
        }
    }
}
