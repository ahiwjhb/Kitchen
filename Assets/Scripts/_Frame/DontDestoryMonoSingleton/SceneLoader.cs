using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : DontDestoryMonoSingleton<SceneLoader>
{
    [SerializeField] float fadeTime = 0.5f;

    public static readonly string MengDeScence = "MengDe";

    private bool isLoading = false;

    private SceneLoadUI loadingUI;

    private Image processBar;

    private AsyncOperation asyncOperation;

    public event Action<AsyncOperation> OnScenceLoadCompleted {
        add => asyncOperation.completed += value;
        remove => asyncOperation.completed -= value;
    }

    protected override void Awake() {
        base.Awake();
        loadingUI = transform.GetComponentInGameObject<SceneLoadUI>();
        processBar = transform.FindInPrognies("ProcessBar").GetComponent<Image>();
    }

    private void Start() {
        loadingUI.SetVisible(false);
    }

    public void Loading(string sceneName) {
        if (isLoading) return;
        processBar.fillAmount = 0;
        StartCoroutine(LoadingCoroutine(sceneName));
    }

    private IEnumerator LoadingCoroutine(string sceneName) {
        isLoading = true;
        loadingUI.SetVisible(true);
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        yield return loadingUI.FadeIn(fadeTime);
        yield return WaitSceneLoading();
        asyncOperation.allowSceneActivation = true;
        yield return loadingUI.FadeOut(fadeTime);
        loadingUI.SetVisible(false);
        isLoading = false;
    }

    private IEnumerator WaitSceneLoading() {
        while (processBar.fillAmount < 0.9f) {
            processBar.fillAmount = Mathf.Min(processBar.fillAmount + Time.deltaTime, asyncOperation.progress);
            yield return null;
        }
        processBar.fillAmount = 1;
    }

    private class SceneLoadUI : UIWindow
    {

    }
}

