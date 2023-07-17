using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishRecipeList : ScriptableObject
{
    [SerializeField] List<DishRecipe> dishRecipeArray;



    [Serializable]
    public class DishRecipe {
        public string name;

        public List<KitchenObjectSO> recipe;
    }
}
