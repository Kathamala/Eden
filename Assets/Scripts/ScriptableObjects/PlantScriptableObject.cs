using UnityEngine;

[CreateAssetMenu(fileName ="PlantScriptableObject", menuName ="ScriptableObject/Plant")]
public class PlantScriptableObject : ScriptableObject
{
    [field:SerializeField] public Sprite[] Sprites { get; private set; }
    [field: SerializeField] public int[] waterLevels { get; private set; }
}
