using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingFormulaList : ScriptableObject
{
    [SerializeField] List<FryingFormula> fryingFormulaArray;

    private Dictionary<KitchenObjectSO, FryingFormula> fryingFormulaDict;

    private void OnEnable() {
        fryingFormulaDict = new Dictionary<KitchenObjectSO, FryingFormula>(fryingFormulaArray.Count);
        foreach(var fryingFormula in fryingFormulaArray) {
            fryingFormulaDict.Add(fryingFormula.input, fryingFormula);
        }
    }

    public bool TryGetFormula(KitchenObject kitchenObject, out FryingFormula fryingFormula) {
        return fryingFormulaDict.TryGetValue(kitchenObject.KitchenObjectSo, out fryingFormula);
    }

    [Serializable]
    public class FryingFormula
    {
        public KitchenObjectSO input;

        public KitchenObjectSO normalOutput;

        public KitchenObjectSO burnedOutput;

        public float fryingTime;

        public float burnedTime;
    }
}
