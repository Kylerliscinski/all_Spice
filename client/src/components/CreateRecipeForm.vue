<script setup>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";
import { Modal } from "bootstrap";



const categories = [
  "breakfast",
  "lunch",
  "dinner",
  "snack",
  "dessert"
]

const recipeData = ref({
  title: '',
  instructions: '',
  img: '',
  category: ''
})

function resetForm(){
  recipeData.value = {
    title: '',
    instructions: '',
    img: '',
    category: ''
  }
}

async function createRecipe(){
  try {
    await recipesService.createRecipe(recipeData.value)
    resetForm()
    Modal.getOrCreateInstance('#create-recipe-modal').hide()
    Pop.toast("Successfully created recipe", 'success')
  } catch (error) {
    Pop.toast("Could not create recipe", 'error')
    logger.error(error)
  }
}

</script>


<template>
  <div class="container-fluid">
    <form @submit.prevent="createRecipe()" class="row">
      <div class="mb-3 col-6">
        <label for="recipe-title">Title</label>
        <input v-model="recipeData.title" type="text" class="form-control" id="event-title" required minlength="3" maxlength="255">
      </div>
      <div class="mb-3 col-6">
        <label for="recipe-img">Image</label>
        <input v-model="recipeData.img" type="text" class="form-control" id="event-img" required minlength="10" maxlength="1000">
      </div>
      <div class="mb-3 col-6">
        <label for="recipe-instructions">Instructions</label>
        <textarea v-model="recipeData.instructions" id="event-instructions" rows="6" type="text" class="form-control" required minlength="10" maxlength="5000">
        </textarea>
      </div>
      <div class="mb-3 col-6">
        <label for="recipe-category">Category</label>
        <select v-model="recipeData.category" class="form-select" id="event-category" aria-label="Default select example" required>
        <option v-for="category in categories" :key="category" :value="category">
        {{ category }}
        </option>
        </select>
      </div>
      <div class="mb-2 d-flex justify-content-end">
        <button class="btn px-5 text-danger" type="button" @click="resetForm()" >clear form</button>
        <button class="btn btn-primary px-4">Submit <i class="mdi mdi-plus"></i></button>
      </div>
    </form>
  </div>
</template>


<style lang="scss" scoped>

</style>