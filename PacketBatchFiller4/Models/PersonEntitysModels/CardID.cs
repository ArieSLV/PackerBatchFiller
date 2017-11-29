using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Документ, удостоверяющий личность физического лица
    /// </summary>
    [Table("CardID")]
    public class CardID
    {
        /// <summary>
        /// ID в базе данных у документа, удостоверяющего личность физического лица
        /// </summary>
        public long CardIDId { get; set; }

        /// <summary>
        /// Тип документа, удостоверяющего личность физического лица
        /// </summary>
        public CardIDType CardIDType { get; set; }

        /// <summary>
        /// Серия документа, удостоверяющего личность физического лица
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Номер документа, удостоверяющего личность физического лица
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи документа, удостоверяющего личность физического лица
        /// </summary>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Орган выдачи документа, удостоверяющего личность физического лица
        /// </summary>
        public CardIDIssuer CardIDIssuer { get; set; }
    }
}