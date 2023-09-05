using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("BUTTONS")] 
    public Button buyButton;

    //[Header("TEXTS"), Space(10)]

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
}
