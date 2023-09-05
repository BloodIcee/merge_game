using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameConfig config;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
