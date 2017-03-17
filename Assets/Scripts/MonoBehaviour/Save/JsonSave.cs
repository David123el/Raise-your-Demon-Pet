using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonSave
{
    public static void Save(object o, string path)
    {
        string json = JsonUtility.ToJson(o);

        StreamWriter sw = File.CreateText(path);
        sw.Close();

        File.WriteAllText(path, json);
    }

    public static void Load(string path, ref object o)
    {
        string json = File.ReadAllText(path);

        o = JsonUtility.FromJson<object>(json);
    }
}
