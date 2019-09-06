using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GraphUtility
{
    public const float NodeUnitInPixels = 32;
    public const string DebugGraphFileName = "/Serialized Data/debuggraph.json";

    public static string GetDebugGraphFileName()
    {
        return Application.dataPath + DebugGraphFileName;
    }
    public static void SaveCurrentGraph()
    {
        if (GraphConstructor.CurrentGraph == null)
            throw new System.NullReferenceException("No CurrentGraph available!");

        string json = Serializer.Serialize(GraphConstructor.CurrentGraph);
        string fullFilename = GraphUtility.GetDebugGraphFileName();

        Debug.Log("Saving to " + fullFilename);

        File.WriteAllText(fullFilename, json);
    }
    public static IGraph LoadDebugGraph()
    {
        string fullFilename = GraphUtility.GetDebugGraphFileName();

        if (!File.Exists(fullFilename))
        {
            Debug.LogWarning("No file exists at " + fullFilename);
            return null;
        }

        string jsonString = File.ReadAllText(fullFilename);
        DirectedGraph graph = Serializer.Deserialize<DirectedGraph>(jsonString);

        return graph;
    }
}
