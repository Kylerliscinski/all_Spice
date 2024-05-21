<script setup>
import { computed } from "vue";
import { Recipe } from "../models/Recipe.js";
import { AppState } from "../AppState.js";

const props = defineProps({recipe: {type: Recipe, required: true}})
const userFavorites = computed(() => AppState.userFavorites)
const account = computed(() => AppState.account)

const recipeImg = computed(() => `url(${props.recipe.img})`)

</script>


<template>
    <div class="container recipe-img shadow-lg selectable">
      <div class="row m-0 d-block">
        <div class="d-inline rounded rounded-pill category-tag mt-2">{{ recipe.category }}</div>
        <span role="button" class="col-1 me-2 ">
          <i v-if="account && userFavorites.find(fav => fav.id == recipe.id)" class="mdi mdi-heart text-danger"></i>
          <i v-else class="mdi mdi-heart-outline"></i>
        </span>
        <div data-bs-toggle="modal" data-bs-target="#recipe-modal" class="bg-glass card-bottom selectable">
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
width: relative;
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