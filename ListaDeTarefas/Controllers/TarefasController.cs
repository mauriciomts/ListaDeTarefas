﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using ListaDeTarefas.AcessoDados.Interfaces;
using X.PagedList;

namespace ListaDeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly Contexto _contexto;
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly IImportanciaRepositorio _importanciaRepositorio;

        public TarefasController(Contexto contexto, ITarefaRepositorio tarefaRepositorio, IImportanciaRepositorio importanciaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _importanciaRepositorio = importanciaRepositorio;
            _contexto = contexto;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index(int? pagina)
        {
            const int itensPorPagina = 5;
            int numeroPagina = (pagina ?? 1);
            return View(await _contexto.Tarefas.ToPagedListAsync(numeroPagina, itensPorPagina));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar, int? pagina)
        {
            const int itensPorPagina = 5;
            int numeroPagina = (pagina ?? 1);

            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await _contexto.Tarefas.Where(x => x.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToPagedListAsync(numeroPagina, itensPorPagina));

            }

            return View(await _contexto.Tarefas.ToPagedListAsync(numeroPagina, itensPorPagina));
        }
        
        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["ImportanciaId"] = new SelectList(_importanciaRepositorio.PegarTodos(), "ImportanciaId", "Nome");
            return View();
        }

        // POST: Tarefas/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarefaId,Nome,Descricao,Inicio,Fim,ImportanciaId")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                TempData["Cadastro"] = "Tarefa cadastrada com sucesso.";
                await _tarefaRepositorio.Inserir(tarefa);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImportanciaId"] = new SelectList(_importanciaRepositorio.PegarTodos(), "ImportanciaId", "Nome", tarefa.ImportanciaId);
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {            
            var tarefa = await _tarefaRepositorio.PegarPeloId(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewData["ImportanciaId"] = new SelectList(_importanciaRepositorio.PegarTodos(), "ImportanciaId", "Nome", tarefa.ImportanciaId);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarefaId,Nome,Descricao,Inicio,Fim,ImportanciaId")] Tarefa tarefa)
        {
            if (id != tarefa.TarefaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                TempData["Atualizacao"] = "Tarefa atualizada com sucesso.";
                await _tarefaRepositorio.Atualizar(tarefa);
                return RedirectToAction(nameof(Index));

            }
            ViewData["ImportanciaId"] = new SelectList(_importanciaRepositorio.PegarTodos(), "ImportanciaId", "Nome", tarefa.ImportanciaId);
            return View(tarefa);
        }

        
        // POST: Tarefas/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            TempData["Exclusao"] = "Tarefa excluída com sucesso.";
            await _tarefaRepositorio.Excluir(id);
            return Json("Exercicio excluído com sucesso");
        }

        public async Task<JsonResult> TarefaExiste(string nome, int TarefaId)
        {
            if(TarefaId == 0)
            {
                if (await _tarefaRepositorio.TarefaExiste(nome))
                    return Json("Exercicio já existe");

                return Json(true);
            }
            else
            {
                if (await _tarefaRepositorio.TarefaExiste(nome, TarefaId))
                    return Json("Exercicio já existe");

                return Json(true);
            }
        }
    }
}
