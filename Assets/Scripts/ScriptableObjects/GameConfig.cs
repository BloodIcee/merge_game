using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GameConfigs", fileName = "New Game Config")]
public class GameConfig : ScriptableObject
{
    [Range(0, 2), SerializeField] private int spawnAnimalTier = 0;

    [SerializeField] private int startMoney = 300;
    [SerializeField] private int purchasePrice = 30;

    public int GetSpawnAnimalTier
    {
        get { return spawnAnimalTier; }
    }

    public int GetStartMoney
    {
        get { return startMoney; }
    }

    public int GetPurchasePrice
    {
        get { return purchasePrice; }
    }

}
