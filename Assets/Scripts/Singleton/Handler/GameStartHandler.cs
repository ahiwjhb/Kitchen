using System;
using UnityEngine;
using UnityEngine.UI;

public class GameStartHandler : MonoSingleton<GameStartHandler>
{
    [SerializeField] Button gameStartButton;

    [SerializeField] OptionUI optionUI;

    [SerializeField] Button optionButton;

    private void OnEnable() {
        gameStartButton.onClick.AddListener(() =>{
            SceneLoader.Instance.Loading(SceneLoader.GAME);
        });

        optionButton.onClick.AddListener(() => {
            optionUI.SetVisible(true);
        });
    }
}
