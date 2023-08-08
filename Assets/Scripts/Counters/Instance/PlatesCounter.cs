using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class PlatesCounter : Counter
{
    [SerializeField] KitchenObjectSO spawnKitchenObject;

    [SerializeField] float spawnInterval = 4f;

    [SerializeField] int plateCountMax = 5;

    private PlatesCounterVisual platesCounterVisual;

    private Timer spawnCDTimer;

    private int plateCount;

    private void Awake() {
        spawnCDTimer = new Timer();
        platesCounterVisual = GetComponentInChildren<PlatesCounterVisual>();
    }

    public int PlateCount {
        get => plateCount;
        set {
            plateCount = value;
            platesCounterVisual.OnPlateCountChange(plateCount);
        }
    }

    public override void Interact(Player player) {
        if(PlateCount > 0 && player.GetBePlacedKitchenObject() == null) {
            KitchenObject.Creat(spawnKitchenObject, player);
            PlateCount--;
        }
    }

    private void Update() {
        if (GameController.Instance.FSM.CurrentStateType != GameState.Playing) return;

        if (spawnCDTimer.IsTimeUp()) {
            if(PlateCount < plateCountMax) {
                spawnCDTimer.ReStart(spawnInterval);
                ++PlateCount;
            }
        }
        if (PlateCount == plateCountMax) {
            spawnCDTimer.ReStart(spawnInterval);
        }
    }
}
