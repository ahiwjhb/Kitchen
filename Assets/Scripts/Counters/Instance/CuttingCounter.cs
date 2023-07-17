using System;
using UnityEngine;
using static CuttingFormulaList;

public class CuttingCounter : CanPlacedKitchenObjectCounter, ISecondaryInteractable
{
    [SerializeField] CuttingFormulaList cuttingFormulaList;

    public event EventHandler OnCutNumberChange;

    private CuttingFormula cuttingFormula;

    private int cuttingCount;

    private int CuttingCount { 
        get => cuttingCount; 
        set {
            cuttingCount = value;
            OnCutNumberChange?.Invoke(this, new CutEventArgs() {
                currentCutNumber = cuttingCount,
                targetCutNumber = cuttingFormula.cuttingNumber
            });
        } 
    }

    public override void Interact(Player player) {
        bool isInteractSuccessfull = true;
        if (!(player as IPlaceKitchenObject).TryPlace(GetBePlacedKitchenObject())) {
            if(!(this as IPlaceKitchenObject).TryPlace(player.GetBePlacedKitchenObject())) {
                isInteractSuccessfull = false;
            }
        }

        if (isInteractSuccessfull) CuttingCount = 0;
    }

    public override bool CanPlaceKitchenObject(KitchenObject kitchenObject) {
        return base.CanPlaceKitchenObject(kitchenObject) && CanCut(kitchenObject);
    }

    public void SecondaryInteract() {
        if (GetBePlacedKitchenObject() != null && CanCut(GetBePlacedKitchenObject())) {
            int needCuttingNumber = cuttingFormula.cuttingNumber;
            if (++CuttingCount == needCuttingNumber) {
                GetBePlacedKitchenObject().DestroySelf();
                KitchenObject.Creat(cuttingFormula.output, this);
            }
        }
    }

    private bool CanCut(KitchenObject kitchenObject) {
        return cuttingFormulaList.TryGetFormula(kitchenObject, out cuttingFormula);
    }

    public class CutEventArgs : EventArgs {
        public int currentCutNumber;

        public int targetCutNumber;
    }
}
