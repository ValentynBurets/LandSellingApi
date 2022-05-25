using Braintree;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace Business.Services.LotManagement.AgreementManagement
{
    public class PaymentHelper
    {
        private BraintreeGateway _gateway;
        private readonly ILotUnitOfWork _unitOfWork;

        public PaymentHelper(BraintreeGateway gateway, ILotUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _gateway = gateway;
        }

        public async Task<string> GenerateClientToken(Guid userId)
        {

            string customerId = await _unitOfWork.UserRepository.GetUserCustomerIdAsync(userId);
            var tokenRequest = new ClientTokenRequest();
            if (customerId != null)
                tokenRequest.CustomerId = customerId;
            var clientToken = _gateway.ClientToken.Generate(tokenRequest);

            return clientToken;
        }

        public async Task<bool> ProceedTransaction(TransactionDataModel data)
        {
            //var gateway = new BraintreeGateway
            //{
            //    Environment = Braintree.Environment.SANDBOX,
            //    MerchantId = "the_merchant_id",
            //    PublicKey = "a_public_key",
            //    PrivateKey = "a_private_key"
            //};
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(data.RentPrice),
                CurrencyIsoCode = "UAH",
                PaymentMethodNonce = data.Nonce,
                DeviceData = data.DeviceData,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = await _gateway.Transaction.SaleAsync(request);
            if (result.IsSuccess())
            {
                if (result.Transaction != null)
                {
                    if (result.Transaction.Status == TransactionStatus.SETTLED ||
                        result.Transaction.Status == TransactionStatus.SUBMITTED_FOR_SETTLEMENT)
                    {
                        string? customerId = await _unitOfWork.UserRepository.GetUserCustomerIdAsync(data.UserId);
                        if (customerId == null)
                        {
                            var newId = result.Transaction.CustomerDetails.Id;
                            if (newId != null)
                            {
                                var user = await _unitOfWork.UserRepository.GetById(data.UserId);
                                user.CustomerId = newId;
                                await _unitOfWork.UserRepository.Update(user);
                                await _unitOfWork.Save();
                            }
                        }

                        return true;
                    }
                    else
                    {
                        throw new Exception(result.Transaction.ProcessorSettlementResponseText);
                    }
                }
                else
                {
                    if (result.Target != null)
                    {
                        if (result.Target.Status == TransactionStatus.SUBMITTED_FOR_SETTLEMENT)
                        {
                            string? customerId = await _unitOfWork.UserRepository.GetUserCustomerIdAsync(data.UserId);
                            if (customerId == null)
                            {
                                var newId = result.Target.CustomerDetails.Id;
                                if (newId != null)
                                {
                                    var user = await _unitOfWork.UserRepository.GetById(data.UserId);
                                    user.CustomerId = newId;
                                    await _unitOfWork.UserRepository.Update(user);
                                    await _unitOfWork.Save();
                                }
                            }

                            return true;
                        }
                        else
                        {
                            throw new Exception(result.Target.ProcessorSettlementResponseText);
                        }
                    }
                }
            }
            else if (result.Errors.DeepCount > 0)
            {
                foreach (ValidationError error in result.Errors.DeepAll())
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
            {
                Console.WriteLine(result.Transaction.ProcessorSettlementResponseCode);
                Console.WriteLine(result.Transaction.ProcessorSettlementResponseText);
            }

            throw new Exception(result.Message);
        }
    }
}
