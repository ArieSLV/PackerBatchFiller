using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{

    /// <summary>
    /// Свидетельство о государственной регистрации
    /// </summary>
    [Table("RegistrationCertificates")]
    public class RegistrationCertificate
    {
        /// <summary>
        /// ID в базе данных у данного Свидетельства о государственной регистрации
        /// </summary>
        public long RegistrationCertificateId { get; set; }

        /// <summary>
        /// Номер Свидетельства о государственной регистрации
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи Свидетельства о государственной регистрации
        /// </summary>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Орган выдачи Свидетельства о государственной регистрации
        /// </summary>
        public RegistrationCertificateIssuer RegistrationCertificateIssuer { get; set; }
    }
}