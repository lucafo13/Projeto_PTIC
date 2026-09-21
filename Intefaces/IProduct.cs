
public interface IProduct
{   
    public int Id {get; set;}
    public string Nome {get; set;}
    public int Estoque {get; set;}
    public double Preco {get; set;}
    public string Status {get; set;}

    public int Min {get; set;}

    public void AddEstoque(int newE);    
    public void RemoveStoque(int qnt);

    public void Check();
    public string CheckUp();


}
