using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

static public class TransfromHelp
{
    public static T GetOrAddComponent<T>(this Transform tsm) where T : Component {
        return tsm.GetComponent<T>() ?? tsm.AddComponent<T>();
    }

    /// <summary>
    /// 根据名称寻找层级未知的子类transform组件
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="targetName">目标组件的GameObject名称</param>
    /// <returns>目标组件的transform</returns>
    public static Transform FindInPrognies(this Transform parent, string targetName)
    {
        if (parent == null) return null;
        if (parent.name == targetName) return parent;
        Transform target = null;
        for (int i = 0; i < parent.childCount; ++i)
        {
            target = FindInPrognies(parent.GetChild(i), targetName);
            if (target != null) break;
        }
        return target;
    }

    public static T GetComponentInGameObject<T>(this Transform tsm) where T : Component
    {
        T component = null;
        if (tsm.TryGetComponent<T>(out component)) return component;
        for(int i = 0; i < tsm.childCount; ++i)
        {
            component = tsm.GetChild(i).GetComponentInGameObject<T>();
            if (component != null) break;
        }
        return component;
    }

    /// <summary>
    /// 获取后代所有T类型的组件(不包括自己)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static T[] GetAllCompontentsInPrognies<T>(this Transform parent) where T : Component
    {
        List<T> targets = new List<T>();
        for (int i = 0; i < parent.childCount; ++i)
        {
            AddCompotentsToList<T>(parent.GetChild(i), targets);  
        }
        return targets.ToArray();
    }

    private static void AddCompotentsToList<T>(Transform tsm, List<T> targets) where T : Component
    {
        if (tsm.TryGetComponent<T>(out var target))
        {
            targets.Add(target);
        }
        for (int i = 0; i < tsm.childCount; ++i)
        {
            AddCompotentsToList<T>(tsm.GetChild(i), targets);
        }
    }
}