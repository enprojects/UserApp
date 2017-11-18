using Application.Implemintation;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Srvices
{
    public class CelebsService
    {
        private readonly GenericRepo<Celeb> celebRepository;

        public CelebsService()
        {
            celebRepository = new GenericRepo<Celeb>();
        }


        public IEnumerable<Celeb> GetCelebsList()
        {
            return celebRepository.Get();
        }

        public bool EditCeleb(Celeb celeb)
        {
            return celebRepository.Update(x => x.CelebId == celeb.CelebId, celeb);
        }
        public bool CreateCeleb(Celeb celeb)
        {
            GenerateCelebId(celeb);
            return celebRepository.Add(celeb);
        }
        public bool DeleteCeleb(Celeb celeb)
        {
            return celebRepository.Remove(x=>x.CelebId == celeb.CelebId);
        }

        private void GenerateCelebId(Celeb celeb)
        {
            celeb.CelebId = GetCelebsList().Count() + 1;
        }



    }
}
