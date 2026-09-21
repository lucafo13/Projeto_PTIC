using System;
using System.Collections.Generic;
using System.Linq;
using Control;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Cadastre um produto: ");
        Console.WriteLine("nome: ");
        string nome = Console.ReadLine() ?? "";
        Console.WriteLine("Preço: ");
        double preco = double.Parse(Console.ReadLine());
        Console.WriteLine("estoque: ");
        int estoque = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Mínimo: ");
        int Min = int.Parse(Console.ReadLine() ?? "");


        ProductController produto = new ProductController();
        produto.Cadastrar(nome,  estoque, preco, Min);
        produto.Inicio();

    }
}