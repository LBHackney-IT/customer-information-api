using Bogus;
using customer_information_api.V1.Infrastructure;

namespace customer_information_api.Tests.V1.Helper
{
    public class UhAgreementHelper
    {
        public static UhAgreement CreateUhAgreement()
        {
            Faker _faker = new Faker();

            UhAgreement uhAgreement = new UhAgreement()
            {
                HouseRef = _faker.Random.AlphaNumeric(8),
                TagRef = _faker.Random.AlphaNumeric(10),
                Active = _faker.Random.Bool(),
                AdditionalDebit = _faker.Random.Bool(),
                Committee = _faker.Random.Bool(),
                CourtApp = _faker.Random.Bool(),
                DtStamp = _faker.Date.Past(),
                Eviction = _faker.Random.Bool(),
                FdCharge = _faker.Random.Bool(),
                FreeActive = _faker.Random.Bool(),
                OtherAccounts = _faker.Random.Bool(),
                Terminated = _faker.Random.Bool(),
                IntroDate = _faker.Date.Past(),
                ReceiptCard = _faker.Random.Bool(),
                IntroExtDate = _faker.Date.Past(),
                PotentialEndDate = _faker.Date.Soon(),
                UPaymentExpected = _faker.Random.AlphaNumeric(3)
            };

            return uhAgreement;
        }
    }
}
