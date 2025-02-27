using Microsoft.AspNetCore.Mvc;
using ZooAPI.Models;
using ZooAPI.Services;

namespace ZooAPI.Controllers;

[ApiController]
[Route("api/animals")]

public class AnimalController : ControllerBase
{
    private readonly AnimalService _animalService;

    public AnimalController(AnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAnimals()
    {
        var animals = await _animalService.GetAnimals();
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimal([FromRoute] int id)
    {
        var animal = await _animalService.GetAnimal(id);

        if (animal != null)
            return Ok(animal);
        else
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddAnimal(Animal animal)
    {
        try
        {
            await _animalService.AddAnimal(animal);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}/feed")]
    public async Task<IActionResult> UpdateAnimal([FromRoute] int id, [FromBody] int foodAmount)
    {
        try
        {
            await _animalService.FeedAnimal(id, foodAmount);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
    {
        try
        {
            _animalService.DeleteAnimal(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return StatusCode(204);
    }
}