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

            UhCustomerInformation.PersonNo = 1;
            UhCustomerInformation.HouseRef = _faker.Random.AlphaNumeric(10);
            UhCustomerInformation.OAP = _faker.Random.Bool();
            UhCustomerInformation.AtRisk = _faker.Random.Bool();
            UhCustomerInformation.Responsible = _faker.Random.Bool();
            UhCustomerInformation.FullEd = _faker.Random.Bool();
            UhCustomerInformation.MemberSid = _faker.Random.Int();
            UhCustomerInformation.BankAccType = _faker.Random.AlphaNumeric(3);
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
                Gender = customerInformation.gender
            };
        }
    }
}
