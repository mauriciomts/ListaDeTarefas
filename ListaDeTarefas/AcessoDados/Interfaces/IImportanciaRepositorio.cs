using ListaDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.AcessoDados.Interfaces
{
    public interface IImportanciaRepositorio : IRepositorioGenerico<Importancia>
    {
        Task<bool> ImportanciaExiste(string importancia);
        Task<bool> ImportanciaExiste(string importancia, int ImportanciaId);
    }
}
