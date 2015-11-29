using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zenchi.Repository.Ef.DataEntities
{
    [Table("Configuration")]
    public class ConfigurationData
    {
        [Key]
        public int ConfigurationId { get; set; }

        [StringLength(50)]
        public string Key { get; set; }

        [StringLength(500)]
        public string Value { get; set; }
    }
}
