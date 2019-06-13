using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace customer_information_api.V1.Infrastructure
{
    [Table("tenagree")]
    public class UhAgreement
    {
        public string TagRef { get; set; }
        [Column("other_accounts")] public bool OtherAccounts { get; set; }
        [Column("spec_terms")] public bool SpecTerms { get; set; }
        [Column("active")] public bool Active { get; set; }
        [Column("present")] public bool Present { get; set; }
        [Column("terminated")] public bool Terminated { get; set; }
        [Column("free_active")] public bool FreeActive { get; set; }
        [Column("nop")] public bool NOP { get; set; }
        [Column("additional_debit")] public bool AdditionalDebit { get; set; }
        [Column("fd_charge")] public bool FdCharge { get; set; }
        [Column("receiptcard")] public bool ReceiptCard { get; set; }
        [Column("nosp")] public bool Nosp { get; set; }
        [Column("ntq")] public bool Ntq { get; set; }
        [Column("eviction")] public bool Eviction { get; set; }
        [Column("committee")] public bool Committee { get; set; }
        [Column("suppossorder")] public bool SuppossOrder { get; set; }
        [Column("possorder")] public bool PossOrder { get; set; }
        [Column("courtapp")] public bool CourtApp { get; set; }
        [Column("open_item")] public bool OpenItem { get; set; }
        [Column("potentialenddate")] public DateTime PotentialEndDate { get; set; }
        [Column("u_payment_expected")] public string UPaymentExpected { get; set; }
        [Column("dtstamp")] public DateTime DtStamp { get; set; }
        [Column("intro_date")] public DateTime IntroDate { get; set; }
        [Column("intro_ext_date")] public DateTime IntroExtDate { get; set; }

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
