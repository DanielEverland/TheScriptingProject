using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGraph : MonoBehaviour
{
    public void Save()
    {
        GraphUtility.SaveCurrentGraph();
    }
}
