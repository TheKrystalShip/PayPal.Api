using Braintree;
using TheKrystalShip.PayPal.Api.Properties;

namespace TheKrystalShip.PayPal.Api
{
    public class PaymentService
    {
        BraintreeGateway Gateway;

        public PaymentService()
        {
            Gateway = new BraintreeGateway
            {
                Environment = Environment.SANDBOX,
                MerchantId = Settings.Instance["Braintree:MerchantId"],
                PublicKey = Settings.Instance["Braintree:PublicKey"],
                PrivateKey = Settings.Instance["Braintree:PrivateKey"]
            };
        }

        public string GetGateway()
        {
            var clientToken = Gateway.ClientToken.Generate();
            return clientToken;
        }

        public string CreatePayment(decimal Amount, string PaymentMethodNonce)
        {
            var request = new TransactionRequest
            {
                Amount = Amount,
                PaymentMethodNonce = PaymentMethodNonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = Gateway.Transaction.Sale(request);
            if (result.IsSuccess())
            {
                Transaction transaction = result.Target;
                return transaction.Id;
            }
            else if (result.Transaction != null)
            {
                return result.Transaction.Id;
            }
            else
            {
                string errorMessages = "";
                foreach (ValidationError error in result.Errors.DeepAll())
                {
                    errorMessages += "Error: " + (int)error.Code + " - " + error.Message + "\n";
                }
                return errorMessages;
            }
        }
    }
}
