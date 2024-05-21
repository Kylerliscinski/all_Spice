import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class RecipesService{
  async getFavorites() {
    const response = await api.get('account/favorites')
    const favorites = response.data.map(favData => new Favorite(favData))

    const userFavorites = favorites.filter(favorite => favorite.creatorId == AppState.account.id)
    AppState.userFavorites = userFavorites

    const userFavoriteRecipes = userFavorites.map(favRecipeData => new Recipe(favRecipeData))
    AppState.favoriteRecipes = userFavoriteRecipes

    const userRecipes = AppState.recipes.filter(recipe => recipe.creator.id == AppState.account.id)
    AppState.userRecipes = userRecipes
  }
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