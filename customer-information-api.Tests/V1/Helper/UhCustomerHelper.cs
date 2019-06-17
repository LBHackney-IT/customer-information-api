using Bogus;
using customer_information_api.Tests.V1.Helper;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Infrastructure;

namespace customer_information_api.Tests.V1.Helper
{
    public static class UhCustomerHelper
    {
        public static UhCustomer CreateUhCustomer()
        {
            Faker _faker = new Faker();

            UhCustomer uhCustomer = new UhCustomer()
            {
                HouseRef = _faker.Random.AlphaNumeric(10),
                Title = _faker.Random.Hash(2),
                Forename = _faker.Random.AlphaNumeric(24),
                Surname = _faker.Random.AlphaNumeric(20),
                Ni_No = _faker.Random.AlphaNumeric(9),
                DOB = _faker.Date.Past(),
                Gender = _faker.Random.Hash(1),

                PersonNo = _faker.Random.Int(1, 80),
                OAP = _faker.Random.Bool(),
                AtRisk = _faker.Random.Bool(),
                Responsible = _faker.Random.Bool(),
                FullEd = _faker.Random.Bool(),
                MemberSid = _faker.Random.Int(),
                BankAccType = _faker.Random.AlphaNumeric(3)
            };

            return uhCustomer;
        }
    }
}
