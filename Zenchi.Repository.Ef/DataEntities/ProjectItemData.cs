using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zenchi.Repository.Ef.DataEntities
{
    [Table("ProjectItem")]
    public class ProjectItemData
    {
        [Key]
        public string ProjectItemId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }
    }
}
