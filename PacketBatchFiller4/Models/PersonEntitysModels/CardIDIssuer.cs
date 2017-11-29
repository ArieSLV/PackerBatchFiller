using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{

    /// <summary>
    /// Орган выдачи документа, удостоверяющего личность физического лица
    /// </summary>
    [Table("CardIDIssuers")]
    public class CardIDIssuer
    {
        /// <summary>
        /// ID в базе данных органа выдачи документа, удостоверяющего личность физического лица
        /// </summary>
        public long CardIDIssuerId { get; set; }

        /// <summary>
        /// Имя органа выдачи документа, удостоверяющего личность физического лица
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код подразделения органа выдачи документа, удостоверяющего личность физического лица
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Явное указание на текстовое представление органа выдачи документа, удостоверяющего личность физического лица
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.IsNullOrEmpty(Code) ? Name : $"{Name}, {Code}";
    }
}