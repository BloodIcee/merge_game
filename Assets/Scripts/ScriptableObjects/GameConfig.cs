using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GameConfigs", fileName = "New Game Config")]
public class GameConfig : ScriptableObject
{
    [Range(0, 2), SerializeField] private int spawnAnimalTier = 0;

    public int GetSpawnAnimalTier
    {
        get { return spawnAnimalTier; }
    }

}
