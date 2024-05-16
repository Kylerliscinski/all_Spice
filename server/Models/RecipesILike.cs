namespace all_Spice.Models;

public class RecipesILike : Recipe
{
  public int FavoriteId { get; set; }
  public string AccountId { get; set; }
}