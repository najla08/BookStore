using System;

namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {

        IList<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author{Id=1, FullName="Najla Al-Taleb"},
                new Author{Id=2, FullName="Rashed Mohammed"},
                new Author{Id=3, FullName="Saud Mohammed"}
            };
        }

        public void Add(Author entity)
        {
            entity.Id=authors.Max(a =>a.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;
        }
    }
}

