

namespace all_Spice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repository;

  public FavoritesService(FavoritesRepository repository)
  {
    _repository = repository;
  }

  internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
  {
    FavoriteRecipe favorite = _repository.CreateFavorite(favoriteData);
    return favorite;
  }

  internal List<FavoriteRecipe> GetMyFavoriteRecipes(string userId)
  {
    List<FavoriteRecipe> favoriteRecipes = _repository.GetMyFavoriteRecipes(userId);
    return favoriteRecipes;
  }
}