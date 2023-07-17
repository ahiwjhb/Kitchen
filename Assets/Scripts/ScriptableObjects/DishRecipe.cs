using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DishRecipe : ScriptableObject
{
    public new string name;

    public List<KitchenObjectSO> recipe;
}
