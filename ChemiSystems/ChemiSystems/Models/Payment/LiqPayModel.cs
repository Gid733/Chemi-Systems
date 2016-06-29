using System.ComponentModel.DataAnnotations;

namespace ChemiSystems.Models.Payment
{
    public class LiqPayModel
    {

        public string ApiUrl { get; set; }
        public string CheckpointUrl { get; set; }
        public string Currency { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public int Version { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string OrderId { get; set; }
        public string Recurringbytoken { get; set; }
        public string ServerUrl { get; set; }

        public LiqPayModel()
        {
            ApiUrl = "https://www.liqpay.com/api/";
            CheckpointUrl = "https://www.liqpay.com/api/3/checkout";
            Currency = "UAH";
            Version = 3;
            @Action = "pay";
            PublicKey = "i50329699087";
            PrivateKey = "2ccfWnjsJg1mHcZyNhflQ2vrxhd35VAzv1vf2rvy";
        }
    }
}