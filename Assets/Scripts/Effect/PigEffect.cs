using System;
using Unity.VisualScripting;
using UnityEngine;

public class PigEffect : Effect
{
    Mesh og_mesh;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Material[] og_materials;
    Vector3 og_scale;
    void Awake()
    {
        effect_type = "pig";
        transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        GetComponentInChildren<ParticleSystem>().Play();
        lifetime = 10.0f;
        if (tag == "Customer")
        {
            og_mesh = GetComponent<Customer>().CurrentCharacterMesh.GetComponent<SkinnedMeshRenderer>().sharedMesh;
            og_materials = GetComponent<Customer>().CurrentCharacterMesh.GetComponent<SkinnedMeshRenderer>().sharedMaterials;
        }
        else
        {
            og_mesh = GetComponentInChildren<MeshFilter>().mesh;
            og_materials = GetComponent<MeshRenderer>().materials;
        }
        og_scale = transform.localScale;
        transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0) 
        {
            GetComponent<MeshFilter>().mesh = og_mesh;
            GetComponent<MeshRenderer>().materials = og_materials;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.localScale = Vector3.one;
            Destroy(this);
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    public void SetPigMesh(GameObject pig) 
    {
        if(tag == "Customer")
        {
            GetComponent<Customer>().CurrentCharacterMesh.GetComponent<SkinnedMeshRenderer>().sharedMesh = pig.GetComponent<MeshFilter>().sharedMesh;
            GetComponent<Customer>().CurrentCharacterMesh.GetComponent<SkinnedMeshRenderer>().materials = pig.GetComponent<MeshRenderer>().sharedMaterials;
        }
        else
        {
            GetComponent<MeshFilter>().mesh = pig.GetComponent<MeshFilter>().sharedMesh;
            GetComponent<MeshRenderer>().materials = pig.GetComponent<MeshRenderer>().sharedMaterials;

        }
    }
}
