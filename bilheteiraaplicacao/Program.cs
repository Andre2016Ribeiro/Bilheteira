using System;
using Microsoft.EntityFrameworkCore;
using Bilheteira;
using bilheteiraaplicacao.Data;
using System.Threading.Tasks;
using System.Linq;
namespace bilheteiraaplicacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BilhContexto bd= new BilhContexto();
            
            foreach (var p in bd.Bilhetes.Include(Bilhete => Bilhete.Espetaculo).ThenInclude(Espetaculo => Espetaculo.TipoEspetaculo))
            {
                Console.WriteLine($"Id: {p.Id}, Nome: {p.NumBilhetes}, E TEM A SUBCATEGORIA: {p.Espetaculo.Name} E TEM A CATEGORIA {p.Espetaculo.TipoEspetaculo.Tipo}");
            }
            foreach (var item in bd.Salas.Include(Sala => Sala.Bilhetes).ThenInclude(Bilhete => Bilhete.Vendas))
            {
                Console.WriteLine($"Categoria: Id: {item.Nome}");
                Console.WriteLine($"\tTem {item.Bilhetes.Count} subcategorias");

                //Listar as subcategorias do item corrente:
                foreach (var s in item.Bilhetes)
                {
                    Console.WriteLine($"\t\tId: {s.Id}, Nome: {s.Preco}");
                    Console.WriteLine($"\t\t\tTem {s.Vendas.Count} produtos");

                    foreach (var p in s.Vendas)
                    {
                        Console.WriteLine($"\t\t\t\tId: {p.Id}, Nome: {p.UtilizadorID}");
                    }
                }
            }
        }
    }
}
