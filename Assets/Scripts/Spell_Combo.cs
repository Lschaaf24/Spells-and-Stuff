using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spell_Combo : MonoBehaviour
{
    [SerializeField] string first_word = "";
    [SerializeField] string second_word = "";
    [SerializeField] string spell;

    [SerializeField] TextAsset word_combo_asset;
    int words_count;
    string[,] words_table;

    [SerializeField] TextMeshProUGUI word_ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CSVtoAray(word_combo_asset);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CSVtoAray(TextAsset csv_file)
    {
        string[] split_lines = csv_file.text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
        words_count = split_lines.Length;
        words_table = new string[words_count, words_count];
        for (int i = 0; i < words_count; i++)
        {
            string[] words = split_lines[i].Split(',', StringSplitOptions.None);
            for(int j= 0; j < words.Length; j++)
            {
                words_table[i, j] = words[j];
            }
        }
    }

    public string GetSpell() 
    {
        return spell;
    }

    public void SetWord(string word) 
    {
        word = word.ToLower();
        if(first_word == "") 
        {
            first_word = word; 
        }
        else if(second_word == "") 
        {
            second_word = word;
        }
        else 
        {
            first_word = word;
        }
        FindSpell();
        UpdateText();
    }
    

    private void UpdateText()
    {
        word_ui.text = first_word + " + " + second_word;
    }

    private void FindSpell()
    {
        spell = "";
        for (int i = 0; i < words_count; i++)
        {
            if (words_table[i, 0] == first_word)
            {
                for (int j = 0; j < words_count; j++)
                {
                    if (words_table[0, j] == second_word)
                    {
                        spell = words_table[i, j];
                    }
                }
            }
        }
    }

    public void ResetWords() 
    {
        first_word = "";
        second_word = "";
        FindSpell();
        UpdateText();
    }
}
