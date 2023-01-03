using Foodie.Domain;
using Foodie.Persistance.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foodie.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipieController : ControllerBase
    {
        private readonly FoodieDbContext foodieDbContext;

        public RecipieController(FoodieDbContext foodieDbContext)
        {
            this.foodieDbContext = foodieDbContext;
        }

        [HttpGet(Name = "GetRecipies")]
        public async Task<IEnumerable<Recipie>> GetAll()
        {
            var recipies = await foodieDbContext.Recipies.ToListAsync();

            return recipies;
        }

        [HttpGet("{id}", Name = "GetRecipieById")]
        public async Task<Recipie> GetById(int id)
        {
            var recipie = await foodieDbContext.Recipies.FindAsync(id);

            return recipie;
        }

        [HttpPut("{id}", Name = "UpdateRecipieById")]
        public async Task<Recipie> UpdateRecipieById(int id, string description)
        {
            var recipie = await foodieDbContext.Recipies.FindAsync(id);

            recipie.Description = description;

            await foodieDbContext.SaveChangesAsync();

            return recipie;
        }

        [HttpPost(Name = "AddRecipie")]
        public async Task<Recipie> Add(string name, string description)
        {
            var recipie = new Recipie { Name = name, Description = description };

            await foodieDbContext.AddAsync(recipie);

            await foodieDbContext.SaveChangesAsync();

            return recipie;
        }

        [HttpDelete("{id}", Name = "DeleteRecipie")]
        public async Task<Recipie> Delete(int id)
        {
            var recipie = await foodieDbContext.Recipies.FindAsync(id);

             foodieDbContext.Remove(recipie);

            await foodieDbContext.SaveChangesAsync();

            return recipie;
        }
    }
}