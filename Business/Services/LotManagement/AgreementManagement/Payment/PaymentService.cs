using AutoMapper;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Payment;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Business.Contract.Services.LotManagement.AgreementManagement.Payment;
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
        private IPaymentHelper _paymentHelper;
        public PaymentService(IMapper mapper, ILotUnitOfWork unitOfWork, IPaymentHelper paymentHelper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _paymentHelper = paymentHelper;
        }

        public async Task Create(CreatePaymentDTO createPayment, Guid userIdLink)
        {
            Payment newPayment = _mapper.Map<Payment>(createPayment);
            var userId = (await _unitOfWork.UserRepository.GetByIdLink(userIdLink)).Id;
            newPayment.UserId = userId;
            newPayment.Date = DateTime.Now;
            newPayment.Value = createPayment.Price;

            TransactionDataModel transactionDataModel = new TransactionDataModel()
            {
                RentPrice = createPayment.Price,
                Nonce = createPayment.Nonce,
                DeviceData = "",
                UserId = userId
            };

            var res = await _paymentHelper.ProceedTransaction(transactionDataModel);

            if (res)
            {
                await _unitOfWork.PaymentRepository.Add(newPayment);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("payment is denied");
            }
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

        public async Task<string> GetToken(Guid userIdLink)
        {
            var userId = (await _unitOfWork.UserRepository.GetByIdLink(userIdLink)).Id;
            return await _paymentHelper.GenerateClientToken(userId); ;
        }

        public async Task<IEnumerable<PaymentDTO>> GetByAgreementId(Guid agreementId)
        {
            IEnumerable<Payment> payments = await _unitOfWork.PaymentRepository.GetByAgreementId(agreementId);
            return _mapper.Map<IEnumerable<PaymentDTO>>(payments);
        }
    }
}
