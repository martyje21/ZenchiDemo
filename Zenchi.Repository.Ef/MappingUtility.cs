using Zenchi.Domain.Entities;
using Zenchi.Repository.Ef.DataEntities;
using AutoMapper;
using System.Linq;

namespace Zenchi.Repository.Ef
{
    public class MappingUtility
    {
        public void RegisterMappings()
        {
            Mapper.CreateMap<ConfigurationData, Configuration>();
            Mapper.CreateMap<ProjectData, Project>();
            Mapper.CreateMap<ProjectItemData, ProjectItem>();
        }


        public Configuration MapConfiguration(ConfigurationData configurationData)
        {
            return Mapper.Map<Configuration>(configurationData);
        }

        public Project MapProject(ProjectData projectData)
        {
            return Mapper.Map<Project>(projectData);
        }

        public ProjectItem MapProjectItem(ProjectItemData projectItemData)
        {
            return Mapper.Map<ProjectItem>(projectItemData);
        }

    }
}
