using AutoMapper;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.PaymentManagement.PaymentManagement
{
    public class PaymentService: IPaymentService
    {
        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        public PaymentService(IMapper mapper, ILotUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(PaymentDTO createPayment)
        {
            Payment newPayment = _mapper.Map<Payment>(createPayment);
            await _unitOfWork.PaymentRepository.Add(newPayment);
            await _unitOfWork.Save();
        }

        public async Task<PaymentDTO> Get(Guid paymentId)
        {
            Payment Payment = await _unitOfWork.PaymentRepository.GetById(paymentId);
            return _mapper.Map<PaymentDTO>(Payment);
        }

        public async Task<IEnumerable<PaymentDTO>> GetAll()
        {
            IEnumerable<Payment> Payments = await _unitOfWork.PaymentRepository.GetAll();
            return _mapper.Map<IEnumerable<PaymentDTO>>(Payments);
        }
    }
}
