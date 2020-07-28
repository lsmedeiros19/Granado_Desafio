using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;
using PetCare.Repository.Abstraction;

namespace PetCare.Web.Controllers.API.v1
{
    public class AnimalController : BaseAPIController
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAnimalAsync([FromBody] List<Animal> animais)
        {
            await _animalService.CadastrarAnimaisAsync(animais);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AlterarAnimal([FromBody] Animal animal, [FromRoute] int id)
        {
            animal.Id = id;

            _animalService.AlterarAnimal(animal);

            return Ok();
        }

        //[HttpGet]
        //public IActionResult ObterAnimalPorId(int id)
        //{
        //    Animal animal = _animalService.ObterAnimalPorId(id);

        //    return animal;
        //}


    }
}
