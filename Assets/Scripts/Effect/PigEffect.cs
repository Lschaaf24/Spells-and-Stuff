using System;
using Unity.VisualScripting;
using UnityEngine;

public class PigEffect : Effect
{
    [SerializeField] Mesh mesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        effect_type = "pig";
        transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
