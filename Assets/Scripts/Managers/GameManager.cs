using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameConfig config;

    private int money;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(CONSTS.MONEY_PREFS)) PlayerPrefs.SetInt(CONSTS.MONEY_PREFS, config.GetStartMoney);

        money = PlayerPrefs.GetInt(CONSTS.MONEY_PREFS);

        
    }

    private void Start()
    {
        UIManager.instance.UpdateMoneyText(money);
    }

    public void UpdateMoney(int price)
    {
        money = PlayerPrefs.GetInt(CONSTS.MONEY_PREFS);
        money += price;

        UIManager.instance.UpdateMoneyText(money);

        SaveMoney();
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt(CONSTS.MONEY_PREFS, money);
    }

    public int GetMoney()
    {
        money = PlayerPrefs.GetInt(CONSTS.MONEY_PREFS);
        return money;
    }
}
