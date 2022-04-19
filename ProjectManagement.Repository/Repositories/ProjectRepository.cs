using ProjectManagement.Database;
using ProjectManagement.Database.Tables;
using ProjectManagement.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ProjectManagement.Repository.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> SaveProject(Project project)
        {
            try
            {
                var parameters = new List<object>(){
                new SqlParameter("@Id",project.Id),
                new SqlParameter("@Name", project.Name),
                new SqlParameter("@Amount", project.Amount),
                new SqlParameter("@Tenure", project.Tenure),
                new SqlParameter("@CustomerName", project.CustomerName),
                };
                    return await _context.Database.ExecuteSqlRawAsync("exec SaveProject @Id,@Name,@Amount,@Tenure,@CustomerName", parameters.ToArray());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteProject(int id)
        {
            try
            {
                var parameters = new List<object>(){
                new SqlParameter("@Id",id),
                };
                return await _context.Database.ExecuteSqlRawAsync("exec DeleteProject @Id", parameters.ToArray());
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IQueryable<Project>> ListProjects()
        {
            try
            {
                return await Task.Run(() => _context.Projects.FromSqlRaw("exec ListProjects"));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<Project> GetProjectById(int id)
        {
            try
            {
                var parameters = new List<object>(){
                new SqlParameter("@Id",id),
                };
                return await Task.Run(() => _context.Projects.FromSqlRaw("exec GetProjectById @Id", parameters.ToArray()).AsEnumerable().FirstOrDefault());
            }
            catch(Exception ex)
            {
                throw ex;
            } 
            
        }
    }
}
