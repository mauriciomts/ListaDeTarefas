using ListaDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.AcessoDados.Interfaces
{
    public interface ITarefaRepositorio : IRepositorioGenerico<Tarefa>
    {
        new Task<IEnumerable<Tarefa>> PegarTodos();
        Task<bool> TarefaExiste(string nome);
        Task<bool> TarefaExiste(string nome, int TarefaId);
    }
}
