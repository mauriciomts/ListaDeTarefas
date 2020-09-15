using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.Models
{
    public class Importancia
    {
        public int ImportanciaId{ get; set; }

        [Remote("ImportanciaExiste", "Importancias", AdditionalFields = "ImportanciaId")]
        public string Nome { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
