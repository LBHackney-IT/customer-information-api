using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace customer_information_api.V1.Infrastructure
{
    [Table("member")]
    public class UhCustomerInformation
    {
        [Column("title")] public string Title { get; set; }
        [Column("forename")] public string Forename { get; set; }
        [Column("surname")] public string Surname { get; set; }
        [Column("ni_no")] public string Ni_No { get; set; }
        [Column("dob")] public DateTime? DOB { get; set; }
        [Column("gender")] public string Gender { get; set; }
        [Column("person_no")] public int PersonNo { get; set; }
        [Column("oap")] public bool OAP { get; set; }
        [Key,Column("house_ref")] public string HouseRef { get; set; }
        [Column("at_risk")] public bool AtRisk { get; set; }
        [Column("responsible")] public bool Responsible { get; set; }
        [Column("full_ed")] public bool FullEd { get; set; }
        [Column("member_sid")] public int MemberSid { get; set; }
        [Column("bank_acc_type")] public string BankAccType { get; set; }



        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UhCustomerInformation) obj);
        }

        protected bool Equals(UhCustomerInformation other)
        {
            return string.Equals(Title, other.Title) &&
                   string.Equals(Forename, other.Forename) &&
                   string.Equals(Surname, other.Surname) &&
                   string.Equals(Ni_No, other.Ni_No) &&
                   DOB.Value == other.DOB &&
                   string.Equals(Gender, other.Gender) &&
                   PersonNo == other.PersonNo &&
                   OAP == other.OAP &&
                   AtRisk == other.AtRisk &&
                   Responsible == other.Responsible &&
                   FullEd == other.FullEd &&
                   MemberSid == other.MemberSid &&
                   BankAccType == other.BankAccType &&
                   string.Equals(HouseRef, other.HouseRef);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (HouseRef != null ? HouseRef.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Forename.GetHashCode();
                hashCode = (hashCode * 397) ^ Surname.GetHashCode();
                hashCode = (hashCode * 397) ^ Ni_No.GetHashCode();
                hashCode = (hashCode * 397) ^ DOB.GetHashCode();
                hashCode = (hashCode * 397) ^ Gender.GetHashCode();
                hashCode = (hashCode * 397) ^ OAP.GetHashCode();
                hashCode = (hashCode * 397) ^ AtRisk.GetHashCode();
                hashCode = (hashCode * 397) ^ Responsible.GetHashCode();
                hashCode = (hashCode * 397) ^ FullEd.GetHashCode();
                hashCode = (hashCode * 397) ^ MemberSid.GetHashCode();
                hashCode = (hashCode * 397) ^ BankAccType.GetHashCode();
                hashCode = (hashCode * 397) ^ PersonNo.GetHashCode();
                return hashCode;
            }
        }
    }
}
