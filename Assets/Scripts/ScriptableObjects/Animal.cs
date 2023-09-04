using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Animal", fileName = "New Animal Config")]
public class Animal : ScriptableObject
{
    [SerializeField] private Mesh animalMesh;
    [SerializeField] private Material animalMaterial;
    [SerializeField] private int animalRank = 0;

    public Mesh GetAnimalMesh
    {
        get { return animalMesh; }
    }

    public Material GetAnimalMaterial
    {
        get { return animalMaterial; }
    }

    public int GetAnimalRank
    {
        get { return animalRank; }
    }

}
