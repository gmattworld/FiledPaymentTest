using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FiledPaymentTest.Core.Entities;
using FiledPaymentTest.Core.Enums;
using FiledPaymentTest.Core.Models;
using FiledPaymentTest.Core.Models.ModelExt;
using FiledPaymentTest.Core.Validators;
using FiledPaymentTest.Repository;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiledPaymentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPaymentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Brand management constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public ProcessPaymentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentProcessExtModel>>> GetAsync()
        {
            List<PaymentProcessExtModel> _DTO = null;

            try
            {
                IEnumerable<PaymentProcess> _payments = await _unitOfWork.PaymentProcesses.GetAllAsync();
                _DTO = _mapper.Map<List<PaymentProcessExtModel>>(_payments);

                return Ok(_DTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        // POST: api/PaymentProcesses
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentProcess"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PaymentProcessExtModel>> PostPaymentProcess(PaymentProcessModel paymentProcess)
        {
            try
            {

                // Request validation
                PaymentProcessValidator _validator = new PaymentProcessValidator();
                ValidationResult result = _validator.Validate(paymentProcess);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                PaymentProcess _paymentProcess = _mapper.Map<PaymentProcess>(paymentProcess);
                _paymentProcess.Id = Guid.NewGuid().ToString();
                _paymentProcess.Status = PaymentStatus.PENDING;
                _paymentProcess.Tries = 0;

                _ = _unitOfWork.PaymentProcesses.InsertAsync(_paymentProcess);

                await _unitOfWork.CompleteAsync();

                return Ok(_paymentProcess);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
