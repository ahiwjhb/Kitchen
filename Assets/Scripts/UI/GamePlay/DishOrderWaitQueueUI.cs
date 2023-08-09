using System;
using System.Collections.Generic;
using UnityEngine;

public class DishOrderWaitQueueUI : UIWindow
{
    [SerializeField] GameObject dishRecipeUIPrefab;
    
    [SerializeField] Transform dishRecipesUITSM;

    private List<Tuple<DishRecipe, GameObject>> dishRecipeUIList;

    protected override void Awake() {
        base.Awake();
        dishRecipeUIList = new List<Tuple<DishRecipe, GameObject>>();
        DishOrderSender.Instance.OnGenerateOrder += AddDishRecipeUI;
        DishOrderSender.Instance.OnOrderSubmitSuccessful += RemoveDishRecipeUI;
    }

    private void AddDishRecipeUI(DishRecipe dishRecipe) {
        GameObject dishRecipeUI = Instantiate(dishRecipeUIPrefab);
        dishRecipeUI.transform.SetParent(dishRecipesUITSM);
        dishRecipeUI.GetComponent<RecipeVisual>().CurrentDishRecipe = dishRecipe;
        dishRecipeUIList.Add(new Tuple<DishRecipe, GameObject>(dishRecipe, dishRecipeUI));
    }

    private void RemoveDishRecipeUI(DishRecipe dishRecipe) {
        for(int i = 0; i < dishRecipeUIList.Count; ++i) {
            Tuple<DishRecipe, GameObject> tuple = dishRecipeUIList[i];
            if(tuple.Item1 == dishRecipe) {
                Destroy(tuple.Item2);
                dishRecipeUIList.RemoveAt(i);
                return;
            }
        }
    }
}
