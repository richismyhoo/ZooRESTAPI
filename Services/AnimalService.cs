using ZooAPI.Models;
using ZooAPI.Repository;

namespace ZooAPI.Services;

public class AnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<List<Animal>> GetAnimals()
    {
        return await _animalRepository.GetAnimals();
    }

    public async Task<Animal> GetAnimal(int id)
    {
        var animal = await _animalRepository.GetAnimal(id);
        if (animal != null)
            return animal;
        else
            throw new Exception("Animal not found");
    }

    public async Task<Animal> AddAnimal(Animal animal)
    {
        return await _animalRepository.AddAnimal(animal);
    }

    public async Task FeedAnimal(int id, int foodAmount)
    {
        if (foodAmount > 100)
            foodAmount = 100;
                
        await _animalRepository.FeedAnimal(id, foodAmount);
    }

    public async Task DeleteAnimal(int id)
    {
        await _animalRepository.DeleteAnimal(id);
    }
}