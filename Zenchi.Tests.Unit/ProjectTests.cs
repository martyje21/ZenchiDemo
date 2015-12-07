using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Zenchi.Domain.Entities;
using Zenchi.Domain.ServiceInterfaces;
using Zenchi.Domain.RepositoryInterfaces;
using Zenchi.Services;


namespace Zenchi.Tests.Unit
{
    [TestFixture]
    public class ProjectTests
    {

        [Test]
        public void CreateProject_HappyPath_Test()
        {

            IProjectService _projectService = new ProjectService(new TestProjectRepository());

            var project = _projectService.CreateProject(new Project()
            {
                Description = "My new project",
                Name = "New Project",
                ProjectId = "FD006E64-ACB5-4257-B516-6F186D762AFB"
            });

            Assert.AreEqual(project.Description, "My new project");
            Assert.AreEqual(project.Name, "New Project");
            Assert.AreEqual(project.ProjectId, "FD006E64-ACB5-4257-B516-6F186D762AFB");
        }
    }


    public class TestProjectRepository : IProjectRepository
    {
        List<Project> projects { get; set; }
        public TestProjectRepository()
        {
            List<Project> projs = new List<Project>();

            projs.Add(new Project()
            {
                Description = "Test project 1",
                Name = "Project1",
                ProjectId = "13ABB18F-75E2-48A0-94F0-7DC2585B56FF"
            });

            projs.Add(new Project()
            {
                Description = "Test project 2",
                Name = "Project2",
                ProjectId = "2CE0C856-0F27-4F98-BE22-C6FF07C67002"
            });

            projs.Add(new Project()
            {
                Description = "Test project 3",
                Name = "Project3",
                ProjectId = "D5089898-E47F-4665-AE03-A4E4AFE8A2A8"
            });

            projects = projs;
        }

        public Project CreateProject(Project project)
        {
            return project;
        }

        public void DeleteProject(string projectId)
        {
            if (string.IsNullOrEmpty(projectId))
                throw new ArgumentNullException("Project Id is null or empty");
        }

        public List<ProjectItem> GetAllProjectItemsForProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllProjectsForUser()
        {

            return projects;
        }

        public Project GetProject(string projectId)
        {
            return projects.FirstOrDefault(p => p.ProjectId == projectId);
        }

        public Project UpdateProject(Project project)
        {
            return project;
        }
    }
}
