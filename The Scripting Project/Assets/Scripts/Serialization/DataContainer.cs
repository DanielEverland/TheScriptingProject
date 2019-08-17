using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class DataContainer
{
    [JsonProperty]
    private DataVector persistentData = new DataVector();
    [JsonIgnore]
    private DataVector runtimeData = new DataVector();

    public object GetPersistentData(int key)
    {
        return persistentData[key];
    }
    public T GetPersistentData<T>(int key)
    {
        return (T)persistentData[key];
    }

    public object GetRuntimeData(int key)
    {
        return runtimeData[key];
    }
    public T GetRuntimeData<T>(int key)
    {
        return (T)runtimeData[key];
    }

    public void SetPersistentData(int key, object obj)
    {
        persistentData.SetData(key, obj);
    }
    public void SetRuntimeData(int key, object obj)
    {
        runtimeData.SetData(key, obj);
    }
}
