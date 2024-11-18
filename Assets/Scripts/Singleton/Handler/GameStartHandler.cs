using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameStartHandler : MonoSingleton<GameStartHandler>
{
    [SerializeField] Button gameStartButton;

    [SerializeField] OptionUI optionUI;

    [SerializeField] Button optionButton;

    [SerializeField] Button quiteButton;

    private void OnEnable() {
        gameStartButton.onClick.AddListener(() =>{
            SceneLoader.Instance.Loading(SceneLoader.GAME);
        });

        optionButton.onClick.AddListener(() => {
            optionUI.SetVisible(true);
        });

        quiteButton.onClick.AddListener(() => {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        });
    }
}
