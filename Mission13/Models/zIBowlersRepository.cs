using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlersRepository
    {
        public IQueryable<Team> Teams { get; }
        public IQueryable<Bowler> Bowlers { get;}

        public void SaveBowler(Bowler b);
        public void CreateBowler(Bowler b);
        public void DeleteBowler(Bowler b);
        //public void EditBowler(Bowler b);
    }
}
