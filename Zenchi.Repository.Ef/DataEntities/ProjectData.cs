using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Zenchi.Repository.Ef.DataEntities
{
    [Table("Project")]
    public class ProjectData
    {
        [Key]
        public string ProjectId { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }
    }
}
