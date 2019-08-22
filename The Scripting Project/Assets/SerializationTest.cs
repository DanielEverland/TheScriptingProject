using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

using BindingFlags = System.Reflection.BindingFlags;

public class SerializationTest : MonoBehaviour
{
    private void Start()
    {
        Node node = new Node();
        node.Position = new Vector2(2, 1);
        
        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ContractResolver = new TestConverter(),
        };
        string str = JsonConvert.SerializeObject(node, Formatting.Indented, settings);

        Debug.Log(str);
    }
}
public class TestConverter : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        IList<JsonProperty> baseProperties = base.CreateProperties(type, memberSerialization);
        
        return baseProperties.Where(x => ShouldSerialize(x)).ToList();
    }
    private static bool ShouldSerialize(JsonProperty property)
    {
        return property.DeclaringType.GetField(property.PropertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField) != null;
    }
}