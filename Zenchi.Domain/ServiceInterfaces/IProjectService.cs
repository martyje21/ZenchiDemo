using Zenchi.Domain.Entities;
using System.Collections.Generic;

namespace Zenchi.Domain.ServiceInterfaces
{
    public interface IProjectService
    {
        List<Project> GetAllProjectsForUser();

        List<ProjectItem> GetAllProjectItemsForProjectId(string projectId);

        Project GetProject(string projectId);

        Project UpdateProject(Project project);

        Project CreateProject(Project project);

        void DeleteProject(string projectId);
    }
}
