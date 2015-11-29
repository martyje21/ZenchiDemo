using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenchi.Domain.Entities;
using Zenchi.Domain.ServiceInterfaces;
using Zenchi.Domain.RepositoryInterfaces;


namespace Zenchi.Services
{
    public class ProjectService : IProjectService
    {
        protected IProjectRepository ProjectRepository { get; set; }
        public ProjectService(IProjectRepository projectRepository)
        {
            if (projectRepository == null)
                throw new ArgumentNullException("IProjectRepository is null");

            ProjectRepository = projectRepository;
        }

        public Project CreateProject(Project project)
        {
            return ProjectRepository.CreateProject(project);
        }

        public void DeleteProject(string projectId)
        {
            ProjectRepository.DeleteProject(projectId);
        }

        public List<ProjectItem> GetAllProjectItemsForProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllProjectsForUser()
        {
            return ProjectRepository.GetAllProjectsForUser();
        }

        public Project GetProject(string projectId)
        {
            return ProjectRepository.GetProject(projectId);
        }

        public Project UpdateProject(Project project)
        {
            return ProjectRepository.UpdateProject(project);
        }
    }
}
