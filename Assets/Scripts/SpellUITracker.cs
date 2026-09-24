using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;


public class SpellUITracker : MonoBehaviour
{
    [SerializeField] private GameObject[] spellUIObjects;
    [SerializeField] private SpellDescriptions[] spellDescriptions;

    [SerializeField] private SpellLearned spellLearned;

    private List<string> learnedSpells = new List<string>(); 

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
                        img.color = spellDescriptions[j].iconColor;

                        Transform description = spellUIObjects[i].transform.Find("Description");
                        TextMeshProUGUI content = description.GetComponent<TextMeshProUGUI>();
                        content.text = spellDescriptions[j].spellName;
                        content.color = spellDescriptions[j].iconColor;

                        TextMeshProUGUI text = spellLearned.getText();
                        text.color = Color.paleGoldenRod;
                        text.alpha = 0.0f;
                        text.text = "Spell Learned " + spellName;


                        Transform imgBack = spellUIObjects[i].transform.Find("Image (1)");
                        Image imgBackground = imgBack.GetComponent<Image>();
                        imgBackground.color = Color.blue;



                    }
                }
            }

        }

        if (learnedSpells.Contains(spellName) == false)
        {
            learnedSpells.Add(spellName);
            spellLearned.textIn();
            Debug.Log("list item: " + learnedSpells[0]);
        }

    }
}
