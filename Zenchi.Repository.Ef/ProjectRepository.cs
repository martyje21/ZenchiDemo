using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenchi.Domain.Entities;
using Zenchi.Domain.RepositoryInterfaces;
using Zenchi.Repository.Ef.DataEntities;

namespace Zenchi.Repository.Ef
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {

        public Project CreateProject(Project project)
        {
            ProjectData newProject = Mapper.MapProject(project);

            newProject.ProjectId = Guid.NewGuid().ToString();

            using (var context = new ZenchiDBContext())
            {
                context.ProjectData.Add(newProject);
                context.SaveChanges();

                return Mapper.MapProject(newProject);
            }
            
        }

        public void DeleteProject(string projectId)
        {
            using (var context = new ZenchiDBContext())
            {
                ProjectData dbItem = context.ProjectData
                                     .Where(p => p.ProjectId == projectId)
                                     .FirstOrDefault();

                if (dbItem == null)
                    throw new KeyNotFoundException();

                context.ProjectData.Remove(dbItem);
                context.SaveChanges();
            }
        }

        public List<Project> GetAllProjectsForUser()
        {
            List<ProjectData> projectDatas;

            using (var context = new ZenchiDBContext())
            {
                projectDatas = context.ProjectData.ToList();

            }

            List<Project> projects = new List<Project>();
            foreach(var pd in projectDatas)
            {
                projects.Add(Mapper.MapProject(pd));
            }

            return projects;
        }

        public Project GetProject(string projectId)
        {
            using (var context = new ZenchiDBContext())
            {
                ProjectData dbItem = context.ProjectData
                                     .Where(p => p.ProjectId == projectId)
                                     .FirstOrDefault();
                                   
                if (dbItem == null)
                    throw new KeyNotFoundException();

                return Mapper.MapProject(dbItem);
            }
        }

        public Project UpdateProject(Project project)
        {
            using (var context = new ZenchiDBContext())
            {
                ProjectData dbItem = context.ProjectData
                                     .Where(p => p.ProjectId == project.ProjectId)
                                     .FirstOrDefault();

                if (dbItem == null)
                    throw new KeyNotFoundException();

                var updateItem = Mapper.MapProject(project);
                updateItem.Id = dbItem.Id;

                context.Set<ProjectData>().AddOrUpdate(updateItem);
                context.SaveChanges();

                return Mapper.MapProject(updateItem);
            }
        }
    }
}
