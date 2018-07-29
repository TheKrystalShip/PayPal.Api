using Braintree;

using TheKrystalShip.PayPal.Api.Properties;

namespace TheKrystalShip.PayPal.Api
{
    public class PaymentService
    {
        public PaymentService()
        {
            BraintreeGateway gateway = new BraintreeGateway
            {
                Environment = Environment.SANDBOX,
                MerchantId = Settings.Instance["Braintree:MerchantId"],
                PublicKey = Settings.Instance["Braintree:PublicKey"],
                PrivateKey = Settings.Instance["Braintree:PrivateKey"]
            };
        }
    }
}
