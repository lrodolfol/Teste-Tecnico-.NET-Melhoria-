using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Data.Interfaces;
using todo_manager.Models.Entitie;

namespace todo_manager.Models.Data
{
    public class CardContext 
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CardContext(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateCard(CreateCardDto cardDto)
        {
            if(cardDto == null)
            {
                throw new ArgumentNullException(nameof(cardDto));
            }

            Todo cardTodo = _mapper.Map<Todo>(cardDto);

            _context.Todo.Add(cardTodo);
        }

        public bool DeleteCard(int id)
        {
            Todo cardTodo = _context.Todo.FirstOrDefault(t => t.Id == id);
            if (cardTodo != null)
            {
                return false;
            }

            _context.Todo.Remove(cardTodo);

            return true;
        }

        public Todo GetCard(int id)
        {
            return _context.Todo.FirstOrDefault(t => t.Id == id);
        }
        
        public IEnumerable<ReadCardDto> GetCard(string? title)
        {
            IList<Todo> cardsTodo = (from todo in _context.Todo
                                    orderby todo.IdPriority descending
                                    select todo).ToList();
            if (cardsTodo == null)
            {
                return null;
            }                

            if (!string.IsNullOrEmpty(title))
            {
                var query =
                    (from t in cardsTodo
                     where t.title == title
                     select t).ToList();

                cardsTodo = query.ToList();
            }

            IList<ReadCardDto> cardsDto = _mapper.Map<IList<ReadCardDto>>(cardsTodo);

            return cardsDto;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
