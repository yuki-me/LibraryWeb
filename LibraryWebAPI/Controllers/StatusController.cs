using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Model;
using LibraryWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController
    {
        private readonly StatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusController(StatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetStatus")]
        public async Task<Result<List<Status>>> GetStatus()
        {
            var status = _statusRepository.GetStatus().ToList();
            var response = new Result<List<Status>>()
            {
                Success = true,
                Message = $"Sucessfully returned {status.Count} status",
                StatusCode = StatusCodes.Status200OK,
                Data = status
            };
            return await Task.FromResult(response);
        }
        [HttpGet("byId/{id}", Name = "GetStatu")]
        public async Task<Result<Status>> GetStatu(string id)
        {
            var status = _statusRepository.GetStatu(id);
            Result<Status>? response;
            if (status == null)
            {
                response = new Result<Status>()
                {
                    Success = false,
                    Message = $"Book with this id {id} does not exist",
                    StatusCode = StatusCodes.Status404NotFound,
                    Data = null
                };
            }
            else
            {
                response = new Result<Status>()
                {
                    Success = true,
                    Message = $"Sucessfully returned {id} status",
                    StatusCode = StatusCodes.Status200OK,
                    Data = status
                };
            }
            return await Task.FromResult(response);
        }
        [HttpPost(Name = "InputStatus")]
        public async Task<Result<string>> PostStatus([FromBody] StatusDto statusCreate)
        {
            var status = _mapper.Map<Status>(statusCreate);
            Result<string> response;
            try
            {
                string? id = _statusRepository.CreateStatus(status);
                if (id != null)
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully created status with this id {id}",
                        StatusCode = StatusCodes.Status201Created,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed create status with this id {id} does already exist",
                        StatusCode = StatusCodes.Status201Created,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Result<string>()
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status409Conflict,
                    Data = null
                };
            }
            return await Task.FromResult(response);
        }
        [HttpPut(Name = "UpdateStatus")]
        public async Task<Result<string>> UpdateStatus([FromBody] StatusDto statusUpdate)
        {
            var status = _mapper.Map<Status>(statusUpdate);
            Result<string> response;
            try
            {
                if (_statusRepository.UpdateStatus(status))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully update status with this id {status.Id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = status.Id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed update status with this id {status.Id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Result<string>()
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status409Conflict,
                    Data = null
                };
            }
            return await Task.FromResult(response);
        }
        [HttpDelete(Name = "DeleteStatus")]
        public async Task<Result<string>> DeleteStatus(string id)
        {
            Result<string> response;
            try
            {
                if (_statusRepository.DeleteStatus(id))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully delete status with this id {id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed in delete status with this id {id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Result<string>()
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status409Conflict,
                    Data = null
                };
            }
            return await Task.FromResult(response);
        }
    }
}
