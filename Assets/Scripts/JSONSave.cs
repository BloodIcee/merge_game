using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class JSONSave : MonoBehaviour
{
    public static void SaveCellsToJson(List<Cell> cells)
    {
        string json = JsonUtility.ToJson(cells, true);

        File.WriteAllText("", json);
    }

    public static List<Cell> LoadCellsFromJson()
    {
        string json = File.ReadAllText("");

        List<Cell> cells = JsonUtility.FromJson<List<Cell>>(json);

        return cells;
    }
}
