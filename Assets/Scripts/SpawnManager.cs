using System.Linq;
using UnityEngine;

public class SpawnManager : GameManager
{
    [SerializeField] private Cell[] spawnCells;

    [SerializeField] private GameObject animalPrefab;

    private void Start()
    {
        SpawnAnimal();
    }

    public void SpawnAnimal()
    {
        bool hasEmptyCell = spawnCells.Any(item => item.isEmpty);
        if (!hasEmptyCell) return;

        Cell[] emptyCells = spawnCells.Where(item => item.isEmpty).ToArray();

        int a = Random.Range(0, emptyCells.Length);

        emptyCells[a].isEmpty = false;
        emptyCells[a].animals[config.GetSpawnAnimalTier].SetActive(true);
    }
}
