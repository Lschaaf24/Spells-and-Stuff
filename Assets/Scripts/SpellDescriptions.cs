using UnityEngine;

[CreateAssetMenu(fileName = "SpellDescriptions", menuName = "Scriptable Objects/SpellDescriptions")]
public class SpellDescriptions : ScriptableObject
{
    public string spellName;
    public string spellDescription;
    public string wordCombo;

    public Sprite icon;

    public Color iconColor;
}
