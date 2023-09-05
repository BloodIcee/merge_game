using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Animal", fileName = "New Animal Config")]
public class Animal : ScriptableObject
{
    [SerializeField] private int animalRank = 0;
    [SerializeField] private int animalDamage = 10;

    public int GetAnimalRank
    {
        get { return animalRank; }
    }

    public int GetAnimalDamage
    {
        get { return animalDamage; }
    }

}
