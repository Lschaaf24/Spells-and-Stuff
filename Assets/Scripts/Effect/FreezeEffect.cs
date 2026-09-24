using UnityEngine;

public class FreezeEffect : Effect
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effect_type = "freeze";
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_BaseColor", Color.lightBlue);
        if (tag == "Customer")
        {
            GetComponent<Customer>().CurrentCharacterMesh.GetComponent<SkinnedMeshRenderer>().SetPropertyBlock(props);
        }
        GetComponent<MeshRenderer>().SetPropertyBlock(props);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public GameObject SpawnCop(GameObject cop_prefab, GameObject freezeParticle) 
    {
        Instantiate(freezeParticle, transform.position - new Vector3(0,1,0), Quaternion.LookRotation(transform.up));
        GameObject cop = Instantiate(cop_prefab, transform.position + (Vector3.left * 3), Quaternion.identity.normalized);
        cop.transform.LookAt(transform.position);
        return cop;

    }
}
