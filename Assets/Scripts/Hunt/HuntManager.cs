using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HuntManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI healthText;
    
    private int huntingAnimals;
    private List<int> animalsTier = new List<int>();

    [Space(30)]
    [SerializeField] private Prey goatPrey;
    [SerializeField] private GameConfig config;


    [SerializeField] private GameObject[] animals;
    public Transform animalPool;

    public static HuntManager instance;

    private int counter = -1;

    private void Awake()
    {
        instance = this;
    }

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

        UpdateProgress(0);
        ChooseAnotherAnimal();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateProgress(int damage)
    {
        goatPrey.health -= damage;
        if (goatPrey.health <= 0)
        {
            PlayerPrefs.SetInt(CONSTS.MONEY_PREFS, PlayerPrefs.GetInt(CONSTS.MONEY_PREFS) + config.GetPrizePerWin);
            SceneManager.LoadScene(0);
        }

        healthText.text = goatPrey.health + "HP";
    }

    public void ChooseAnotherAnimal()
    {
        if (huntingAnimals > 0 && counter + 1 < huntingAnimals)
        {
            counter++;
            animals[animalsTier[counter]].SetActive(true);

            animals[animalsTier[counter]].GetComponent<Animator>().enabled = true;
        }
        else SceneManager.LoadScene(0);
    }
}
