using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : GameManager
{
    [SerializeField] private List<Cell> spawnCells;

    [SerializeField] private List<Cell> huntCells;

    [SerializeField] private GameObject animalPrefab;

    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadCells();
    }

    public void SpawnAnimal()
    {
        bool hasEmptyCell = spawnCells.Any(item => item.isEmpty);

        int tempMoney = GetMoney();

        Debug.Log(tempMoney);

        if (!hasEmptyCell || tempMoney < config.GetPurchasePrice) return;

        UpdateMoney(-config.GetPurchasePrice);

        Cell[] emptyCells = spawnCells.Where(item => item.isEmpty).ToArray();

        int a = Random.Range(0, emptyCells.Length);

        emptyCells[a].isEmpty = false;
        emptyCells[a].animals[config.GetSpawnAnimalTier].SetActive(true);
    }

    private void LoadCells()
    {
        List<CellSave> loadedCells = JSONSave.LoadCellsFromJson(JSONSave.SaveType.All);

        for (int i = 0; i < loadedCells.Count; i++)
        {
            spawnCells[i].isEmpty = loadedCells[i].isEmpty;
            spawnCells[i].currentAnimalTier = loadedCells[i].currentAnimalTier;
            if (!spawnCells[i].isEmpty) spawnCells[i].animals[spawnCells[i].currentAnimalTier].SetActive(true);
        }
    }

    public List<Cell> GetAllCells 
    {
        get { return spawnCells; }
    }

    public List<Cell> GetHuntCells
    {
        get { return huntCells; }
    }
}
