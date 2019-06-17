using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;
using Bogus;

namespace customer_information_api.Tests.V1.Helper
{
    public static class CustomerHelper
    {
        public static Customer CreateCustomer()
        {
            Faker faker = new Faker();
            Customer customer = new Customer()
            {
                contactId = faker.Random.Int(5),
                title = faker.Random.Hash(2),
                forenames = faker.Random.AlphaNumeric(24),
                surname = faker.Random.AlphaNumeric(20),
                dateCreated = faker.Date.Past(),
                callerNotes = faker.Random.Hash(50),
                dateModified = faker.Date.Past(),
                modifiedBy = faker.Random.Hash(10),
                nationalInsuranceNumber = faker.Random.AlphaNumeric(9),
                dateOfBirth = faker.Date.Past(),
                modificationType = faker.Random.Hash(10),
                personType = faker.Random.Hash(10),
                emailAddress = faker.Random.AlphaNumeric(20),
                modificationProcess = faker.Random.Int(40),
                uprn = faker.Random.Int(5),
                clientId = faker.Random.Int(5),
                correspondanceName = faker.Random.Hash(20),
                isRecordActive = faker.Random.Hash(5),
                gender = faker.Random.Hash(1),
                uhContact = faker.Random.Int(5),
                tenancyRef = faker.Random.Hash(10)
            };
            return customer;
        }
    }
}
