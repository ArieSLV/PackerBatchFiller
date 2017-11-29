using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    [Table("Emails")]
    public class Email
    {
        /// <summary>
        /// ID в базе данных адреса электронной почты
        /// </summary>
        public long EmailId { get; set; }
        
        /// <summary>
        /// Текстовое написание адреса электронной почты
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Тип контакта
        /// </summary>
        public ContactType Type { get; set; }

        /// <summary>
        /// Коментарий к адресу электронной почты
        /// </summary>
        public string Comment { get; set; }
    }
}