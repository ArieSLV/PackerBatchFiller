using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Адрес
    /// </summary>
    [Table("Addresses")]
    public class Address
    {

        /// <summary>
        /// ID в базе данных адреса
        /// </summary>
        public long AddressId { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Тип региона 
        /// </summary>
        public string RegionType { get; set; }

        /// <summary>
        /// Имя региона
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Тип местности
        /// </summary>
        public string DistrictType { get; set; }

        /// <summary>
        /// Имя местности
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// Тип поселения
        /// </summary>
        public string CityType { get; set; }

        /// <summary>
        /// Имя поселения
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Тип локального населенного пункта
        /// </summary>
        public string LocalityType { get; set; }

        /// <summary>
        /// Имя локального населенного пункта
        /// </summary>
        public string LocalityName { get; set; }

        /// <summary>
        /// Тип улицы
        /// </summary>
        public string StreetType { get; set; }

        /// <summary>
        /// Имя улицы
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Тип здания
        /// </summary>
        public string BuildingType { get; set; }

        /// <summary>
        /// Номер здания
        /// </summary>
        public string BuildingValue { get; set; }

        /// <summary>
        /// Корпус\строение\литера
        /// </summary>
        public string SubBuildingType { get; set; }

        /// <summary>
        /// Номер корпуса\строения\буква литеры
        /// </summary>
        public string SubBuildingValue { get; set; }

        /// <summary>
        /// Квартира\офис
        /// </summary>
        public string FlatType { get; set; }

        /// <summary>
        /// Номер квартиры\офиса
        /// </summary>
        public string FlatValue { get; set; }
    }
}