using System;
using System.Collections.Generic;

public class UIManager : MonoSingleton<UIManager>
{
    private Dictionary<Type, UIWindow> uiWindownDict;

    protected override void Awake()
    {
        base.Awake();
        UIWindow[] uIWindows = transform.GetAllCompontentsInPrognies<UIWindow>();
        uiWindownDict = new Dictionary<Type, UIWindow>(uIWindows.Length);
        foreach (var window in uIWindows) uiWindownDict.Add(window.GetType(), window);
    }

    private void Start()
    {
        foreach (var window in uiWindownDict.Values) window.SetVisible(false);
    }

    public T GetUIWindow<T>() where T : UIWindow
    {
        return uiWindownDict.TryGetValue(typeof(T), out UIWindow window) ? window as T : null;
    }
}
