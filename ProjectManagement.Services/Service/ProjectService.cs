using AutoMapper;
using ProjectManagement.Database.Tables;
using ProjectManagement.Entities;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repository.IRepositories;
using ProjectManagement.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<int>> CreateProject(ProjectModel projectRequestModel)
        {
            ResponseModel<int> responseModel = new ResponseModel<int>();
            try
            {
                var project = _mapper.Map<Project>(projectRequestModel);
                responseModel.Result = await _projectRepository.SaveProject(project);
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
        }

        public async Task<ResponseModel<int>> DeleteProject(int id)
        {
            ResponseModel<int> responseModel = new ResponseModel<int>();
            try
            {
                responseModel.Result = await _projectRepository.DeleteProject(id);
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
        }

        public async Task<ResponseModel<ProjectModel>> GetProjectById(int id)
        {
            ResponseModel<ProjectModel> responseModel = new ResponseModel<ProjectModel>();
            try
            {
                var projectResponseModel = await _projectRepository.GetProjectById(id);
                responseModel.Result = _mapper.Map<ProjectModel>(projectResponseModel); 
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<ProjectModel>>> GetProjectList()
        {
            ResponseModel<List<ProjectModel>> responseModel = new ResponseModel<List<ProjectModel>>();
            try
            {
                var projectResponseModelList = await _projectRepository.ListProjects();
                responseModel.Result = _mapper.Map<List<ProjectModel>>(projectResponseModelList.ToList());
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
            
        }
    }
}
