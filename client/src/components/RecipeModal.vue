<script setup>
import { computed } from "vue";
import { AppState } from "../AppState.js";

const recipe = computed(()=>AppState.activeRecipe)

</script>


<template>
  <div v-if="recipe" class="container-fluid">
    <div class="row">
      <div class="col-5 recipe-img">
      
      </div>

      <div class="col-7">
        <div class="container p-4">
          <h2 class="text-color">{{ recipe.title }}</h2>
          <h4 class="category-tag rounded-pill">{{ recipe.category }}</h4>
          <div class="row">
            <div class="col-6">
              <div class="card">
                <h2 class="text-center bg-green card-header">Instructions</h2>
                <div class="card-body bg-lightGreen">
                  <p>{{ recipe.instructions }}</p>
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