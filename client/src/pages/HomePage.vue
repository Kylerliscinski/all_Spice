<script setup>
import Login from "../components/Login.vue";
import Searchbar from "../components/Searchbar.vue";
import RecipeCard from "../components/RecipeCard.vue";
import { computed, onMounted, ref, watch } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";
import ModalWrap from "../components/ModalWrap.vue";
import RecipeModal from "../components/RecipeModal.vue";
import CreateRecipeForm from "../components/CreateRecipeForm.vue";

const recipes = computed(()=> AppState.recipes)
const account = computed(()=> AppState.account)
const favoriteRecipes = computed(() => AppState.favoriteRecipes)
const userRecipes = computed(() => AppState.userRecipes)

const activeFilter = ref('all')

const displayedRecipes = computed(() => {
  if(activeFilter.value == 'favorites')
  {
    return AppState.favoriteRecipes
  }
  else if (activeFilter.value == 'user'){
    return AppState.userRecipes
  }
  return AppState.recipes
})

function updateDisplay(){
  if(activeFilter.value == 'all') activeFilter.value = 'all'
}

async function getFavorites(){
  try {
    await recipesService.getFavorites()
  } catch (error) {
    Pop.toast("Could not get favorites", 'error')
    logger.error(error)
  }
}

function filter(filterName){
  activeFilter.value = filterName
}

watch(recipes, updateDisplay)

watch(account, getFavorites)

async function getRecipes(){
  try {
    await recipesService.getRecipes()
  } catch (error) {
    Pop.toast("Could not get recipes", 'error')
    logger.error(error)
  }
}

async function getOneRecipe(recipe)
{
  AppState.activeRecipe = recipe
}


onMounted(()=>{
  getRecipes()
})

</script>

<template>
  <!-- //SECTION - Large image & router links -->
    <div class="hero-img shadow row">
      <div class="col-12 d-flex justify-content-start">
          <div><Login/></div>
          <div><Searchbar/></div>
      </div>
      <div class="text-white text-center txt-shadow col-12">
        <h1 class="lrg-font">All-Spice</h1>
        <h5>Cherish Your Family <br> And Their Cooking</h5>
      </div>
    </div>

    <!-- //SECTION - Router links -->
    <div class="container bg-white shadow rounded mt-3 mb-2">
      <div class="row text-center justify-content-center mx-0 px-0">
        <div class="col-12 col-md-3">
            <h2 @click="filter('all')" class="px-4 selectable" role="button">Home</h2>
        </div>
        <div class="col-12 col-md-3">
            <h2 @click="filter('user')" class="px-4 selectable" role="button">My Recipes</h2>
        </div>
        <div class="col-12 col-md-3">
            <h2 @click="filter('favorites')" class="px-4 selectable" role="button">Favorites</h2>
        </div>
      </div>
    </div>
    

    <!-- //SECTION - Recipe cards -->
    <div class="row mx-0">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-lg-3 col-md-4 col-sm-6">
        <RecipeCard @click="getOneRecipe(recipe)" :recipe="recipe"/>
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
  border-color: rgba(255, 255, 255, 0);
  box-shadow: 2px 2px 2px black;
  margin-right: 15px;
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
