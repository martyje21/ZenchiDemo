using Zenchi.Domain.Entities;
using System.Collections.Generic;

namespace Zenchi.Domain.ServiceInterfaces
{
    public interface IProjectService
    {
        List<Project> GetAllProjectsForUser();

        List<ProjectItem> GetAllProjectItemsForProjectId(string projectId);
    }
}
