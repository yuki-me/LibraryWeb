using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Model;
using LibraryWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetUser")]
        public async Task<Result<List<Users>>> GetUsers()
        {
            var returnBook = _userRepository.GetUsers().ToList();
            var response = new Result<List<Users>>()
            {
                Success = true,
                Message = $"Sucessfully returned {returnBook.Count} user",
                StatusCode = StatusCodes.Status200OK,
                Data = returnBook
            };
            return await Task.FromResult(response);
        }
        [HttpGet("byId/{id}", Name = "GetUsers")]
        public async Task<Result<Users>> GetUser(string id)
        {
            var returnBook = _userRepository.GetUser(id);
            Result<Users>? response;
            if (returnBook == null)
            {
                response = new Result<Users>()
                {
                    Success = false,
                    Message = $"Book with this id {id} does not exist",
                    StatusCode = StatusCodes.Status404NotFound,
                    Data = null
                };
            }
            else
            {
                response = new Result<Users>()
                {
                    Success = true,
                    Message = $"Sucessfully returned {id} user",
                    StatusCode = StatusCodes.Status200OK,
                    Data = returnBook
                };
            }
            return await Task.FromResult(response);
        }
        [HttpPost(Name = "InputUsers")]
        public async Task<Result<string>> PostUsers([FromBody] UsersDto userCreate)
        {
            var user = _mapper.Map<Users>(userCreate);
            Result<string> response;
            try
            {
                string? id = _userRepository.CreateUser(user);
                if (id != null)
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully created return user with this id {id}",
                        StatusCode = StatusCodes.Status201Created,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed create return user with this id {id} does already exist",
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
        [HttpPut(Name = "UpdateUser")]
        public async Task<Result<string>> UpdateUser([FromBody] UsersDto userUpdate)
        {
            var user = _mapper.Map<Users>(userUpdate);
            Result<string> response;
            try
            {
                if (_userRepository.UpdateUser(user))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully update return user with this id {user.Id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = user.Id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed update return user with this id {user.Id}",
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
        [HttpDelete(Name = "DeleteUser")]
        public async Task<Result<string>> DeleteUser(string id)
        {
            Result<string> response;
            try
            {
                if (_userRepository.DeleteUser(id))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully delete return user with this id {id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed in delete return user with this id {id}",
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
