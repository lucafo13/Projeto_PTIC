
using System.Net.Quic;

public class Product : IProduct
{
    public int Id {get; set;}
    public string Nome {get; set;}
    public int Estoque {get; set;}
    public double Preco {get; set;}
    public int Min {get; set;}
    public string Status {get; set;}


    public Product(string nome, int estoque, double preco, int min)
    {
      
        this.Nome = nome;
        this.Estoque = estoque;
        if(min < 0)
        {
            return;
        }
        this.Min = min;
        if(this.Estoque > 0)
        {
            this.Status = "Não Checado";
        }
        else
        {
            return;
        }
        if(preco <= 0)
        {
            return;
        }
        this.Preco = preco;
    }
    public void AddEstoque(int newE)
    {   
        using var context = new AppDbContext();
        var finde = context.Produtos.Find(this.Id);
        if(finde == null)
        {
            return;
        }
        if(newE <= 0)
        {
            return;
        };
        this.Estoque += newE;
        finde.Estoque = this.Estoque;
        context.SaveChanges();
    }
    public void Check()
    {
        using var context = new AppDbContext();
        var InQuest = context.Produtos.Find(this.Id);
       if(InQuest == null)
        {
            return;
        }
        if(this.Estoque <= this.Min || this.Estoque < this.Min + 1)
        {
            this.Status = "Crítico";
       
                        
        } else if(this.Estoque > this.Min && this.Estoque < this.Min + 10)
        {
            this.Status = "Atenção";
        } else
        {
            this.Status = "Ok!";
        }
        InQuest.Status = this.Status;
        InQuest.Estoque = this.Estoque;
        context.SaveChanges();
    }
    public void RemoveStoque(int qnt)
    {
        using var context = new AppDbContext();
        var InQuest = context.Produtos.Find(this.Id);
        if(this.Estoque - qnt <= this.Min || this.Estoque - qnt <= this.Min + 1)
        {
            Console.WriteLine("Está remoção deixará o Estoque em ua quantidade perigosa, crtz?: (S/N)");
            string read = Console.ReadLine() ?? "N";
            switch (read)
            {
                case "S" or "s":
                    if(this.Estoque - qnt <= 0)
                    {
                        Console.WriteLine("Não é possivel");
                        return;
                        
                       
                    }
                    this.Estoque = this.Estoque - qnt;
                    this.Status = "Crítico";
                    break;
                default: 
                    break;
            }
        }
        if(this.Estoque - qnt > this.Min && this.Estoque < this.Min + 10)
        {
            this.Status = "Atenção";
            this.Estoque -= qnt;
        }

        this.Estoque -= qnt;
        this.Status = "Ok!";
        InQuest.Status = this.Status;
        InQuest.Estoque = this.Estoque;
        context.SaveChanges();

        
    }
    public string CheckUp()
    {
        using var context = new AppDbContext();
        var inquest = context.Produtos.Find(this.Id);
        if(inquest == null)
        {
            return "";
        }
        return 
        $"""
            Id: {inquest.Id}
            Nome: {inquest.Nome}
            Preço: R${inquest.Preco}
            Estoque: {inquest.Estoque}
            Status: {inquest.Status}
        """;
    }
    public string checkStatus()
    {
        using var context = new AppDbContext();
        var findit = context.Produtos.Find(this.Id);
        if(findit == null)
        {
            return"";
        }
        return findit.Status;
    }
    
    public string CheckProdutoEstoqye()
    {   
        Console.WriteLine("\n");
        return $"Nome: {this.Nome} \n Estoque: {this.Estoque}";
    }




}