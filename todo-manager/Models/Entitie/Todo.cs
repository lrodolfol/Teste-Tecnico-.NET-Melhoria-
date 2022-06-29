using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace todo_manager.Models.Entitie
{
    public class Todo : Card
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório: Id")]
        public override int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Titulo")]
        [StringLength(15, ErrorMessage = "Campo Title: não pode exceder 15 caracteres")]
        public override string title { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: User Story")]
        [StringLength(120, ErrorMessage = "Campo User Story não pode exceder 120 caracteres")]
        public override string UserStory { get; set; }

        [DefaultValue(null)]
        public override DateTime DeadLine { get; set; }

        [DefaultValue(1)]
        [Range(1, 3, ErrorMessage = "Campo de prioridade deve deve estar entre 1(baixo), 2(medio) e 3(urgente)")]
        public override int IdPriority { get; set; }
        public virtual Priority Priority { get; set; }
    }
}
