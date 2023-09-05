using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilities : MonoBehaviour
{
    [SerializeField] private GameObject[] hiddenbuttons;

    [SerializeField] private int additionalMoney;

    public void GetMoney()
    {
        SpawnManager.instance.UpdateMoney(additionalMoney);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        JSONSave.ClearJson();
    }

    public void ShowHiddenButtons()
    {
        for (int i = 0; i < hiddenbuttons.Length; i++)
        {
            hiddenbuttons[i].SetActive(!hiddenbuttons[i].activeInHierarchy);
        }
    }
}
