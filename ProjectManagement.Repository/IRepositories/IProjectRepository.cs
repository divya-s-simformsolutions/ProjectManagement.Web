using ProjectManagement.Database.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Repository.IRepositories
{
    public interface IProjectRepository
    {
        public Task<int> SaveProject(Project project);
        public Task<int> DeleteProject(int id);
        public Task<IQueryable<Project>> ListProjects();
        public Task<Project> GetProjectById(int id);
    }
}
