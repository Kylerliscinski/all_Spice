<script setup>
import Login from "../components/Login.vue";
import Searchbar from "../components/Searchbar.vue";
import RecipeCard from "../components/RecipeCard.vue";
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";
import ModalWrap from "../components/ModalWrap.vue";
import RecipeModal from "../components/RecipeModal.vue";

const recipes = computed(()=>AppState.recipes)

async function getRecipes(){
  try {
    await recipesService.getRecipes()
  } catch (error) {
    Pop.toast("Could not get recipes", 'error')
    logger.error(error)
  }
}

onMounted(()=>{
  getRecipes()
})

</script>

<template>
  <!-- //SECTION - Large image & router links -->
    <div class="hero-img shadow row">
      <div class="col-12 d-flex justify-content-end">
          <div><Searchbar/></div>
          <div><Login/></div>
      </div>
      <div class="text-white text-center shadow col-12">
        <h1>All-Spice</h1>
        <h5>Cherish Your Family <br> And Their Cooking</h5>
      </div>
    </div>
    <!-- //FIXME - Make container overlap with hero img & Make selectable tags -->
    <div class="container bg-white shadow rounded">
      <div class=" d-flex justify-content-center">
        <h2 class="px-4">Home</h2>
        <h2 class="px-4">My Recipes</h2>
        <h2 class="px-4">Favorites</h2>
      </div>
    </div>

    <!-- //SECTION - Recipe cards -->
    <div class="row m-0 g-3">
      <div v-for="recipe in recipes" :key="recipe.id" data-bs-toggle="modal" data-bs-target="#recipe-modal" class="col-12 col-lg-4 col-sm-6">
        <RecipeCard :recipe="recipe"/>
      </div>
    </div>
    <ModalWrap modalId="recipe-modal">
      <RecipeModal/>
    </ModalWrap>
    
</template>

<style scoped lang="scss">

.hero-img{
background-image: url(https://images.unsplash.com/photo-1523294587484-bae6cc870010?q=80&w=2004&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
background-position: center;
background-size: cover;
min-height: 40vh;
margin-top: 35px;
margin-left: 35px;
margin-right: 35px;
border-radius: 10px;
}
</style>
