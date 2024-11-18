using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryUI : UIWindow
{
    private void Start() {
        canvas.worldCamera = Camera.main;
    }
}
