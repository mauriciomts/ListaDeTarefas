using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using ListaDeTarefas.AcessoDados.Interfaces;

namespace ListaDeTarefas.Controllers
{
    public class ImportanciasController : Controller
    {
        private readonly IImportanciaRepositorio _importanciaRepositorio;

        public ImportanciasController(IImportanciaRepositorio importanciaRepositorio)
        {
            _importanciaRepositorio = importanciaRepositorio;
        }

        // GET: Importancias
        public IActionResult Index()
        {
            return View(_importanciaRepositorio.PegarTodos());
        }
                
        // GET: Importancias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Importancias/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImportanciaId,Nome")] Importancia importancia)
        {
            if (ModelState.IsValid)
            {
                await _importanciaRepositorio.Inserir(importancia);
                return RedirectToAction(nameof(Index));
            }
            return View(importancia);
        }

        // GET: Importancias/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            
            var importancia = await _importanciaRepositorio.PegarPeloId(id);
            if (importancia == null)
            {
                return NotFound();
            }
            return View(importancia);
        }

        // POST: Importancias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImportanciaId,Nome")] Importancia importancia)
        {
            if (id != importancia.ImportanciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _importanciaRepositorio.Atualizar(importancia);
                return RedirectToAction(nameof(Index));
            }
            return View(importancia);
        }

        
        // POST: Importancias/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _importanciaRepositorio.Excluir(id);
            return Json("Impontancia excluída com sucesso");
        }

        public async Task<JsonResult> ImportanciaExiste(string nome, int ImportanciaId)
        {
            if(ImportanciaId == 0)
            {
                if (await _importanciaRepositorio.ImportanciaExiste(nome))
                    return Json("Importancia já existe");

                return Json(true);
            }
            else
            {
                if (await _importanciaRepositorio.ImportanciaExiste(nome, ImportanciaId))
                    return Json("Importancia já existe");

                return Json(true);
            }
        }
    }
}
