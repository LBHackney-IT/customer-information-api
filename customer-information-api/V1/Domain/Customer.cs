using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_information_api.V1.Domain
{
    public class Customer
    {
#pragma warning disable IDE1006 // Naming Styles
        public string houseRef { get; set; }
        public int contactId { get; set; }
        public string title { get; set; }
        public string forenames { get; set; }
        public string surname { get; set; }
        public DateTime dateCreated { get; set; }
        public string callerNotes { get; set; }
        public DateTime dateModified { get; set; }
        public string modifiedBy { get; set; }
        public string nationalInsuranceNumber { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string modificationType { get; set; }
        public string personType { get; set; }
        public string emailAddress { get; set; }
        public int modificationProcess { get; set; }
        public int uprn { get; set; }
        public int clientId { get; set; }
        public string correspondanceName { get; set; }
        public string isRecordActive { get; set; }
        public string gender { get; set; }
        public int uhContact { get; set; }
        public string tenancyRef { get; set; }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer != null)
            {
                return string.Equals(houseRef, customer.houseRef) &&
                       string.Equals(contactId, customer.contactId) &&
                       string.Equals(title, customer.title) &&
                       string.Equals(forenames, customer.forenames) &&
                       string.Equals(surname, customer.surname) &&
                       dateCreated.Equals(customer.dateCreated) &&
                       string.Equals(callerNotes, customer.callerNotes) &&
                       dateModified.Equals(customer.dateModified) &&
                       string.Equals(modifiedBy, customer.modifiedBy) &&
                       string.Equals(nationalInsuranceNumber, customer.nationalInsuranceNumber) &&
                       dateOfBirth.Equals(customer.dateOfBirth) &&
                       string.Equals(modificationType, customer.modificationType) &&
                       string.Equals(personType, customer.personType) &&
                       string.Equals(emailAddress, customer.emailAddress) &&
                       string.Equals(modificationProcess, customer.modificationProcess) &&
                       uprn == customer.uprn &&
                       clientId == customer.clientId &&
                       string.Equals(correspondanceName, customer.correspondanceName) &&
                       string.Equals(isRecordActive, customer.isRecordActive) &&
                       string.Equals(gender, customer.gender) &&
                       uhContact == customer.uhContact &&
                       string.Equals(tenancyRef, customer.tenancyRef);
            }
            return false;
        }
        #pragma warning restore IDE1006 // Naming Styles
    }
}


