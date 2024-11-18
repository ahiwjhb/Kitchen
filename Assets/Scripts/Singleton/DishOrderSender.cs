using Helper;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using static GameController;

public class DishOrderSender : NetBehaviourSingleton<DishOrderSender>
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

    private NetworkList<int> networkDishRecipeId;

    private Timer generateOrderTimer;

    protected override void Awake() {
        base.Awake();
        dishRecipeWaitQueue = new List<DishRecipe>();
        networkDishRecipeId = new NetworkList<int>();
        generateOrderTimer = new Timer();
    }

    private void Start() {
        OnOrderSubmitSuccessful += (empty) => {
            AudioMgr.Instance.PlayOnceSFX(submitSuccessfulSound, 0.4f);
        };

        OnOrderSumbitFail += () => {
            AudioMgr.Instance.PlayOnceSFX(submitFailSound, 0.4f);
        };
    }

    public override void OnNetworkSpawn() {
        base.OnNetworkSpawn();
        foreach (var dishRecipeId in networkDishRecipeId) {
            var dishRecipe = GetDishRecipeById(dishRecipeId);
            dishRecipeWaitQueue.Add(dishRecipe);
            OnGenerateOrder?.Invoke(dishRecipe);
        }
    }

    private void Update() {
        if (!IsServer || GameController.Instance.FSM.CurrentStateType != GameState.Playing) return;

        if (generateOrderTimer.IsTimeUp() && dishRecipeWaitQueue.Count < maxOrderInWaitQueue) {
            int randIndex = UnityEngine.Random.Range(0, dishRecipeArray.Count);
            networkDishRecipeId.Add(dishRecipeArray[randIndex].id);
            GenerateDishOrderClientRpc(randIndex);
            generateOrderTimer.ReStart(generateOrderInterval);
        }

        if (dishRecipeWaitQueue.Count == maxOrderInWaitQueue) {
            generateOrderTimer.ReStart(generateOrderInterval);
        }
    }

    [ClientRpc]
    private void GenerateDishOrderClientRpc(int dishOrderIndex) {
        DishRecipe randDisRecipe = dishRecipeArray[dishOrderIndex];
        dishRecipeWaitQueue.Add(randDisRecipe);
        OnGenerateOrder?.Invoke(randDisRecipe);
    } 

    public void DeliveryDishOrder(List<KitchenObjectSO> recipe) {
        int[] recipeIdArray = new int[recipe.Count];
        for (int i = 0; i < recipe.Count; ++i) {
            recipeIdArray[i] = recipe[i].id;
        }
        DeliveryDishOrderServerRpc(recipeIdArray);
    }

    [ServerRpc(RequireOwnership = false)]
    private void DeliveryDishOrderServerRpc(int[] deliverRecipeIdArray) {
        for (int i = 0; i < dishRecipeWaitQueue.Count; ++i) {
            var dishRecipe = dishRecipeWaitQueue[i];
            if (IsRecipeEquivalence(dishRecipe.GetRecipeIdArray(), deliverRecipeIdArray)) {
                DeliveryDishOrderSuccessfulClientRpc(i);
                networkDishRecipeId.Remove(i);
                return;
            }
        }
        DeliveryDishOrderFailClientRpc();
    }

    private bool IsRecipeEquivalence(int[] recipeA, int[] recipeB) {
        if (recipeA.Length != recipeB.Length) return false;

        Dictionary<int, int> counter = new Dictionary<int, int>();
        foreach (var recipeId in recipeA) {
            if (counter.ContainsKey(recipeId)) {
                counter[recipeId]++;
            }
            else {
                counter.Add(recipeId, 1);
            }
        }

        foreach (var recipeId in recipeB) {
            if (!counter.TryGetValue(recipeId, out int cnt) || cnt <= 0) {
                return false;
            }
            counter[recipeId]--;
        }

        return true;
    }

    [ClientRpc]
    private void DeliveryDishOrderSuccessfulClientRpc(int dishRecipeIndex) {
        var dishRecipe = dishRecipeWaitQueue[dishRecipeIndex];
        OnOrderSubmitSuccessful?.Invoke(dishRecipe);
        dishRecipeWaitQueue.Remove(dishRecipe);
    }

    [ClientRpc]
    private void DeliveryDishOrderFailClientRpc() {
        OnOrderSumbitFail?.Invoke();
    }

    private DishRecipe GetDishRecipeById(int dishRecipeId) {
        foreach(var dishRecipe in dishRecipeArray) {
            if(dishRecipe.id == dishRecipeId) {
                return dishRecipe;
            }
        }
        return null;
    }
}
