import { Account } from "./Account.js";
import { Recipe } from "./Recipe.js";



export class Favorite extends Recipe{
  constructor(data){
    super(data)
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.recipeId = data.recipeId
    this.accountId = new Account(data.accountId)
  }
}