using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class JSONSave : MonoBehaviour
{
    public enum SaveType
    {
        All,
        Hunt
    }

    public SaveType savetype;

    public static void SaveCellsToJson(List<Cell> cells, SaveType type)
    {
        string savePathAll;
        string savePathHunt;

#if UNITY_ANDROID && !UNITY_EDITOR
        savePathAll = Path.Combine(Application.persistentDataPath, "save.json");
        savePathHunt = Path.Combine(Application.persistentDataPath, "saveHunt.json");
#else
        savePathAll = Path.Combine(Application.dataPath, "save.json");
        savePathHunt = Path.Combine(Application.dataPath, "saveHunt.json");
#endif

        List<CellSave> cellSave = new List<CellSave>(cells.Count);

        for (int i = 0; i < cells.Count; i++)
        {
            CellSave tempCell = new CellSave();

            tempCell.isEmpty = cells[i].isEmpty;
            tempCell.currentAnimalTier = cells[i].currentAnimalTier;

            cellSave.Add(tempCell);
        }

        string json = JsonConvert.SerializeObject(cellSave);
        
        if (type == SaveType.All)
        {
            File.WriteAllText(savePathAll, json);
        }
        else if (type == SaveType.Hunt)
        {
            File.WriteAllText(savePathHunt, json);
        }

        try
        {
            
            Debug.Log("Save done");
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + e.Message);
        }
    }

    public static List<CellSave> LoadCellsFromJson(SaveType type)
    {
        string savePathAll;
        string savePathHunt;

#if UNITY_ANDROID && !UNITY_EDITOR
        savePathAll = Path.Combine(Application.persistentDataPath, "save.json");
        savePathHunt = Path.Combine(Application.persistentDataPath, "saveHunt.json");
#else
        savePathAll = Path.Combine(Application.dataPath, "save.json");
        savePathHunt = Path.Combine(Application.dataPath, "saveHunt.json");
#endif

        string json = "";

        if (type == SaveType.All)
        {
            json = File.ReadAllText(savePathAll);
        }
        else if (type == SaveType.Hunt)
        {
            json = File.ReadAllText(savePathHunt);
        }

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
