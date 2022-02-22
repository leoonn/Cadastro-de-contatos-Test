using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Junior_Cadastro_de_contatos.Models;

namespace Teste_Junior_Cadastro_de_contatos.Data
{
    public class ContatoContext : DbContext
    {
       public ContatoContext(DbContextOptions<ContatoContext> options) : base(options)
        {

        }

       public DbSet<Contatos> Contacts { get; set; }
    }
}
