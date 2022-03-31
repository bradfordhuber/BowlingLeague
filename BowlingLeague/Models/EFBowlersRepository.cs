using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlingDbContext context { get; set; } //gets the data

        //constructor 
        public EFBowlersRepository(BowlingDbContext temp) //gets data from variable above
        {
            context = temp;
        }
        public IQueryable<Bowler> Bowlers => context.Bowlers;

        //methods for saving adding and updated books

        public void SaveBowler(Bowler b)
        {
            context.SaveChanges();
        }

        public void CreateBowler(Bowler b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
