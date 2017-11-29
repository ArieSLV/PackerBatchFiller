using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Способ получения дивидентов
    /// </summary>
    public enum DividentsPaymentWays
    {
        /// <summary>
        /// Получение диведендов почтовым переводом
        /// </summary>
        ByMail,

        /// <summary>
        /// Получение диведендов банковским переводом
        /// </summary>
        ByBank
    }
    
    /// <summary>
    /// Лицо
    /// </summary>
    [Table("Units")]
    public class Unit
    {
        /// <summary>
        /// ID в базе данных лица
        /// </summary>
        public long UnitId { get; set; }

        /// <summary>
        /// Способ получения дивидендов
        /// </summary>
        public DividentsPaymentWays DividentsPaymentWay { get; set; }

        /// <summary>
        /// Документы для проведения операций могут представляться почтовым отправлением в случаях, 
        /// предусмотренных Правилами ведения реестра Регистратора 
        /// </summary>
        public bool OnlyPersonalPresenceFlag { get; set; }

        /// <summary>
        /// Индивидуальный номер налогоплатильщика
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// Указание на то, что почтовый адрес совпадает с адресом места регистрации
        /// </summary>
        public bool MailingAddressEqualRegistrationAddressFlag { get; set; }

        /// <summary>
        /// Гражданство\страна регистрации
        /// </summary>
        public Citizenship Citizenship { get; set; }

        /// <summary>
        /// Адрес регистрации\юридический адрес
        /// </summary>
        public Address AddressRegistration { get; set; }

        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public Address MailingAddress { get; set; }

        /// <summary>
        /// Телефонный номера
        /// </summary>
        public ObservableCollection<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Адреса электронной почты
        /// </summary>
        public ObservableCollection<Email> Emails { get; set; }

        /// <summary>
        /// Банковские реквизиты
        /// </summary>
        public BankDetails BankDetails { get; set; }

        /// <summary>
        /// Лицевые счета, принадлежащие данному лицу
        /// </summary>
        public ObservableCollection<ShareholderAccount> ShareholderAccounts { get; set; }

        /// <summary>
        /// Указание на то, является ли лицо акционером
        /// </summary>
        public bool RoleIsShareHolderFlag { get; set; }

        /// <summary>
        /// Указание на то, является ли лицо единоличным исполнительным органом
        /// </summary>
        public bool RoleIsFirstPersonOfTheCompany { get; set; }

        /// <summary>
        /// Дата создания (последнего редактирования) записи о лице
        /// </summary>
        public DateTime? TimeStamp { get; set; }

        /// <summary>
        /// Полное наименование лица
        /// </summary>
        public string FullName { get; set; }
    }
}