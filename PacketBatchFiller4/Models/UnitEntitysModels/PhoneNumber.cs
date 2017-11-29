using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Телефонный номер
    /// </summary>
    [Table("PhoneNumbers")]
    public class PhoneNumber
    {
        /// <summary>
        /// ID в базе данных телефонного номера
        /// </summary>
        public long PhoneNumberId { get; set; }
        
        /// <summary>
        /// Текстовое написание телефонного номера
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Тип контакта
        /// </summary>
        public ContactType Type { get; set; }

        /// <summary>
        /// Коментарий к телефонному номеру 
        /// </summary>
        public string Comment { get; set; }
    }
}