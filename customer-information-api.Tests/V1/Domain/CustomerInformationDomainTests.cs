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
        public void Customer_information_has_contactId()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.contactId);
        }
        [Test]
        public void Customer_information_domain_has_title()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.title);
        }
        [Test]
        public void Customer_information_domain_has_forenames()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.forenames); 
        }
        [Test]
        public void Customer_information_has_surname()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.surname);
        }
        [Test]
        public void Customer_information_has_dateCreated()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            DateTime dateCreated = new DateTime(2019, 02, 21);
            customerInformation.dateCreated = dateCreated;
            Assert.AreEqual(dateCreated, customerInformation.dateCreated);
        }
        [Test]
        public void Customer_information_has_callerNotes()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.callerNotes);
        }
        [Test]
        public void Customer_information_has_dateModified()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            DateTime date = new DateTime(2019, 02, 21);
            customerInformation.dateModified = date;
            Assert.AreEqual(date,customerInformation.dateModified);
        }
        [Test]
        public void Customer_information_modifiedBy()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.modifiedBy);
        }
        [Test]
        public void Customer_information_has_nationalInsuranceNumber()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.nationalInsuranceNumber);
        }
        [Test]
        public void Customer_information_has_dateOfBirth()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            DateTime dob = new DateTime(2019, 02, 21);
            customerInformation.dateOfBirth = dob;
            Assert.AreEqual(dob, customerInformation.dateOfBirth);
        }
        [Test]
        public void Customer_information_has_modificationType()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.modificationType);
        }
        [Test]
        public void Customer_information_has_personType()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.personType);
        }
        [Test]
        public void Customer_information_has_emailAddress()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.emailAddress);
        }
        [Test]
        public void Customer_information_has_modificationProcess()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.modificationProcess);
        }
        [Test]
        public void Customer_information_has_uprn()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.uprn);
        }
        [Test]
        public void Customer_information_has_clientId()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.clientId);
        }
        [Test]
        public void Customer_information_has_correspondanceName()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.correspondanceName);
        }
        [Test]
        public void Customer_information_has_isRecordActive()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.isRecordActive);
        }
        [Test]
        public void Customer_information_has_gender()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.gender);
        }
        [Test]
        public void Customer_information_has_uhContact()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.Zero(customerInformation.uhContact);
        }
        [Test]
        public void Customer_information_has_tenancyRef()
        {
            CustomerInformation customerInformation = new CustomerInformation();
            Assert.IsNull(customerInformation.tenancyRef);
        }

        [Test]
        public void CustomerInformationCanBeCompared()
        {
            CustomerInformation customerInformationA = CustomerInformationHelper.CreateCustomerInformation();

            CustomerInformation customerInformationB = new CustomerInformation()
            {
                contactId = customerInformationA.contactId,
                title = customerInformationA.title,
                forenames = customerInformationA.forenames,
                surname = customerInformationA.surname,
                dateCreated = customerInformationA.dateCreated,
                callerNotes = customerInformationA.callerNotes,
                dateModified = customerInformationA.dateModified,
                modifiedBy = customerInformationA.modifiedBy,
                nationalInsuranceNumber = customerInformationA.nationalInsuranceNumber,
                dateOfBirth = customerInformationA.dateOfBirth,
                modificationType = customerInformationA.modificationType,
                personType = customerInformationA.personType,
                emailAddress = customerInformationA.emailAddress,
                modificationProcess = customerInformationA.modificationProcess,
                uprn = customerInformationA.uprn,
                clientId = customerInformationA.clientId,
                correspondanceName = customerInformationA.correspondanceName,
                isRecordActive = customerInformationA.isRecordActive,
                gender = customerInformationA.gender,
                uhContact = customerInformationA.uhContact,
                tenancyRef = customerInformationA.tenancyRef
            };

            Assert.True(customerInformationA.Equals(customerInformationB));
        }
    }
}
