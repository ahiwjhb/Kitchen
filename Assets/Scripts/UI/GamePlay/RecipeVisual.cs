using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeVisual : MonoBehaviour
{
    [SerializeField] TMP_Text dishRecipeNameText;

    [SerializeField] Transform iconsTSM;

    private DishRecipe dishRecipe;

    public DishRecipe CurrentDishRecipe {
        get => dishRecipe;
        set {
            dishRecipe = value;
            if (dishRecipe == null) return;
            dishRecipeNameText.text = dishRecipe.name;
            foreach(var kitchenObjectSO in dishRecipe.recipe) {
                Image icon = new GameObject().AddComponent<Image>();
                icon.sprite = kitchenObjectSO.sprite;
                icon.transform.SetParent(iconsTSM, false);
            }
        }
    }
}
