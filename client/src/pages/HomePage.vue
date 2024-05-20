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
import CreateRecipeForm from "../components/CreateRecipeForm.vue";

const recipes = computed(()=> AppState.recipes)
const account = computed(()=> AppState.account)

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
      <div class="text-white text-center txt-shadow col-12">
        <h1 class="lrg-font">All-Spice</h1>
        <h5>Cherish Your Family <br> And Their Cooking</h5>
      </div>
    </div>
    <!-- //FIXME - Make container overlap with hero img & Make selectable tags -->
    <div class="container bg-white shadow rounded">
      <div class="d-flex justify-content-center">
        <RouterLink :to="{name: 'Home'}">
          <h2 class="px-4 selectable" role="button">Home</h2>
        </RouterLink>
    <!-- //FIXME - Add correct route -->
        <RouterLink :to="{name: 'About'}">
          <h2 class="px-4 selectable" role="button">My Recipes</h2>
        </RouterLink>
    <!-- //FIXME - Add correct route -->
        <RouterLink :to="{name: 'Home'}">
          <h2 class="px-4 selectable" role="button">Favorites</h2>
        </RouterLink>
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
    
    <!-- //SECTION - Create Recipe Button & modal -->
    <button v-if="account" data-bs-toggle="modal" data-bs-target="#create-recipe-modal" class="add-button"><i class="mdi mdi-plus"></i></button>
    <ModalWrap modalId="create-recipe-modal">
      <CreateRecipeForm/>
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

.add-button{
  background-color: rgba(82, 163, 100, 0.925);
  font-size: xx-large;
  font-weight: 900;
  color: white;
  height: 60px;
  aspect-ratio: 1/1;
  border-radius: 50em;
  position: sticky;
  bottom: 2dvh;
  left: 100%;
  margin-right: 2dvh;
  border-color: rgba(255, 255, 255, 0);
  box-shadow: 2px 2px 2px black;
}

button:hover{
  color: black;
  transform: rotate(360deg);
  transition: .5s;
  box-shadow: none;
}

div a{
  color:  rgba(82, 163, 100);
}

.txt-shadow{
  text-shadow: 2px 2px 2px black;
}

.lrg-font{
  font-size: 60px;
}
</style>
