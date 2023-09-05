using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class JSONSave : MonoBehaviour
{
    public static void SaveCellsToJson(List<Cell> cells)
    {
        List<CellSave> cellSave = new List<CellSave>(cells.Count);

        for (int i = 0; i < cells.Count; i++)
        {
            CellSave tempCell = new CellSave();

            tempCell.isEmpty = cells[i].isEmpty;
            tempCell.currentAnimalTier = cells[i].currentAnimalTier;

            cellSave.Add(tempCell);
        }

        string json = JsonConvert.SerializeObject(cellSave);
        File.WriteAllText(Application.dataPath + "/Saves/save.json", json);

        Debug.Log(json);

        try
        {
            
            Debug.Log("Save done");
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + e.Message);
        }
    }

    public static List<CellSave> LoadCellsFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Saves/save.json");

        List<CellSave> cells = JsonConvert.DeserializeObject<List<CellSave>>(json);

        return cells;
    }

    public static void ClearJson()
    {
        string json = "[{}]";

        File.WriteAllText(Application.dataPath + "/Saves/save.json", json);
    }
}

[Serializable]
public class CellSave
{
    public bool isEmpty = true;

    public int currentAnimalTier = 0;
}
