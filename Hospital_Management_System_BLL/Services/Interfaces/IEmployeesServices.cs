﻿using Hospital_Management_System_DAL.Wrapper_Response;
using Hospital_Management_System_DTO.Data_transfer_objects.Result_Request_DTO;
using Hospital_Management_System_DAL.Unit_of_Work_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System_DAL.Pagination;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management_System_DAL.Filter;
using Hospital_Management_System_DAL.Pagination.Services.Interfaces;

namespace Hospital_Management_System_BLL.Services.Interfaces
{
    public interface IEmployeesServices
    {
        Task<ResultResponse<IEnumerable<GetEmployeesDTO>>> GetAllEmployeesAsync();

        Task<ResultResponse<GetEmployeesDTO>> GetEmployeeByIdAsync(Guid ID);

        Task<ResultResponse<GetEmployeesDTO>> InsertEmployeeAsync(InsertEmployeeDTO employeeDTO);

        Task<ResultResponse<GetEmployeesDTO>> UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO);

        Task<ResultResponse<IEnumerable<GetEmployeesDTO>>> DeleteEntityByIdAsync(Guid ID);

        Task<PagedResponse<IEnumerable<GetEmployeesDTO>>> GetAllEmployeeUsingPaginationAsync([FromQuery] PaginationFiltering filter, IUriService uriService, string route);
    }
}
