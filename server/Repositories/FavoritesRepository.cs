

namespace all_Spice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
      INSERT INTO
      favorites(recipeId, accountId)
      VALUES(@RecipeId, @AccountId);
      
      SELECT
      favorites.*,
      recipes.*,
      accounts.*
      FROM favorites
      JOIN recipes ON favorites.recipeId = recipes.id
      JOIN accounts ON recipes.creatorId = accounts.id
      WHERE favorites.id = LAST_INSERT_ID();";

    FavoriteRecipe favorites = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>
    (sql, (favorites, recipe, profile) =>
    {
      recipe.FavoriteId = favorites.Id;
      recipe.AccountId = favorites.AccountId;
      recipe.Creator = profile;
      return recipe;
    }, favoriteData).FirstOrDefault();

    return favorites;
  }

  internal List<FavoriteRecipe> GetMyFavoriteRecipes(string userId)
  {
    string sql = @"
      SELECT
      favorites.*,
      recipes.*,
      accounts.*
      FROM favorites
      JOIN recipes ON favorites.recipeId = recipes.id
      JOIN accounts ON recipes.creatorId = accounts.id
      WHERE favorites.accountId = @userId;";

    List<FavoriteRecipe> favoriteRecipes = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>
    (sql, (favorite, recipe, profile) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.AccountId = favorite.AccountId;
      recipe.Creator = profile;
      return recipe;
    }, new { userId }).ToList();

    return favoriteRecipes;
  }
}