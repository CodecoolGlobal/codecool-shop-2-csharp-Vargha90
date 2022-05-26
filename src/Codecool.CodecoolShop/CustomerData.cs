namespace Codecool.CodecoolShop
{
    public class CustomerData
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string BillingCountry { get; private set; }
        public string BillingCity { get; private set; }
        public string BillingZip { get; private set; }
        public string BillingAddress { get; private set; }
        public string ShippingCountry { get; private set; }
        public string ShippingCity { get; private set; }
        public string ShippingZip { get; private set; }
        public string ShippingAddress { get; private set; }

        public CustomerData(string name, string email, string phone,
            string billingCountry, string billingCity, string billingZip, string billingAddress,
            string shippingCountry, string shippingCity, string shippingZip, string shippingAddress)
        {
            Name = name;
            Email = email;
            Phone = phone;
            BillingCountry = billingCountry;
            BillingCity = billingCity;
            BillingZip = billingZip;
            BillingAddress = billingAddress;
            ShippingCountry = shippingCountry;
            ShippingCity = shippingCity;
            ShippingZip = shippingZip;
            ShippingAddress = shippingAddress;
        }
    }
}
