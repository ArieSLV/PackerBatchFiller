using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Орган выдачи Свидетельства о государственной регистрации юридического лица
    /// </summary>
    [Table("RegistrationCertificateIssuers")]
    public class RegistrationCertificateIssuer
    {
        /// <summary>
        /// ID в базе данных органа выдачи Свидетельства о государственной регистрации юридического лица
        /// </summary>
        public long RegistrationCertificateIssuerId { get; set; }

        /// <summary>
        /// Имя органа выдачи Свидетельства о государственной регистрации юридического лица
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// Явное указание на текстовое представление органа выдачи Свидетельства о государственной регистрации юридического лица
        /// </summary>
        /// <returns>Орган выдачи Свидетельства о государственной регистрации юридического лица</returns>
        public override string ToString() => Value;

        
        public override bool Equals(object obj)
        {
            if (!(obj is RegistrationCertificateIssuer item)) return false;
            return Value == item.Value && RegistrationCertificateIssuerId == item.RegistrationCertificateIssuerId;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}