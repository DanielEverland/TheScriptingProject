using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class DataVector
{
    [JsonProperty]
    private Dictionary<int, object> data = new Dictionary<int, object>();

    public object this[int key]
    {
        get
        {
            return GetData(key);
        }
        set
        {
            SetData(key, value);
        }
    }

    public object GetData(int key)
    {
        if (!data.ContainsKey(key))
            throw new System.NullReferenceException("Unable to find data for key: " + key);

        return data[key];
    }
    
    public void SetData(int key, object obj)
    {
        if(!data.ContainsKey(key))
        {
            data[key] = obj;
        }
        else
        {
            data.Add(key, obj);
        }
    }
}
