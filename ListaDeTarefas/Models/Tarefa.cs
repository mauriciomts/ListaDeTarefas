using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "Use menos caracteres")]
        [Remote("TarefaExiste", "Tarefas", AdditionalFields = "TarefaId")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "Use menos caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Início")]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Fim { get; set; }

        
        public int ImportanciaId { get; set; }

        
        [Display(Name = "Importância")]
        public Importancia Importancia { get; set; }
    }
}
