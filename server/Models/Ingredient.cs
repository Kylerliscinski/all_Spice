namespace all_Spice.Models;

public class Ingredient : RepoItem<int>
{
  public string Name { get; set; }
  public string Quantity { get; set; }
  public string RecipeId { get; set; }
}