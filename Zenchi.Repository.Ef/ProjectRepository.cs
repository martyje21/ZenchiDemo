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
                ProjectData dbItem = context.ProjectData.Find(projectId);
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
                ProjectData dbItem = context.ProjectData.Find(projectId);
                if (dbItem == null)
                    throw new KeyNotFoundException();

                return Mapper.MapProject(dbItem);
            }
        }

        public Project UpdateProject(Project project)
        {
            using (var context = new ZenchiDBContext())
            {
                ProjectData dbItem = context.ProjectData.Find(project.ProjectId);
                
                if (dbItem == null)
                    throw new KeyNotFoundException();

                context.Set<ProjectData>().AddOrUpdate(Mapper.MapProject(project));
                context.SaveChanges();

                dbItem = context.ProjectData.Find(project.ProjectId);
                return Mapper.MapProject(dbItem);
            }
        }
    }
}
