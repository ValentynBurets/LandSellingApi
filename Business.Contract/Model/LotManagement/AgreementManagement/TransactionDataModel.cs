using System;

namespace Business.Contract.Model.LotManagement.AgreementManagement
{
    public class TransactionDataModel
    {
        public double RentPrice { get; set; }
        public string Nonce { get ; set; }
        public string DeviceData { get; set; }
        public Guid UserId { get; set; }

    }
}