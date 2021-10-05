using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootballPlayerTest;

namespace REST_Service.Managers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersManager : ControllerBase
    {
        private static int _nextID = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer {ID = _nextID++, Name = "Tobias", Price =6,shirtNumber = 13},
            new FootballPlayer {ID = _nextID++, Name = "Freja", Price =3,shirtNumber = 20}
        };
        // GET: api/<FootballPlayersManager>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FootballPlayersManager>/5
        [HttpGet("{id}")]
        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(Data);
        }
        public FootballPlayer GetByID(int id)
        {
            FootballPlayer footballplayer = Data.Find(footballplayer => footballplayer.ID == id);

            if (footballplayer == null)
            {
                throw new ArgumentOutOfRangeException("There is no shirt Number");
            }
            return footballplayer;
        }

        // POST api/<FootballPlayersManager>
        [HttpPost]
        public FootballPlayer Post([FromBody] FootballPlayer footballplayer)
        {
            footballplayer.ID = _nextID++;
            Data.Add(footballplayer);
            return footballplayer;
        }

        internal FootballPlayer add(FootballPlayer value)
        {
            throw new NotImplementedException();
        }

        internal FootballPlayer Update(int id, FootballPlayer value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<FootballPlayersManager>/5
        [HttpPut("{id}")]
        public FootballPlayer Put(int id, [FromBody] FootballPlayer value)
        {
            FootballPlayer footballplayer = Data.Find(footballplayer1 => footballplayer1.ID == id);
            if (footballplayer == null) return null;
            footballplayer.Name = value.Name;
            footballplayer.Price = value.Price;
            footballplayer.shirtNumber = value.shirtNumber;
            return footballplayer;
        }

        // DELETE api/<FootballPlayersManager>/5
        [HttpDelete("{id}")]
        public FootballPlayer Delete(int id)
        {
            FootballPlayer footballplayer = Data.Find(footballplayer => footballplayer.ID == id);
            if (footballplayer == null) return null;
            Data.Remove(footballplayer);
            return footballplayer;
        }
    }
}