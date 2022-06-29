using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace todo_manager.Models.Entitie
{
    public abstract class Card
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório: Id")]
        public abstract int Id { get; set; }

        [Required(ErrorMessage = "")]
        [StringLength(15, ErrorMessage = "")]
        public abstract string title { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: User Story")]
        [StringLength(120, ErrorMessage = "")]
        public abstract string UserStory { get; set; }

        [DefaultValue(null)]
        public abstract DateTime DeadLine { get; set; }

        [DefaultValue(1)]
        [Range(1, 3, ErrorMessage = "Campo deve deve estar entre 1 e 3")]
        public abstract int IdPriority { get; set; }

        public virtual Priority Priority { get; set; }
    }
}