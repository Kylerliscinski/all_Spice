

namespace all_Spice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repository;
  private readonly RecipesService _recipesService;

  public IngredientsService(IngredientsRepository repository, RecipesService recipesService)
  {
    _repository = repository;
    _recipesService = recipesService;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
  {
    Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);

    if (recipe == null)
    {
      throw new Exception($"{recipe.Title} was removed");
    }

    if (recipe.CreatorId != userId)
    {
      throw new Exception("You cannot add an ingredient to a recipe that you did not create!");
    }

    Ingredient ingredient = _repository.CreateIngredient(ingredientData);

    return ingredient;
  }

  internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
  {
    List<Ingredient> ingredients = _repository.GetIngredientsForRecipe(recipeId);
    return ingredients;
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _repository.GetIngredientById(ingredientId);

    if (ingredient == null)
    {
      throw new Exception($"Invalid id: {ingredientId}");
    }

    return ingredient;
  }

  internal string DestroyIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);

    Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);

    if (recipe.CreatorId != userId)
    {
      throw new Exception("You cannot add remove an ingredient from a recipe that you did not create!");
    }

    _repository.DestroyIngredient(ingredientId);
    return "Ingredient was deleted!";
  }
}