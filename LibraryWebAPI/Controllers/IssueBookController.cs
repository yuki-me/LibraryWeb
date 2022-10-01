using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Model;
using LibraryWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueBookController:Controller
    {
        private readonly IssueBookRepository _issueBookRepository;
        private readonly IMapper _mapper;

        public IssueBookController(IssueBookRepository issueBookRepository, IMapper mapper)
        {
            _issueBookRepository = issueBookRepository;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetIssueBooks")]
        public async Task<Result<List<IssueBook>>> GetIssueBooks()
        {
            var issueBooks = _issueBookRepository.GetIssueBooks().ToList();
            var response = new Result<List<IssueBook>>()
            {
                Success = true,
                Message = $"Sucessfully returned {issueBooks.Count} Books",
                StatusCode = StatusCodes.Status200OK,
                Data = issueBooks
            };
            return await Task.FromResult(response);
        }
        [HttpGet("byId/{id}", Name = "GetIssueBook")]
        public async Task<Result<IssueBook>> GetIssueBook(string id)
        {
            var issueBook = _issueBookRepository.GetIssueBook(id);
            Result<IssueBook>? response;
            if (issueBook == null)
            {
                response = new Result<IssueBook>()
                {
                    Success = false,
                    Message = $"Book with this id {id} does not exist",
                    StatusCode = StatusCodes.Status404NotFound,
                    Data = null
                };
            }
            else
            {
                response = new Result<IssueBook>()
                {
                    Success = true,
                    Message = $"Sucessfully returned {id} issue Books",
                    StatusCode = StatusCodes.Status200OK,
                    Data = issueBook
                };
            }
            return await Task.FromResult(response);
        }
        [HttpPost(Name = "InputIssueBook")]
        public async Task<Result<string>> PostIssueBook([FromBody] IssueBookDto issueBookCreate)
        {
            var issueBook = _mapper.Map<IssueBook>(issueBookCreate);
            Result<string> response;
            try
            {
                string? id = _issueBookRepository.CreateIssueBook(issueBook);
                if (id != null)
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully created issue book with this id {id}",
                        StatusCode = StatusCodes.Status201Created,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed create issue book with this id {id} does already exist",
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
        [HttpPut(Name = "UpdateIssueBook")]
        public async Task<Result<string>> UpdateIssueBook([FromBody] IssueBookDto issueBookUpdate)
        {
            var issueBook = _mapper.Map<IssueBook>(issueBookUpdate);
            Result<string> response;
            try
            {
                if (_issueBookRepository.UpdateIssueBook(issueBook))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully update issue book with this id {issueBook.Id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = issueBook.Id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed update issue book with this id {issueBook.Id}",
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
        [HttpDelete(Name = "DeleteIssueBook")]
        public async Task<Result<string>> DeleteIssueBook(string id)
        {
            Result<string> response;
            try
            {
                if (_issueBookRepository.DeleteBook(id))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully delete issue book with this id {id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed in delete issue book with this id {id}",
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
