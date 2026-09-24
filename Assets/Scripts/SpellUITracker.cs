using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;


public class SpellUITracker : MonoBehaviour
{
    [SerializeField] private GameObject[] spellUIObjects;
    [SerializeField] private SpellDescriptions[] spellDescriptions;


    private void Update()
    {

    }


    public void learnSpell(string spellName)
    {
        for (int i = 0; i < spellUIObjects.Length; i++)
        {
            if (spellUIObjects[i].name == spellName)
            {

                for (int j = 0; j < spellDescriptions.Length; j++)
                {

                    if (spellDescriptions[j].spellName == spellName)
                    {
                        Debug.Log("spell description found" + spellDescriptions[j].spellName);
                        Transform icon = spellUIObjects[i].transform.Find("UnknownIcon");

                        Image img = icon.GetComponent<Image>();
                        img.sprite = spellDescriptions[j].icon;

                        Transform description = spellUIObjects[i].transform.Find("Description");
                        TextMeshProUGUI content = description.GetComponent<TextMeshProUGUI>();
                        content.text = spellDescriptions[j].spellName;
                    }
                }
            }

        }

    }
}
