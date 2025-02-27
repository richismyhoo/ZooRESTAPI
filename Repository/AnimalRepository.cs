using Microsoft.EntityFrameworkCore;
using ZooAPI.Context;
using ZooAPI.Models;

namespace ZooAPI.Repository;

public class AnimalRepository : IAnimalRepository
{
    private readonly ApplicationContext _context;

    public AnimalRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Animal>> GetAnimals()
    {
        return await _context.Animals.ToListAsync();
    }

    public async Task<Animal> GetAnimal(int id)
    {
        return await _context.Animals.FindAsync(id);
    }

    public async Task<Animal> AddAnimal(Animal animal)
    {
        Random random = new Random();
        int randomEnergy = random.Next(1, 100);
        animal.Energy = randomEnergy;
        
        await _context.Animals.AddAsync(animal);
        await _context.SaveChangesAsync();
        return animal;
    }

    public async Task FeedAnimal(int id, int foodAmount)
    {
        var animal = await _context.Animals.FindAsync(id);

        if (animal.Energy + foodAmount > 100)
            animal.Energy = 100;
        else
            animal.Energy += foodAmount;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAnimal(int id)
    {
        var animal = await _context.Animals.FindAsync(id);
        _context.Animals.Remove(animal);
        await _context.SaveChangesAsync();
    }
}