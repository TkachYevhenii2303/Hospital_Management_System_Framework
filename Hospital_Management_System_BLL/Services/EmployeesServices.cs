﻿using AutoMapper;
using Hospital_Management_System_BLL.Services.Interfaces;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Filter;
using Hospital_Management_System_DAL.Pagination;
using Hospital_Management_System_DAL.Pagination.Services.Interfaces;
using Hospital_Management_System_DAL.Unit_of_Work_Pattern.Interfaces;
using Hospital_Management_System_DAL.Wrapper_Response;
using Hospital_Management_System_DTO.Data_transfer_objects.Result_Request_DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_BLL.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public EmployeesServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public async Task<ResultResponse<IEnumerable<GetEmployeesDTO>>> DeleteEntityByIdAsync(Guid ID)
        {
            var employees = await _unitOfWork.EmployeesRepository.DeleteEntityByIdAsync(ID);

            await _unitOfWork.Complete();

            return _mapper.Map<ResultResponse<IEnumerable<Employees>>, ResultResponse<IEnumerable<GetEmployeesDTO>>>(employees);
        }

        public async Task<ResultResponse<IEnumerable<GetEmployeesDTO>>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.EmployeesRepository.GetAllInformationsAsync();

            return _mapper.Map<ResultResponse<IEnumerable<Employees>>, ResultResponse<IEnumerable<GetEmployeesDTO>>>(employees);
        }

        public async Task<ResultResponse<GetEmployeesDTO>> GetEmployeeByIdAsync(Guid ID)
        {
            var employee = await _unitOfWork.EmployeesRepository.GetEntityByIdAsync(ID);

            return _mapper.Map<ResultResponse<GetEmployeesDTO>>(employee);
        }

        public async Task<ResultResponse<GetEmployeesDTO>> InsertEmployeeAsync(InsertEmployeeDTO employee)
        {
            var result = await _unitOfWork.EmployeesRepository.InsertEntityAsync(_mapper.Map<Employees>(employee));

            await _unitOfWork.Complete();

            return _mapper.Map<ResultResponse<GetEmployeesDTO>>(result);
        }

        public async Task<ResultResponse<GetEmployeesDTO>> UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO)
        {
            var result = await _unitOfWork.EmployeesRepository.UpdateEntityAsync(_mapper.Map<Employees>(employeeDTO));

            await _unitOfWork.Complete();

            return _mapper.Map<ResultResponse<GetEmployeesDTO>>(result);
        }

        public async Task<PagedResponse<IEnumerable<GetEmployeesDTO>>> GetAllEmployeeUsingPaginationAsync([FromQuery] PaginationFiltering filter, IUriService uriService, string route)
        {
            var result = await _unitOfWork.EmployeesRepository.GetAllEmployeeUsingPaginationAsync(filter, uriService, route);

            return _mapper.Map<PagedResponse<IEnumerable<Employees>>, PagedResponse<IEnumerable<GetEmployeesDTO>>>(result);
        }
    }
}
