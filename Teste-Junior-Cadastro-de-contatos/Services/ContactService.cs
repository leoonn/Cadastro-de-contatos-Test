using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Junior_Cadastro_de_contatos.Data;
using Teste_Junior_Cadastro_de_contatos.Models;

namespace Teste_Junior_Cadastro_de_contatos.Services
{
    public class ContactService
    {
        private readonly ContatoContext _context;

        public ContactService(ContatoContext context)
        {
            _context = context;
        }

        public async Task<List<Contatos>> FindAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task InsertAsync(Contatos contact)
        {
          await  _context.Contacts.AddAsync(contact);
          await  _context.SaveChangesAsync();
        }
    }
}
