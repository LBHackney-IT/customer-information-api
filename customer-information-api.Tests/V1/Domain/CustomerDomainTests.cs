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
    public class CustomerDomainTests
    {
        [Test]
        public void Customer_has_contactId()
        {
            Customer customer = new Customer();
            Assert.Zero(customer.contactId);
        }
        [Test]
        public void Customer_domain_has_title()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.title);
        }
        [Test]
        public void Customer_domain_has_forenames()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.forenames); 
        }
        [Test]
        public void Customer_has_surname()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.surname);
        }
        [Test]
        public void Customer_has_dateCreated()
        {
            Customer customer = new Customer();
            DateTime dateCreated = new DateTime(2019, 02, 21);
            customer.dateCreated = dateCreated;
            Assert.AreEqual(dateCreated, customer.dateCreated);
        }
        [Test]
        public void Customer_has_callerNotes()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.callerNotes);
        }
        [Test]
        public void Customer_has_dateModified()
        {
            Customer customer = new Customer();
            DateTime date = new DateTime(2019, 02, 21);
            customer.dateModified = date;
            Assert.AreEqual(date,customer.dateModified);
        }
        [Test]
        public void Customer_modifiedBy()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.modifiedBy);
        }
        [Test]
        public void Customer_has_nationalInsuranceNumber()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.nationalInsuranceNumber);
        }
        [Test]
        public void Customer_has_dateOfBirth()
        {
            Customer customer = new Customer();
            DateTime dob = new DateTime(2019, 02, 21);
            customer.dateOfBirth = dob;
            Assert.AreEqual(dob, customer.dateOfBirth);
        }
        [Test]
        public void Customer_has_modificationType()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.modificationType);
        }
        [Test]
        public void Customer_has_personType()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.personType);
        }
        [Test]
        public void Customer_has_emailAddress()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.emailAddress);
        }
        [Test]
        public void Customer_has_modificationProcess()
        {
            Customer customer = new Customer();
            Assert.Zero(customer.modificationProcess);
        }
        [Test]
        public void Customer_has_uprn()
        {
            Customer customer = new Customer();
            Assert.Zero(customer.uprn);
        }
        [Test]
        public void Customer_has_clientId()
        {
            Customer customer = new Customer();
            Assert.Zero(customer.clientId);
        }
        [Test]
        public void Customer_has_correspondanceName()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.correspondanceName);
        }
        [Test]
        public void Customer_has_isRecordActive()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.isRecordActive);
        }
        [Test]
        public void Customer_has_gender()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.gender);
        }
        [Test]
        public void Customer_has_uhContact()
        {
            Customer customer = new Customer();
            Assert.Zero(customer.uhContact);
        }
        [Test]
        public void Customer_has_tenancyRef()
        {
            Customer customer = new Customer();
            Assert.IsNull(customer.tenancyRef);
        }

        [Test]
        public void CustomersCanBeCompared()
        {
            Customer customerA = CustomerHelper.CreateCustomer();

            Customer customerB = new Customer()
            {
                contactId = customerA.contactId,
                title = customerA.title,
                forenames = customerA.forenames,
                surname = customerA.surname,
                dateCreated = customerA.dateCreated,
                callerNotes = customerA.callerNotes,
                dateModified = customerA.dateModified,
                modifiedBy = customerA.modifiedBy,
                nationalInsuranceNumber = customerA.nationalInsuranceNumber,
                dateOfBirth = customerA.dateOfBirth,
                modificationType = customerA.modificationType,
                personType = customerA.personType,
                emailAddress = customerA.emailAddress,
                modificationProcess = customerA.modificationProcess,
                uprn = customerA.uprn,
                clientId = customerA.clientId,
                correspondanceName = customerA.correspondanceName,
                isRecordActive = customerA.isRecordActive,
                gender = customerA.gender,
                uhContact = customerA.uhContact,
                tenancyRef = customerA.tenancyRef
            };

            Assert.True(customerA.Equals(customerB));
        }
    }
}
