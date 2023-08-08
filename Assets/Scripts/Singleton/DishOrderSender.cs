using Helper;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class DishOrderSender : MonoSingleton<DishOrderSender>
{
    [SerializeField] List<DishRecipe> dishRecipeArray;

    [SerializeField] int maxOrderInWaitQueue;

    [SerializeField] float generateOrderInterval;

    [SerializeField] AudioClip submitSuccessfulSound;

    [SerializeField] AudioClip submitFailSound;

    public event Action<DishRecipe> OnOrderSubmitSuccessful;

    public event Action OnOrderSumbitFail;

    public event Action<DishRecipe> OnGenerateOrder;

    private List<DishRecipe> dishRecipeWaitQueue;

    private Timer generateOrderTimer;

    protected override void Awake() {
        base.Awake();
        dishRecipeWaitQueue = new List<DishRecipe>();
        generateOrderTimer = new Timer();
    }

    private void Start() {
        OnOrderSubmitSuccessful += (empty) => AudioMgr.Instance.PlayOnceSFX(submitSuccessfulSound, 0.4f);
        OnOrderSumbitFail += () => AudioMgr.Instance.PlayOnceSFX(submitFailSound, 0.4f);
    }

    private void Update() {
        if (GameController.Instance.FSM.CurrentStateType != GameState.Playing) return;

        if (generateOrderTimer.IsTimeUp() && dishRecipeWaitQueue.Count < maxOrderInWaitQueue) {
            DishRecipe randDisRecipe = dishRecipeArray[UnityEngine.Random.Range(0, dishRecipeArray.Count)];
            dishRecipeWaitQueue.Add(randDisRecipe);
            OnGenerateOrder?.Invoke(randDisRecipe);
            generateOrderTimer.ReStart(generateOrderInterval);
        }

        if (dishRecipeWaitQueue.Count == maxOrderInWaitQueue) {
            generateOrderTimer.ReStart(generateOrderInterval);
        }
    }

    public bool DeliveryDishOrder(List<KitchenObjectSO> recipe) {
        foreach (var disRecipe in dishRecipeWaitQueue) {
            if (IsRecipeEquivalence(disRecipe.recipe, recipe)) {
                dishRecipeWaitQueue.Remove(disRecipe);
                OnOrderSubmitSuccessful?.Invoke(disRecipe);
                return true;
            }
        }
        OnOrderSumbitFail?.Invoke();
        return false;
    }

    private bool IsRecipeEquivalence(List<KitchenObjectSO> recipeA, List<KitchenObjectSO> recipeB) {
        if (recipeA.Count != recipeB.Count) return false;
        Dictionary<GameObject, int> counter = new Dictionary<GameObject, int>();
        foreach (var kitchenObjectSO in recipeA) {
            if (counter.ContainsKey(kitchenObjectSO.perfab)) {
                counter[kitchenObjectSO.perfab]++;
            }
            else {
                counter.Add(kitchenObjectSO.perfab, 1);
            }
        }
        foreach (var kitchenObjectSO in recipeB) {
            if (!counter.ContainsKey(kitchenObjectSO.perfab)) return false;
            if (counter[kitchenObjectSO.perfab] <= 0) return false;
            counter[kitchenObjectSO.perfab]--;
        }
        return true;
    }
}
