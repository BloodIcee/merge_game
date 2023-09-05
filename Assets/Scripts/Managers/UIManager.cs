using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : GameManager
{
    [Header("BUTTONS")] 
    public Button buyButton;

    [Header("TEXTS"), Space(10)]
    public TextMeshProUGUI buyPriceText;
    public TextMeshProUGUI moneyText;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        buyPriceText.text = "BUY " + config.GetPurchasePrice;
    }

    public void StartHunt()
    {
        JSONSave.SaveCellsToJson(SpawnManager.instance.GetAllCells, JSONSave.SaveType.All);
        JSONSave.SaveCellsToJson(SpawnManager.instance.GetAllCells, JSONSave.SaveType.Hunt);

        SceneManager.LoadScene(1);
    }

    public void UpdateMoneyText(int money)
    {
        if (money <= 0) buyButton.interactable = false;
        else buyButton.interactable = true;

        moneyText.text = money + "";
    }
}
