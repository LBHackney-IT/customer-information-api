using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_information_api.V1.Domain
{
    public class CustomerInformation
    { 
        public string Title { get; set; }
        public string Forenames { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public string CallerNotes { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedByUser { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string ModificationType { get; set; }
        public string PersonType { get; set; }
        public string EmailAddress { get; set; }
        public int Uprn { get; set; }
        public int ClientId { get; set; }
        public string CorrespondanceName { get; set; }
        public string StatusFG { get; set; }
        public string GenderFG { get; set; }
        public int UhContact { get; set; }
        public string TenRef { get; set; }

        public override bool Equals(object obj)
        {
            CustomerInformation customerInformation = obj as CustomerInformation;
            if (customerInformation != null)
            {
                return string.Equals(Title,customerInformation.Title) &&
                       string.Equals(Forenames, customerInformation.Forenames) &&
                       string.Equals(LastName,customerInformation.LastName) &&
                       DateOfBirth.Equals(customerInformation.DateOfBirth) &&
                       string.Equals(ContactNumber,customerInformation.ContactNumber) &&
                       DateCreated.Equals(customerInformation.DateCreated) &&
                       string.Equals(CallerNotes, customerInformation.CallerNotes) &&
                       DateModified.Equals(customerInformation.DateModified) &&
                       string.Equals(ModifiedByUser, customerInformation.ModifiedByUser) &&
                       string.Equals(NationalInsuranceNumber,customerInformation.NationalInsuranceNumber) &&
                       string.Equals(ModificationType, customerInformation.ModificationType) &&
                       string.Equals(PersonType,customerInformation.PersonType) &&
                       string.Equals(EmailAddress,customerInformation.EmailAddress) &&
                       Uprn == customerInformation.Uprn &&
                       ClientId == customerInformation.ClientId &&
                       string.Equals(CorrespondanceName,customerInformation.CorrespondanceName) &&
                       string.Equals(StatusFG,customerInformation.StatusFG) &&
                       string.Equals(GenderFG,customerInformation.GenderFG) &&
                       UhContact == customerInformation.UhContact &&
                       string.Equals(TenRef,customerInformation.TenRef);
            }
            return false;
        }
    }
}


