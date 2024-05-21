// import { AppState } from "../AppState.js"
// import { Favorite } from "../models/Favorite.js"
// import { logger } from "../utils/Logger.js"
// import { api } from "./AxiosService.js"



// class FavoritesService{

//   async getFavorites(){
//     const response = await api.get('account/favorites')
//     const favorites = response.data.map(favData => new Favorite(favData))
//     AppState.favorites = favorites
//   }
//   async favorite(recipeId) {
//     const recipeData = {recipeId: recipeId}
//     const response = await api.post('api/favorites', recipeData)
//     const newFavorite = new Favorite(response.data)
//     AppState.favorites.push(newFavorite)
//   }
//   async unFavorite(favoriteId) {
//     const response = await api.delete(`api/favorites/${favoriteId}`)
//     logger.log("unfavorited", response.data)
//     const indexToRemove = AppState.favorites.findIndex(fav => fav.id = favoriteId)
//     if(indexToRemove == -1){
//       logger.error("could not remove favorite")
//       return
//     }
//     AppState.favorites.splice(indexToRemove, 1)
//   }


// }

// export const favoritesService = new FavoritesService()