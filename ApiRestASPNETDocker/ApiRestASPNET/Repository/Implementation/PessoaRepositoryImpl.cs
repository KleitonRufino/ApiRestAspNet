
using ApiRestASPNET.Model;
using ApiRestASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRestASPNET.Repository.Implementation
{
    public class PessoaRepositoryImpl : IPessoaRepository
    {

        private MySQLContext _context;

        public PessoaRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return pessoa;
        }

        public void Delete(long id)
        {
            var result = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Pessoas.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Pessoa Disable(long id)
        {
           return null;
        }

        public bool Exists(long id)
        {
            return _context.Pessoas.Any(p => p.Id.Equals(id));
        }

        public List<Pessoa> FindAll(String order, int page, int size)
        {
            if("DESC".Equals(order.ToUpper()))
                return _context.Pessoas.Skip(size * page).Take(size).OrderByDescending(a => a.FirstName).OrderByDescending(a => a.LastName).ToList();
            return _context.Pessoas.Skip(size * page).Take(size).OrderBy(a => a.FirstName).OrderBy(a => a.LastName).ToList(); 
        }

        public Pessoa FindById(long id)
        {
            return _context.Pessoas.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Pessoa> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                return _context.Pessoas.Where(p => p.FirstName.Contains(firstName) || p.LastName.Contains(lastName)).ToList();
            else if(!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return _context.Pessoas.Where(p => p.FirstName.Contains(firstName)).ToList();
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                return _context.Pessoas.Where(p => p.LastName.Contains(lastName)).ToList();
            else
                return null;
        }

        public Pessoa Update(Pessoa pessoa)
        {
            var result = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(pessoa.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return pessoa; ;
        }
    }
}
