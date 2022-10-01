using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Model;
using LibraryWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(StudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetStudents")]
        public async Task<Result<List<Students>>> GetStudents()
        {
            var student = _studentRepository.GetStudents().ToList();
            var response = new Result<List<Students>>()
            {
                Success = true,
                Message = $"Sucessfully returned {student.Count} students",
                StatusCode = StatusCodes.Status200OK,
                Data = student
            };
            return await Task.FromResult(response);
        }
        [HttpGet("byId/{id}", Name = "GetStudent")]
        public async Task<Result<Students>> GetStudent(string id)
        {
            var student = _studentRepository.GetStudent(id);
            Result<Students>? response;
            if (student == null)
            {
                response = new Result<Students>()
                {
                    Success = false,
                    Message = $"Book with this id {id} does not exist",
                    StatusCode = StatusCodes.Status404NotFound,
                    Data = null
                };
            }
            else
            {
                response = new Result<Students>()
                {
                    Success = true,
                    Message = $"Sucessfully returned {id} students",
                    StatusCode = StatusCodes.Status200OK,
                    Data = student
                };
            }
            return await Task.FromResult(response);
        }
        [HttpPost(Name = "InputStudents")]
        public async Task<Result<string>> PostStudents([FromBody] StudentsDto returnBookCreate)
        {
            var returnBook = _mapper.Map<Students>(returnBookCreate);
            Result<string> response;
            try
            {
                string? id = _studentRepository.CreateStudent(returnBook);
                if (id != null)
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully created return student with this id {id}",
                        StatusCode = StatusCodes.Status201Created,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed create return student with this id {id} does already exist",
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
        [HttpPut(Name = "UpdateStudents")]
        public async Task<Result<string>> UpdateReturnBook([FromBody] StudentsDto returnBookUpdate)
        {
            var student = _mapper.Map<Students>(returnBookUpdate);
            Result<string> response;
            try
            {
                if (_studentRepository.UpdateStudent(student))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully update return student with this id {student.Id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = student.Id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed update return student with this id {student.Id}",
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
        [HttpDelete(Name = "DeleteStudents")]
        public async Task<Result<string>> DeleteStudents(string id)
        {
            Result<string> response;
            try
            {
                if (_studentRepository.DeleteStudent(id))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully delete return student with this id {id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed in delete return student with this id {id}",
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
