

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

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);

    if (recipe == null)
    {
      throw new Exception($"{recipe.Title} was removed");
    }

    Ingredient ingredient = _repository.CreateIngredient(ingredientData);

    return ingredient;
  }

  internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
  {
    List<Ingredient> ingredients = _repository.GetIngredientsForRecipe(recipeId);
    return ingredients;
  }

  internal Ingredient GetIngredientById
}