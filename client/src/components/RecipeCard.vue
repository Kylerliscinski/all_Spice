<script setup>
import { computed } from "vue";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";

const props = defineProps({recipe: {type: Recipe, required: true}})

const recipeImg = computed(()=> `url(${props.recipe.img})`)


const route = useRoute()

async function getRecipeById(){
  try {
    await recipesService.getRecipeById(route.params.recipeId)
  } catch (error) {
    Pop.toast("Could not get the recipe by its id", 'error')
    logger.error(error)
  }
}
</script>


<template>
    <div class="container recipe-img shadow-lg selectable">
      <div class="row m-0 d-block">
        <div class="d-inline rounded rounded-pill category-tag mt-2">{{ recipe.category }}</div>
        <span class="d-inline"><i class="mdi mdi-heart-outline fs-3" role="button"></i></span>
        <div class="bg-glass card-bottom">
          <div>{{ recipe.title }}</div>
        </div>
      </div>
    </div>
</template>


<style lang="scss" scoped>

.recipe-img{
background-image: v-bind(recipeImg);
background-position: center;
background-size: cover;
height: 50vh;
width: 48vh;
margin-top: 10px;
padding-left: 10px;
padding-right: 10px;
padding-top: 5px;
border-radius: 5px;
}

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

//Fixme - Fix the margin-top for the title
.bg-glass{
  background-color: rgba(105, 97, 97, 0.732);
  width: max-content;
  font-size: larger;
  font-weight: 500;
  color: white;
  border-radius: 3px;
  padding-left: 5px;
  padding-right: 5px;
  padding-bottom: 5px;
}

.card-bottom{
  position:absolute;
  bottom: 8px;
}

</style>