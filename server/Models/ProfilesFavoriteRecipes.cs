namespace all_Spice.Models;

public class ProfilesFavoriteRecipes : RepoItem<int>
{
  public string AccountId { get; set; }
  public int RecipeId { get; set; }
}