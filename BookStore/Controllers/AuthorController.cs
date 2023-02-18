using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        public IBookstoreRepository<Author> authorRepository { get; }

        public AuthorController(IBookstoreRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        // GET: /<controller>/
        public ActionResult Index()
        {
            var authors = authorRepository.List();
            return View(authors);
        }

        public ActionResult Details(int id) {
            var author = authorRepository.Find(id);
            return View(author);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Post: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Author author) {
            try
            {
                authorRepository.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            var author = authorRepository.Find(id);

            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                authorRepository.Update(id, author);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            var author = authorRepository.Find(id);

            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                authorRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

