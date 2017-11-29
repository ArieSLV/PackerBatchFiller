using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    public enum SecuritiesTypes
    {
        /// <summary>
        /// Акция обыкновенная именная
        /// </summary>
        [StringValue("Акция обыкновенная именная")]
        SimpleShare,

        /// <summary>
        /// Акция привилегированная именная типа А
        /// </summary>
        [StringValue("Акция привилегированная именная типа А")]
        PreferredTypaAShare,

        /// <summary>
        /// Акция привилегированная именная
        /// </summary>
        [StringValue("Акция привилегированная именная")]
        PreferredShare,

        Unknown
    }

    /// <summary>
    /// Выпуск ценных бумаг
    /// </summary>
    [Table("IssuesOfSecurities")]
    public class IssueOfSecurities
    {
        /// <summary>
        /// ID выпуска ценных бумаг
        /// </summary>
        public long IssueOfSecuritiesId { get; set; }

        /// <summary>
        /// Тип ценных бумаг
        /// </summary>
        public SecuritiesTypes Type { get; set; }

        /// <summary>
        /// Номер выпуска ценных бумаг
        /// </summary>
        public string Number { get; set; }
    }
}