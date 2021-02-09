using System;
using System.Collections.Generic;
using GenericRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository
{
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IRepository<Person> personRepository;

        public ExampleController(IRepository<Person> personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet]
        public IEnumerable<Person> GetAllPersons() => personRepository.GetAll();

        [HttpGet]
        public IEnumerable<Person> GetPersonsOver30() => personRepository.GetBy(person => person.Age > 30);

        [HttpGet]
        public Person GetPersonById(Guid bookId) => personRepository.GetById(bookId);

        [HttpPost]
        public void AddPerson(Person book) => personRepository.Insert(book);

        [HttpDelete]
        public void DeletePerson(Guid personId) => personRepository.Delete(personId);
    }
}