using System;
using UnityEngine;

public class PigEffect : Effect
{
    [SerializeField] Mesh mesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        effect_type = "pig";
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
