using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingFormulaList : ScriptableObject
{
    [SerializeField] List<CuttingFormula> cuttingFormulaArray;

    private Dictionary<KitchenObjectSO, CuttingFormula> cuttingFormulaDict;

    private void OnEnable() {
        cuttingFormulaDict = new Dictionary<KitchenObjectSO, CuttingFormula>(cuttingFormulaArray.Count);
        foreach(var cuttingFormula in cuttingFormulaArray) {
            cuttingFormulaDict.Add(cuttingFormula.input, cuttingFormula);
        }
    }

    public bool TryGetFormula(KitchenObject kitchenObject, out CuttingFormula cuttingFormula) {
        return cuttingFormulaDict.TryGetValue(kitchenObject.KitchenObjectSo, out cuttingFormula);
    }


    [Serializable]
    public class CuttingFormula 
    {
        public KitchenObjectSO input;

        public KitchenObjectSO output;

        public int cuttingNumber;
    }
}
