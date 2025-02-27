using ZooAPI.Models;

namespace ZooAPI.Repository;

public interface IAnimalRepository
{
    Task<List<Animal>> GetAnimals();
    Task<Animal?> GetAnimal(int id);
    Task<Animal> AddAnimal(Animal animal);
    Task FeedAnimal(int id, int foodAmount);
    Task DeleteAnimal(int id);
}