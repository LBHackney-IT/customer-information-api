using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.Tests.V1.Helper;
using customer_information_api.V1.Domain;
using NUnit.Framework;

namespace customer_information_api.Tests.V1.Domain
{
    [TestFixture]
    public class CustomerInformationDomainTests
    {
        [Test]
        public void customer_information_domain_has_title()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.Title);
        }
        [Test]
        public void customer_information_domain_has_forenames()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.Forenames); 
        }

        [Test]
        public void customer_information_has_last_name()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.LastName);
        }
        [Test]
        public void customer_information_has_date_of_birth()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            DateTime dob = new DateTime(2019, 02, 21);
            customerInformation.DateOfBirth = dob;
            Assert.AreEqual(dob, customerInformation.DateOfBirth);
        }

        [Test]
        public void customer_information_has_date_created()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            DateTime dateCreated = new DateTime(2019, 02, 21);
            customerInformation.DateCreated = dateCreated;
            Assert.AreEqual(dateCreated,customerInformation.DateCreated);
        }
        [Test]
        public void customer_information_has_caller_notes()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.CallerNotes);
        }
        [Test]
        public void customer_information_has_date_modified()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            DateTime date = new DateTime(2019, 02, 21);
            customerInformation.DateModified = date;
            Assert.AreEqual(date,customerInformation.DateModified);
        }
        [Test]
        public void customer_information_modified_by_user()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.ModifiedByUser);
        }
        [Test]
        public void customer_information_has_national_insurance_number()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.NationalInsuranceNumber);
        }
        [Test]
        public void customer_information_has_modification_type()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.ModificationType);
        }
        [Test]
        public void customer_information_has_person_type()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.PersonType);
        }
        [Test]
        public void customer_information_has_email_address()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.EmailAddress);
        }
        [Test]
        public void customer_information_has_uprn()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.Uprn);
        }
        [Test]
        public void customer_information_has_client_id()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.ClientId);
        }
        [Test]
        public void customer_information_has_correspondance_name()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.CorrespondanceName);
        }
        [Test]
        public void customer_information_has_status_fg()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.StatusFG);
        }
        [Test]
        public void customer_information_has_gender_fg()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.GenderFG);
        }
        [Test]
        public void customer_information_has_uh_contact()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.UhContact);
        }
        [Test]
        public void customer_information_has_ten_ref()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.TenRef);
        }

        [Test]
        public void CustomerInformationCanBeCompared()
        {
            CustomerInformation customerInformationA = CustomerInformationHelper.CreateCustomerInformation();

            CustomerInformation customerInformationB = new CustomerInformation()
            {
                CallerNotes = customerInformationA.CallerNotes,
                ClientId = customerInformationA.ClientId,
                ContactNumber = customerInformationA.ContactNumber,
                CorrespondanceName = customerInformationA.CorrespondanceName,
                DateCreated = customerInformationA.DateCreated,
                DateModified = customerInformationA.DateModified,
                DateOfBirth = customerInformationA.DateOfBirth,
                EmailAddress = customerInformationA.EmailAddress,
                Forenames = customerInformationA.Forenames,
                GenderFG = customerInformationA.GenderFG,
                LastName = customerInformationA.LastName,
                ModificationType = customerInformationA.ModificationType,
                ModifiedByUser = customerInformationA.ModifiedByUser,
                NationalInsuranceNumber = customerInformationA.NationalInsuranceNumber,
                PersonType = customerInformationA.PersonType,
                StatusFG = customerInformationA.StatusFG,
                TenRef = customerInformationA.TenRef,
                Title = customerInformationA.Title,
                UhContact = customerInformationA.UhContact,
                Uprn = customerInformationA.Uprn
            };

            Assert.True(customerInformationA.Equals(customerInformationB));
        }
    }
}
