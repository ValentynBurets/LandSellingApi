using AutoMapper;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Business.Services.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.PaymentManagement.PaymentManagement
{
    public class PaymentService: IPaymentService
    {
        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        private PaymentHelper _paymentHelper;
        public PaymentService(IMapper mapper, ILotUnitOfWork unitOfWork, PaymentHelper paymentHelper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _paymentHelper = paymentHelper;
        }

        public async Task Create(PaymentDTO createPayment, Guid userId)
        {
            Payment newPayment = _mapper.Map<Payment>(createPayment);
            newPayment.UserId = userId;

            await _paymentHelper.ProceedTransaction(createPayment.PaymentData);

            await _unitOfWork.PaymentRepository.Add(newPayment);
            await _unitOfWork.Save();
        }

        public async Task<PaymentDTO> GetById(Guid paymentId)
        {
            Payment Payment = await _unitOfWork.PaymentRepository.GetById(paymentId);
            return _mapper.Map<PaymentDTO>(Payment);
        }

        public async Task<IEnumerable<PaymentDTO>> GetAll()
        {
            IEnumerable<Payment> Payments = await _unitOfWork.PaymentRepository.GetAll();
            return _mapper.Map<IEnumerable<PaymentDTO>>(Payments);
        }

        public async Task<string> GetToken(Guid userId)
        {
            return await _paymentHelper.GenerateClientToken(userId); ;
        }
    }
}
