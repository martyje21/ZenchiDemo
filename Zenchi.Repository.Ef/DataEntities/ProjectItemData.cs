using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zenchi.Repository.Ef.DataEntities
{
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
