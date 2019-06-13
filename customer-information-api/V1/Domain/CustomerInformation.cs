using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_information_api.V1.Domain
{
    public class CustomerInformation
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
            CustomerInformation customerInformation = obj as CustomerInformation;
            if (customerInformation != null)
            {
                return string.Equals(houseRef, customerInformation.houseRef) &&
                       string.Equals(contactId, customerInformation.contactId) &&
                       string.Equals(title, customerInformation.title) &&
                       string.Equals(forenames, customerInformation.forenames) &&
                       string.Equals(surname, customerInformation.surname) &&
                       dateCreated.Equals(customerInformation.dateCreated) &&
                       string.Equals(callerNotes, customerInformation.callerNotes) &&
                       dateModified.Equals(customerInformation.dateModified) &&
                       string.Equals(modifiedBy, customerInformation.modifiedBy) &&
                       string.Equals(nationalInsuranceNumber, customerInformation.nationalInsuranceNumber) &&
                       dateOfBirth.Equals(customerInformation.dateOfBirth) &&
                       string.Equals(modificationType, customerInformation.modificationType) &&
                       string.Equals(personType, customerInformation.personType) &&
                       string.Equals(emailAddress, customerInformation.emailAddress) &&
                       string.Equals(modificationProcess, customerInformation.modificationProcess) &&
                       uprn == customerInformation.uprn &&
                       clientId == customerInformation.clientId &&
                       string.Equals(correspondanceName, customerInformation.correspondanceName) &&
                       string.Equals(isRecordActive, customerInformation.isRecordActive) &&
                       string.Equals(gender, customerInformation.gender) &&
                       uhContact == customerInformation.uhContact &&
                       string.Equals(tenancyRef, customerInformation.tenancyRef);
            }
            return false;
        }
        #pragma warning restore IDE1006 // Naming Styles
    }
}


