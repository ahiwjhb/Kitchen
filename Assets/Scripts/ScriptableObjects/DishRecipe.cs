using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu()]
public class DishRecipe : Item
{
    public new string name;

    public List<KitchenObjectSO> recipe;

    public int[] GetRecipeIdArray() {
        int[] dishRecipeIdArray = new int[recipe.Count];
        for(int i = 0; i < recipe.Count; ++i) {
            dishRecipeIdArray[i] = recipe[i].id;
        }
        return dishRecipeIdArray;
    }
}
