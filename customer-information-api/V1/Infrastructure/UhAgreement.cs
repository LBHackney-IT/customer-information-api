using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace customer_information_api.V1.Infrastructure
{
    [Table("member")]
    public class UhAgreement
    {
        [Column("tag_ref")] public string TagRef { get; set; }
        [Column("house_ref")] public string HouseRef { get; set; }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UhAgreement) obj);
        }

        protected bool Equals(UhAgreement other)
        {
            return string.Equals(TagRef, other.TagRef) &&
                   string.Equals(HouseRef, other.HouseRef);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (TagRef != null ? TagRef.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HouseRef.GetHashCode();
                return hashCode;
            }
        }
    }
}
