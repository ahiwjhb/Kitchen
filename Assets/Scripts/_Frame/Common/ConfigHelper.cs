using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public static class ConfigHelper
{
    public static void ReadConfigFile(string configFile, Action<string> readActionOnEachLine)
    {
        string configFilePath = GetConfigFilePath(configFile);
        using (StringReader stringReader = new StringReader(configFilePath))
        {
            string line = null;
            while ((line = stringReader.ReadLine()) != null)
            {
                readActionOnEachLine(line);
            }
        }
    }

    private static string GetConfigFilePath(string fileName)
    {
        string url;

#if   UNITY_EDITOR || UNITY_STANDALONE
        url = "file://" + Application.streamingAssetsPath + "/" + fileName;
#elif UNITY_IPHONE
        url = "file://" + Application.dataPath + "/Raw"     + "/" + fileName;
#elif UNITY_ANDROID
        url = "jar:file://" + Application.dataPath + "!/assets" + "/" + fileName;
#endif
        UnityWebRequest uwr = UnityWebRequest.Get(url + ".txt");
        uwr.SendWebRequest();
        while (true)
        {
            if (uwr.downloadHandler.isDone)
            {
                return uwr.downloadHandler.text;
            }
        }
    }
}
