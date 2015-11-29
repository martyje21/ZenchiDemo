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
        List<Project> GetAllProjectsByUser();
    }
}
