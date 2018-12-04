using AutoMapper;
using RecipeTastic.Dtos;
using RecipeTastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace RecipeTastic.Controllers.Api
{
    public class RecipeBooksController : ApiController
    {
        private ApplicationDbContext _context;
        public RecipeBooksController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetRecipes()
        {
            var recipeBookDtos = _context.RecipeBooks
                .Include(c => c.Cuisine)
                .ToList().Select(Mapper.Map<RecipeBook, RecipeBookDto>);
            return Ok(recipeBookDtos);
        }

        public IHttpActionResult GetRecipe(int id)
        {
            var recipeBook = _context.RecipeBooks.SingleOrDefault(c => c.RecipeBookId == id);
            if (recipeBook == null)
                return NotFound();
            return Ok(Mapper.Map<RecipeBook, RecipeBookDto>(recipeBook));
        }
        [HttpPost]
        public IHttpActionResult CreateRecipe(RecipeBookDto recipeBookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var recipeBook = Mapper.Map<RecipeBookDto, RecipeBook>(recipeBookDto);
            _context.RecipeBooks.Add(recipeBook);
            _context.SaveChanges();
            recipeBookDto.RecipeBookId = recipeBook.RecipeBookId;
            return Created(new Uri(Request.RequestUri + "/" + recipeBook.RecipeBookId), recipeBookDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateRecipe(int id, RecipeBookDto recipeBookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var recipeBookInDb = _context.RecipeBooks.SingleOrDefault(c => c.RecipeBookId == id);
            if (recipeBookInDb == null)
                return NotFound();
            Mapper.Map(recipeBookDto, recipeBookInDb);
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult DeleteRecipe(int id)
        {
            var recipeBookInDb = _context.RecipeBooks.SingleOrDefault(c => c.RecipeBookId == id);
            if (recipeBookInDb == null)
                return NotFound();
            _context.RecipeBooks.Remove(recipeBookInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
