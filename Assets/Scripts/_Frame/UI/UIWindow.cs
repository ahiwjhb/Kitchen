using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas),typeof(CanvasGroup))]
public class UIWindow : MonoBehaviour
{
    protected Canvas canvas;

    private CanvasGroup canvasGroup;

    protected virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
        TryGetComponent<CanvasGroup>(out canvasGroup);
    }

    public void SetVisible(bool visiable)
    {
        canvas.enabled = visiable;
    }

    public IEnumerator FadeIn(float time = 0)
    {
        SetVisible(true);
        if (time > 0)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }
    }

    public IEnumerator FadeOut(float time = 0)
    {
        if (time > 0)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
        SetVisible(false);
    }
}
