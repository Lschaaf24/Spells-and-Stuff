using System;
using Unity.VisualScripting;
using UnityEngine;

public class BirdEffect : Effect
{
    Mesh og_mesh;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Material[] og_materials;
    Vector3 og_scale;
    void Awake()
    {
        effect_type = "bird";
        if (GetComponentInChildren<ParticleSystem>()) 
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }
        lifetime = 4.0f;
        og_mesh = GetComponentInChildren<MeshFilter>().mesh;
        og_materials = GetComponent<MeshRenderer>().materials;
        og_scale = transform.localScale;
        transform.localScale = Vector3.one;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        transform.position += Vector3.up * Time.deltaTime * 1.0f;
        
        if(lifetime < 0) 
        {
            if (GetComponentInChildren<ParticleSystem>())
            {
                GetComponentInChildren<ParticleSystem>().Play();
            }
            GetComponent<MeshFilter>().mesh = og_mesh;
            GetComponent<MeshRenderer>().materials = og_materials;
            transform.localScale = Vector3.one;
            GetComponent<Rigidbody>().isKinematic = false;
            Destroy(this);
        }
    }

    public void SetBirdMesh(GameObject bird) 
    {
       GetComponent<MeshFilter>().mesh = bird.GetComponentInChildren<MeshFilter>().sharedMesh;
       GetComponent<MeshRenderer>().materials = bird.GetComponentInChildren<MeshRenderer>().sharedMaterials;
    }
}
