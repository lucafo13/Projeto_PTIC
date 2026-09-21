using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Control
{
    
    public class ProductController

    {
        List<Product> Produtos = new List<Product>();

        public async void Cadastrar(string nome, int estoque, double preco, int min)
        {
            using var context = new AppDbContext();
            Product produto = new Product(nome, estoque, preco, min);
            context.Produtos.Add(produto);
            context.SaveChanges();
            Console.WriteLine("Aguarde...");
            Thread.Sleep(500);
            Produtos.Add(produto);
        
        }
        public void Inicio()
        {
            using var context = new AppDbContext();
            
            var all = context.Produtos.ToList();
            foreach(var aura in all)
            {
                Console.WriteLine($"""
                    Id: {aura.Id}
                    Nome: {aura.Nome}
                    Preço: {aura.Preco}
                    Estoque: {aura.Estoque}
                    minimo: {aura.Min}                    
                    Status: {aura.Status}
                """);
                Console.WriteLine("\n");
            }
           
            Console.WriteLine("Escreva o Id do produto desejado");
            int search = Convert.ToInt32(Console.ReadLine() ?? "");

            var finde = context.Produtos.Find(search);
            if(finde == null)
            {
                Console.WriteLine("Errou");
                return;
            }

            var focus = finde;
            
            bool continueIt = true;
            while (continueIt)
            {
                focus.Check();
                Console.WriteLine(focus.CheckUp());
                Console.Write("O que deseja fzr?\n");
                
                Console.WriteLine("""
                        1 - Adicionar Estoque;
                        2 - Remover Estoque;
                        3 - Checar status;
                        4 - ver propriedades;
                        5 - RageQuit;
                """);
                int resposta = int.Parse(Console.ReadLine() ?? "5");

                switch (resposta)
                {
                    case 1:
                        Console.WriteLine("Digite a quantia: ");
                        int qntA = int.Parse(Console.ReadLine() ??"0");
                        focus.AddEstoque(qntA);
                        focus.Check();
                        Console.WriteLine(focus.CheckUp());
                        break;
                    case 2:
                        Console.WriteLine("Digite a quantia: ");
                        int qntR = int.Parse(Console.ReadLine() ?? "0");
                        focus.RemoveStoque(qntR);
                        focus.Check();
                        Console.WriteLine(focus.CheckUp());
                        break;
                    case 3:
                        Console.WriteLine(focus.checkStatus());
                        break;
                    case 4:
                        foreach(var item in Produtos)
                        {
                            Console.WriteLine(item.CheckUp() + "\n");
                        }
                        Console.WriteLine(focus.CheckUp());
                        break;
                    case 5:
                        continueIt = false;
                        break;
                    
                }

        
                Console.WriteLine("Deseja Continuar? (S/N)");
                string res = Console.ReadLine() ??"N";

                switch (res)
                {
                    case "S" or "s":
                        break;
                    default:
                        continueIt = false;
                        Console.WriteLine("Cadastrar outro produto?(S/N) \n");
                        string res2 = Console.ReadLine() ??"N";
                        if(res2 == "S" || res2 == "s")
                        {
                            InicioCad();
                        }
                        else
                        {
                         break;
                         return;   
                        }
                        break;


                }
                Console.Clear();
            }
        }
        public void InicioCad()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar novo produto: ");
            Console.WriteLine("Cadastre um produto: \n");
            Console.WriteLine("nome: ");
            string nome = Console.ReadLine() ?? "";
            Console.WriteLine("Preço: ");
            double preco = double.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("estoque: ");
            int estoque = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Mínimo: ");
            int Min = int.Parse(Console.ReadLine() ?? "");
            Cadastrar(nome, estoque,preco, Min);;
            Inicio();

        }
    }
}



