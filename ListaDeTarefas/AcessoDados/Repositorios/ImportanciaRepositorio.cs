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
    public class ImportanciaRepositorio : RepositorioGenerico<Importancia>, IImportanciaRepositorio
    {
        private readonly Contexto _contexto;

        public ImportanciaRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ImportanciaExiste(string importancia)
        {
            return await _contexto.Importancias.AnyAsync(i => i.Nome == importancia);
        }

        public async Task<bool> ImportanciaExiste(string importancia, int ImportanciaId)
        {
            return await _contexto.Importancias.AnyAsync(i => i.Nome == importancia && i.ImportanciaId == ImportanciaId);
        }
    }
}
