namespace all_Spice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _ingredientsRepository;

  public IngredientsService(IngredientsRepository ingredientsRepository)
  {
    _ingredientsRepository = ingredientsRepository;
  }
}