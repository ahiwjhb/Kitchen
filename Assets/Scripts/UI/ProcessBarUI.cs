using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessBarUI : UIWindow
{
    [SerializeField] Image processBarImage;

    private void Start() {
        canvas.worldCamera = Camera.main;
    }

    public void SetProcess(float process) {
        processBarImage.fillAmount = process;
    }
}
