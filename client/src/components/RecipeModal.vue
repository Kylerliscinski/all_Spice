<script setup>
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import { useRoute } from "vue-router";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";


const recipes = computed(()=>AppState.activeRecipe)
const route = useRoute()

async function getRecipeById(){
  try {
    await recipesService.getRecipeById(route.params.recipeId)
  } catch (error) {
    Pop.toast("Could not get the recipe by its id", 'error')
    logger.error(error)
  }
}

//FIXME - Needs to wait for click before getting recipe
// onMounted(()=>{
//   getRecipeById()
// })

</script>


<template>
  <div class="container">
    <div class="row">
      <div class="col-3">
        <img :src="recipes?.img" alt="img">
      </div>

      <div class="col-9">
        <h1>{{ recipes?.title }}</h1>
        <h4 class="category-tag">{{ recipes?.category }}</h4>
        <div class="row">
          <div class="col-6 card">
            <div class="card-header">
              Recipe Steps
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>

.category-tag{
  background-color: rgba(105, 97, 97, 0.732);
  width: fit-content;
  font-size: larger;
  font-weight: 500;
  color: white;
  text-transform: capitalize;
  padding-left: 8px;
  padding-right: 8px;
}

</style>