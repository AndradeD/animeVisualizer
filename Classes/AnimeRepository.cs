using System.Collections.Generic;
using Animes.Interfaces;

namespace Animes.Classes
{
    public class AnimeRepository : IRepository<Anime>
    {
        private List<Anime> listaAnimes = new List<Anime>();
        public void Delete(int id)
        {
            Anime entity = GetByID(id);
            listaAnimes.Remove(entity);
        }

        public Anime GetByID(int id)
        {
            return listaAnimes.Find(anime => anime.Id == id);
        }

        public void Insert(Anime entity)
        {
            listaAnimes.Add(entity);
        }

        public int NextId()
        {
            return listaAnimes.Count+1;
        }

        public List<Anime> ReturnAll()
        {
            return listaAnimes;
        }

        public void Update(int id, Anime entity)
        {
            int index = listaAnimes.FindIndex(a => a.Id == id);
            listaAnimes[index] = entity;
        }
    }
}