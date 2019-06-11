using Bogus;
using customer_information_api.Tests.V1.Helper;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Infrastructure;

namespace customer_information_api.Tests.V1.Helper
{
    public static class UhCustomerInformationHelper
    {
        public static UhCustomerInformation CreateUhCustomerInformation()
        {
            return CreateUhCustomerInformationFrom(CustomerInformationHelper.CreateCustomerInformation());
        }

        public static UhCustomerInformation CreateUhCustomerInformationFrom(CustomerInformation customerInformation)
        {
            Faker _faker = new Faker();
            UhCustomerInformation UhCustomerInformation = CopyCustomerInformationFields(customerInformation);
            UhCustomerInformation.Id = _faker.Random.Int();
            UhCustomerInformation.PropRef = _faker.Random.AlphaNumeric(length: 12);
            UhCustomerInformation.TagRef = _faker.Random.AlphaNumeric(length: 9);
            UhCustomerInformation.transno = _faker.Random.Int();
            UhCustomerInformation.line_no = _faker.Random.Int();
            UhCustomerInformation.adjustment = _faker.Random.Bool();
            UhCustomerInformation.apportion = _faker.Random.Bool();
            UhCustomerInformation.prop_deb = _faker.Random.Bool();
            UhCustomerInformation.none_rent = _faker.Random.Bool();
            UhCustomerInformation.receipted = _faker.Random.Bool();
            UhCustomerInformation.vat = _faker.Random.Bool();

            return UhCustomerInformation;
        }

//        private static UhCustomerInformation CopyTransactionFields(Transaction transaction)
//        {
//            return new UhCustomerInformation
//            {
//                Amount = transaction.Amount,
//                Code = transaction.Code,
//                Date = transaction.Date,
//                Comments = transaction.Comments,
//                FinancialYear = transaction.FinancialYear,
//                PeriodNumber = transaction.PeriodNumber,
//            };
//        }
    }
}
