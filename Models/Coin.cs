using System.ComponentModel.DataAnnotations;
namespace coinsapi.Models;

public class Coin
{
    [Key]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public float Price { get; set; }
    public string? Img { get; set; }
    public string? Symbol { get; set; }
    public int Rank { get; set; }
    public bool IsNew { get; set; }
    public bool IsActive { get; set; }
    public string? Type { get; set; }

}