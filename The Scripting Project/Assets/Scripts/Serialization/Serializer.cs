using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using BindingFlags = System.Reflection.BindingFlags;

public static class Serializer
{
    static Serializer()
    {
        settings = new JsonSerializerSettings()
        {
            ContractResolver = new FieldOnlyConverter(),
        };
    }

    private static JsonSerializerSettings settings;

    public static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
    }

    private class FieldOnlyConverter : DefaultContractResolver
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
}