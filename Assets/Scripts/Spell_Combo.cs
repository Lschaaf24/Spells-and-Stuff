using System;
using UnityEngine;

public class Spell_Combo : MonoBehaviour
{
    [SerializeField] string first_word;
    [SerializeField] string second_word;
    [SerializeField] string spell;

    [SerializeField] TextAsset word_combo_asset;
    int words_count;
    string[,] words_table;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CSVtoAray(word_combo_asset);
    }

    // Update is called once per frame
    void Update()
    {
        spell = "";
        for (int i = 0; i < words_count; i++) 
        {
            if (words_table[i,0] == first_word) 
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
}
