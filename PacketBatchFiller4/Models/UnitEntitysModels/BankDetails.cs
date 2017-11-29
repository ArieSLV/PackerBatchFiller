using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Банковские реквизиты лицевого счета
    /// </summary>
    [Table("BankDetails")]
    public class BankDetails
    {
        /// <summary>
        /// ID в базе данных Банковских реквизитов лицевого счета
        /// </summary>
        public long BankDetailsId { get; set; }

        /// <summary>
        /// Лицевой счет лица
        /// </summary>
        public string PersonalAccount { get; set; }

        /// <summary>
        /// Наименование отделения
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// Счет получателя платежа
        /// </summary>
        public string MainAccount { get; set; }

        /// <summary>
        /// Корреспондентский счет
        /// </summary>
        public string CorrAccount { get; set; }

        /// <summary>
        /// Наименование банка
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Банковский идентификационный код
        /// </summary>
        public string BIK { get; set; }

        /// <summary>
        /// Город банка
        /// </summary>
        public string BankCity { get; set; }
    }
}