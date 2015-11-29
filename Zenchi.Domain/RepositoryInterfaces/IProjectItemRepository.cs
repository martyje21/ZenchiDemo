using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenchi.Domain.Entities;

namespace Zenchi.Domain.RepositoryInterfaces
{
    public interface IProjectItemRepository
    {
        List<ProjectItem> GetAllProjectItemsForProjectId(string projectId);
    }
}
