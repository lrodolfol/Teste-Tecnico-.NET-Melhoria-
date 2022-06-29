using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using todo_manager.Models.Data;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Data.Interfaces;
using todo_manager.Models.Entitie;

namespace todo_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase, ICardController
    {
        private CardContext _cardContext;
        private IMapper _mapper;

        public TodoController(CardContext cardContext, IMapper mapper)
        {
            _cardContext = cardContext;
            _mapper = mapper;
        }

        /* [HttpPut("{id}")]
         public IActionResult PutCard(int id, CreateCardDto dtoCard)
         {
             Todo todoCard = _context.Todo.FirstOrDefault(t => t.Id == id);

             if (todoCard == null)
             {
                 return NotFound();
             }

             todoCard = _mapper.Map(dtoCard, todoCard);

             try
             {
                 _context.SaveChanges();
             }
             catch(Exception)
             {
                 return StatusCode(500);
             }

             return NoContent();
         }*/

        public IActionResult PutCard(int id, CreateCardDto dtoCard)
        {
            return NoContent();
        }



        [HttpPost]
        public IActionResult PostCard([FromBody] CreateCardDto dtoCard)
        {
            try
            {
                _cardContext.CreateCard(dtoCard);
                _cardContext.Save();

                Todo cardTodo = _mapper.Map<Todo>(dtoCard);

                ReadCardDto cardDto = _mapper.Map<ReadCardDto>(cardTodo);

                return CreatedAtAction(nameof(GetCard), new { id = cardDto.Id }, cardDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        public IActionResult GetCard([FromQuery] string title)
        {
            var cardsDto = _cardContext.GetCard(title);

            return Ok(cardsDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            if(!_cardContext.DeleteCard(id))
            {
                return NotFound();
            }

            _cardContext.Save();

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetCard(int id)
        {
            var cardTodo = _cardContext.GetCard(id);

            if (cardTodo == null)
            {
                return NotFound();
            }

            ReadCardDto readCardDto = _mapper.Map<ReadCardDto>(cardTodo);

            return Ok(readCardDto);
        }
    }
}
