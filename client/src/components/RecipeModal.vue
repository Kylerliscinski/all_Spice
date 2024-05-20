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
  <div class="container-fluid">
    <div class="row">
      <div class="col-5 recipe-img">
      
      </div>

      <div class="col-7">
        <div class="container p-4">
          <h2 class="text-color">Good Soup</h2>
          <h4 class="category-tag rounded-pill">Dinner</h4>
          <div class="row">
            <div class="col-6">
              <div class="card">
                <h2 class="text-center bg-green card-header">Recipe Steps</h2>
                <div class="card-body bg-lightGreen">
                  <p>1. In a Dutch oven, cook bacon over medium heat until crisp. Remove to paper towels with a slotted spoon; drain, reserving 1 tablespoon drippings. Saute onion in drippings until tender. Add garlic; cook 1 minute longer.2. Stir in the broth, pumpkin, salt, nutmeg and pepper. Bring to a boil. Reduce heat; simmer, uncovered, for 10 minutes. Cool slightly.
                  3. In a blender, process soup in batches until smooth. Return all to pan. Stir in cream; heat through. Add cheese; stir until melted. Sprinkle each serving with parsley, bacon and, if desired, additional cheese.  
                </p>
                <form>
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Add step...">
                    <button class="btn bg-green" type="submit"><i class="mdi mdi-plus"></i></button>
                  </div>
                </form>
                </div>
              </div>
            </div>
            <div class="col-6">
              <div class="card">
                <h2 class="text-center bg-green card-header">Ingredients</h2>
                <div class="card-body bg-lightGreen">
                  <p>4 bacon strips, chopped
                    1 medium onion, chopped
                    3 garlic cloves, minced
                    6 cups chicken broth
                    1 can (29 ounces) solid-pack pumpkin
                    1/2 teaspoon salt
                    1/4 teaspoon ground nutmeg
                    1/8 teaspoon pepper
                    1 cup heavy whipping cream
                    1 cup shredded Gouda cheese
                    2 tablespoons minced fresh parsley
                    Additional shredded Gouda cheese, optional
                  </p>
                  <form>
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Add ingredient...">
                    <button class="btn bg-green" type="submit"><i class="mdi mdi-plus"></i></button>
                  </div>
                </form>
                </div>
              </div>
            </div>
          </div>
        </div>
        <h5 class="float-end text-secondary">Published by Kyler Liscinski</h5>

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

.recipe-img{
  background-image: url(https://images.unsplash.com/photo-1476718406336-bb5a9690ee2a?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-position: center;
  background-size: cover;
  height: 100dvh;
}

.text-color{
  color: rgb(82, 163, 100);
}

.bg-green{
  background-color: rgb(82, 163, 100);
}

.bg-lightGreen{
  background-color: rgb(222, 231, 224);
}
</style>