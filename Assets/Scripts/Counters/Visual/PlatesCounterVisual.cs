using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] Transform visualPoint;

    [SerializeField] GameObject visualPrefab;

    private List<GameObject> visualObjectArray;

    private void Awake() {
        visualObjectArray = new List<GameObject>();
    }

    public void OnPlateCountChange(int plateCount) {
        if(plateCount < visualObjectArray.Count) {
            RemovePlate(visualObjectArray.Count - plateCount);
        }
        else if(plateCount > visualObjectArray.Count) {
            AddPlate(plateCount - visualObjectArray.Count);
        }
    }

    private void AddPlate(int count) {
        Vector3 positionOffset = new Vector3(0, 0.1f, 0);
        while(count > 0) {
            GameObject visualObject = Instantiate(visualPrefab, visualPoint);
            visualObject.transform.localPosition += positionOffset * visualObjectArray.Count;
            visualObjectArray.Add(visualObject);
            --count;
        }
    }

    private void RemovePlate(int count) { 
        while(count > 0) {
            int lastOne = visualObjectArray.Count - 1;
            Destroy(visualObjectArray[lastOne]);
            visualObjectArray.RemoveAt(lastOne);
            count--;
        }
    }

}
