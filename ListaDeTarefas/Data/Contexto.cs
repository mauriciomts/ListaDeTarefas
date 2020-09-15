using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Importancia> Importancias { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
        }
    }
}
