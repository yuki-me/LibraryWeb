using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Model;
using LibraryWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(BookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        [HttpGet(Name ="GetBooks")]
        public async Task<Result<List<Books>>> GetBooks()
        {
            var books = _bookRepository.GetBooks().ToList();
            var response = new Result<List<Books>>()
            {
                Success = true,
                Message = $"Sucessfully returned {books.Count} Books",
                StatusCode = StatusCodes.Status200OK,
                Data = books
            };
            return await Task.FromResult(response);
        }
        [HttpGet("byId/{id}", Name = "GetBook")]
        public async Task<Result<Books>> GetBook(string id)
        {
            var book = _bookRepository.GetBook(id);
            Result<Books>? response;
            if(book == null)
            {
                response = new Result<Books>()
                {
                    Success = false,
                    Message = $"Book with this id {id} does not exist",
                    StatusCode = StatusCodes.Status404NotFound,
                    Data = null
                };
            }
            else
            {
                response = new Result<Books>()
                {
                    Success = true,
                    Message = $"Sucessfully returned {id} Books",
                    StatusCode = StatusCodes.Status200OK,
                    Data = book
                };
            }
            return await Task.FromResult(response);
        }
        [HttpPost(Name = "InputBook")]
        public async Task<Result<string>> PostBook([FromBody]BooksDto bookCreate)
        {
            var book = _mapper.Map<Books>(bookCreate);
            Result<string> response;
            try
            {
                string? id = _bookRepository.CreateBook(book);
                if (id != null)
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully created book with this id {id}",
                        StatusCode = StatusCodes.Status201Created,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed create book with this id {id} does already exist",
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
        [HttpPut(Name = "UpdateBook")]
        public async Task<Result<string>> UpdateBook([FromBody]BooksDto bookUpdate)
        {
            var book = _mapper.Map<Books>(bookUpdate);
            Result<string> response;
            try
            {
                if (_bookRepository.UpdateBook(book))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully update book with this id {book.Id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = book.Id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed update book with this id {book.Id}",
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
        [HttpDelete(Name = "DeleteBook")]
        public async Task<Result<string>> DeleteBook(string id)
        {
            Result<string> response;
            try
            {
                if (_bookRepository.DeleteBook(id))
                {
                    response = new Result<string>()
                    {
                        Success = true,
                        Message = $"Sucessfully delete book with this id {id}",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = id
                    };
                }
                else
                {
                    response = new Result<string>()
                    {
                        Success = false,
                        Message = $"Failed in delete book with this id {id}",
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
