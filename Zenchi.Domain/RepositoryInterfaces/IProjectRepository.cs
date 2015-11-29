using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenchi.Domain.Entities;

namespace Zenchi.Domain.RepositoryInterfaces
{
    public interface IProjectRepository
    {
        List<Project> GetAllProjectsForUser();

        Project GetProject(string projectId);

        Project UpdateProject(Project project);

        Project CreateProject(Project project);

        void DeleteProject(string projectId);
    }
}
