using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PolishGamesRanking.DTOs;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.Controllers.API
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetGames()
        {
            var gameDtos = _context.Games.ToList().Select(Mapper.Map<Game, GameDto>);
            return Ok(gameDtos);
        }

        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);
            if (game == null)
                return NotFound();

            return Ok(Mapper.Map<Game, GameDto>(game));
        }

        [HttpPost]
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var game = Mapper.Map<GameDto, Game>(gameDto);
            _context.Games.Add(game);
            _context.SaveChanges();

            gameDto.Id = game.Id;

            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateGame(int id, GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);
            if (gameInDb == null)
                return NotFound();

            Mapper.Map(gameDto, gameInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);
            if (gameInDb == null)
                return NotFound();

            _context.Games.Remove(gameInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
