using ProjectManagement.Entities;
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services.IService
{
    public interface IProjectService
    {
        Task<ResponseModel<int>> CreateProject(ProjectModel projectRequestModel);

        Task<ResponseModel<ProjectModel>> GetProjectById(int id);

        Task<ResponseModel<List<ProjectModel>>> GetProjectList();

        Task<ResponseModel<int>> DeleteProject(int id);
    }
}
