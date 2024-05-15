


namespace all_Spice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repository;
  public RecipesService(RecipesRepository repository)
  {
    _repository = repository;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repository.CreateRecipe(recipeData);
    return recipe;
  }


  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repository.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repository.GetRecipeById(recipeId);
    if (recipe == null)
    {
      throw new Exception($"Invalid id: {recipeId}");
    }
    return recipe;
  }

  internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeData)
  {
    Recipe recipeToUpdate = GetRecipeById(recipeId);
    if (recipeToUpdate.CreatorId != userId)
    {
      throw new Exception("You cannot edit this recipe, it does not belong to you!");
    }

    recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
    recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;

    Recipe updatedRecipe = _repository.UpdateRecipe(recipeToUpdate);
    return updatedRecipe;
  }

  internal string DestroyRecipe(int recipeId, string userId)
  {
    Recipe recipeToDestroy = GetRecipeById(recipeId);
    if (recipeToDestroy.CreatorId != userId)
    {
      throw new Exception("You cannot delete this recipe, you are not the creator!");
    }
    _repository.DestroyRecipe(recipeId);
    return $"{recipeToDestroy.Title} has been removed";
  }
}