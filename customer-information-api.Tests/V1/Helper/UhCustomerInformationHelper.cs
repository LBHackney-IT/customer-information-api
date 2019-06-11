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
            UhCustomerInformation.Title = _faker.Random.AlphaNumeric(length:3);
            UhCustomerInformation.Forename = _faker.Random.AlphaNumeric(length: 12);
            UhCustomerInformation.Surname = _faker.Random.AlphaNumeric(length: 9);
            UhCustomerInformation.Ni_No = _faker.Random.AlphaNumeric(length: 9);
            UhCustomerInformation.DOB = _faker.Date.Past();
            UhCustomerInformation.Gender = _faker.Random.AlphaNumeric(length: 9);
            UhCustomerInformation.HouseRef = _faker.Random.AlphaNumeric(length: 9);

            return UhCustomerInformation;
        }

        private static UhCustomerInformation CopyCustomerInformationFields(CustomerInformation customerInformation)
        {
            return new UhCustomerInformation
            {
                Title = customerInformation.title,
                Forename = customerInformation.forenames,
                Surname = customerInformation.surname,
                Ni_No = customerInformation.nationalInsuranceNumber,
                DOB = customerInformation.dateOfBirth,
                Gender = customerInformation.gender,
                HouseRef = null
            };
        }
    }
}
