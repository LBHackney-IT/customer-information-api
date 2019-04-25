using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;
using Bogus;

namespace customer_information_api.Tests.V1.Helper
{
    public static class CustomerInformationHelper
    {
        public static CustomerInformation CreateCustomerInformation()
        {
            Faker faker = new Faker();
            CustomerInformation customerInformation = new CustomerInformation()
            {
                PersonType = faker.Random.Hash(10),
                Uprn = faker.Random.Int(5),
                ModifiedByUser = faker.Random.Hash(10),
                CorrespondanceName = faker.Random.Hash(20),
                GenderFG = faker.Random.Hash(1),
                LastName = faker.Name.LastName(),
                DateCreated = faker.Date.Past(),
                Forenames = faker.Name.FirstName(),
                ContactNumber = faker.Random.Hash(5),
                CallerNotes = faker.Random.Hash(50),
                ClientId = faker.Random.Int(5),
                ModificationType = faker.Random.Hash(10),
                EmailAddress = faker.Random.AlphaNumeric(20),
                NationalInsuranceNumber = faker.Random.AlphaNumeric(9),
                Title = faker.Random.Hash(2),
                DateModified = faker.Date.Past(),
                StatusFG = faker.Random.Hash(5),
                DateOfBirth = faker.Date.Past(),
                TenRef = faker.Random.Hash(10),
                UhContact = faker.Random.Int(5)
            };
            return customerInformation;
        }
    }
}
