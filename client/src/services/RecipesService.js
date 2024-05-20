import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class RecipesService{
  async createRecipe(recipeData) {
    const response = await api.post('api/recipes', recipeData)
    logger.log("Created recipe", response.data)
    const recipe = new Recipe(response.data)
    AppState.recipes.push(recipe)
    return recipe
  }
  async getRecipeById(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}`)
    logger.log("Got recipe by its id", response.data)
    const recipe = new Recipe(response.data)
    AppState.activeRecipe = recipe
  }
  async getRecipes(){
    const response = await api.get("api/recipes")
    logger.log("Got recipes", response.data)
    const recipes = response.data.map(recipeData => new Recipe(recipeData))
    AppState.recipes = recipes
  }
}

export const recipesService = new RecipesService()