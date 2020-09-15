using ListaDeTarefas.AcessoDados.Interfaces;
using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.AcessoDados.Repositorios
{
    public class TarefaRepositorio : RepositorioGenerico<Tarefa>, ITarefaRepositorio
    {
        private readonly Contexto _contexto;

        public TarefaRepositorio(Contexto contexto) : base (contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> TarefaExiste(string nome)
        {
            return await _contexto.Tarefas.AnyAsync(t => t.Nome == nome);
        }

        public async Task<bool> TarefaExiste(string nome, int TarefaId)
        {
            return await _contexto.Tarefas.AnyAsync(t => t.Nome == nome && t.TarefaId == TarefaId);
        }

        public new async Task<IEnumerable<Tarefa>> PegarTodos()
        {
            return await _contexto.Tarefas.Include(t => t.Importancia).ToListAsync();
        }
    }
}
