using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkTestUI : UIWindow
{
    [SerializeField] Button hostBtn;

    [SerializeField] Button clientBtn;

    private void Start() {
        SetVisible(true);

        hostBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
            gameObject.SetActive(false);
        });

        clientBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            gameObject.SetActive(false);
        });
    }
}
