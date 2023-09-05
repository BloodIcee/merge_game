using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HuntManager : MonoBehaviour
{
    private int huntingAnimals = 0;
    private List<int> animalsTier = new List<int>();

    private void Start()
    {
        List<CellSave> cells = JSONSave.LoadCellsFromJson(JSONSave.SaveType.Hunt);

        for (int i = 0; i < cells.Count; i++)
        {
            if (!cells[i].isEmpty)
            {
                huntingAnimals++;
                animalsTier.Add(cells[i].currentAnimalTier);
            }

        }

        Debug.Log("Animals = " + huntingAnimals);
        for (int i = 0; i < animalsTier.Count; i++)
        {
            Debug.Log(animalsTier[i]);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
