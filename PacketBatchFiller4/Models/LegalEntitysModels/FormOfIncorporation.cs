using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Организационно-правовая форма
    /// </summary>
    [Table("FormOfIncorporations")]
    public class FormOfIncorporation
    {
        /// <summary>
        /// ID организационно-правовой формы.
        /// </summary>
        public long FormOfIncorporationId { get; set; }

        /// <summary>
        /// Краткое написание организационно-правовой формы.
        /// </summary>
        public string ShortForm { get; set; }

        /// <summary>
        /// Полное написание организационно-правовой формы.
        /// </summary>
        public string FullForm { get; set; }


        /// <summary>
        /// Явное указание текстового представления организационно-правовой формы.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{FullForm} ({ShortForm})";
    }
}