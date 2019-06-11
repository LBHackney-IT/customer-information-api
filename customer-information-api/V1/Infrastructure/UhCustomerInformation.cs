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
        [Key,Column("house_ref")] public string HouseRef { get; set; }



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
                return hashCode;
            }
        }
    }
}
