﻿using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Person> Create(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<Person> Delete(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<ICollection<Person>> GetAll()
        {
            return await _db.People.ToListAsync();
        }

        public async Task<int> GetByDocument(string document)
        {
            return (await _db.People.FirstOrDefaultAsync(p => p.Document == document))?.Id ?? 0;
        }

        public async Task<Person> GetById(int id)
        {
            return await _db.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Person> Update(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
            return person;
        }
    }
}
