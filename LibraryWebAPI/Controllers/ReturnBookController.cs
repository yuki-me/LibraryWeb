using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Model;
using LibraryWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReturnBookController : Controller
    {
        private readonly ReturnBookRepository _returnBookRepository;
        private readonly IMapper _imapper;

        public ReturnBookController(ReturnBookRepository returnBookRepository, IMapper imapper)
        {
            _returnBookRepository = returnBookRepository;
            _imapper = imapper;
        }

        [HttpGet(Name = "GetReturnBooks")]
        public async Task<Result<List<ReturnBook>>> GetReturnBooks()
        {
            var returnBook = _returnBookRepository.GetReturnBooks().ToList();
            var response = new Result<List<ReturnBook>>()
            {
                Success = true,
                Message = $"Sucessfully returned {returnBook.Count} Books",
                StatusCode = StatusCodes.Status200OK,
                Data = returnBook
            };
            return await Task.FromResult(response);
        }
        [HttpGet("byId/{id}", Name = "GetReturnBook")]
        public async Task<Result<ReturnBook>> GeteturnBook(string id)
        {
            var returnBook = _returnBookRepository.GetReturnBook(id);
            Result<ReturnBook>? response;
            if (returnBook == null)
            {
                response = new Result<ReturnBook>()
                {
                    Success = false,
                    Message = $"Book with this id {id} does not exist",
                    StatusCode = StatusCodes.Status404NotFound,
                    Data = null
                };
            }
            else
            {
                response = new Result<ReturnBook>()
                {
                    Success = true,
                    Message = $"Sucessfully returned {id} Books",
                    StatusCode = StatusCodes.Status200OK,
                    Data = returnBook
                };
            }
            return await Task.FromResult(response);
        }
        [HttpPost(Name = "InputReturnBook")]
        public async Task<Result<string>> PostBook([FromBody] ReturnBookDto returnBookCreate)
        {
            var returnBook = _imapper.Map<ReturnBook>(returnBookCreate);
            Result<string> response;
            try
            {
                string? id = _returnBookRepository.CreateReturnBook(returnBook);
                if (id != null)
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully created return book with this id {id}",
                        StatusCode = StatusCodes.Status201Created,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed create return book with this id {id} does already exist",
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
        [HttpPut(Name = "UpdateReturnBook")]
        public async Task<Result<string>> UpdateReturnBook([FromBody] ReturnBookDto returnBookUpdate)
        {
            var returnBook = _imapper.Map<ReturnBook>(returnBookUpdate);
            Result<string> response;
            try
            {
                if (_returnBookRepository.UpdateReturnBook(returnBook))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully update return book with this id {returnBook.Id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = returnBook.Id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed update return book with this id {returnBook.Id}",
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
        [HttpDelete(Name = "DeleteReturnBook")]
        public async Task<Result<string>> DeleteBook(string id)
        {
            Result<string> response;
            try
            {
                if (_returnBookRepository.DeleteBook(id))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully delete return book with this id {id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed in delete return book with this id {id}",
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
