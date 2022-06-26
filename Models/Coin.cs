namespace coinsapi.Models;

public class Coin
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public float Price { get; set; }
    public string? Icon { get; set; }

}