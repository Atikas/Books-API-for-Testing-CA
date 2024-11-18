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
        private readonly IBookMapper _mapper;
        private readonly IBookPriceExternalClient _priceClient;


        public BookController(IBookService service, IBookMapper mapper, IBookPriceExternalClient priceClient)
        {
            _service = service;
            _mapper = mapper;
            _priceClient = priceClient;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<GetBookResult>), 200)]
        public IActionResult GetBooks([FromQuery] string title)
        {
            var books = _service.GetBook(title);
            var dto = _mapper.Map(books!);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetBookResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBook([FromRoute] Guid id)
        {
            var book = _service.GetBook(id);
            if (book is null)
                return NotFound();

            var dto = _mapper.Map(book);
            var price = await _priceClient.GetPrice(book.ISBN, "Hardcover");
            dto.Price = price;

            return Ok(dto);
        }



        [HttpDelete("Remove")]
        public IActionResult RemoveBook([FromQuery] Guid id)
        {
            _service.RemoveBook(id);
            return NoContent();
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(CreateBookRequest req)
        {
          
            var book = _mapper.Map(req);
            var res = _service.AddBook(book);
            return Created(nameof(AddBook), new {id = res.Message });
        }
    }
}
