using BooksApi.DTOs;
using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public ActionResult<Book> GetBooks([FromQuery] string title)
        {
            return _service.GetBook(title);
        }

        [HttpDelete("Remove")]
        public void RemoveBook([FromQuery] Guid id)
        {
            _service.RemoveBook(id);
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(Book book)
        {
          

            var res = _service.AddBook(book);
            return Created(nameof(AddBook), new {id = res.Message });
        }
    }
}
