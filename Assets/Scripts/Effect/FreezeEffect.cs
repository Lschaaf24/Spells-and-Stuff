using UnityEngine;

public class FreezeEffect : Effect
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effect_type = "freeze";
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SpawnCop(GameObject cop_prefab) 
    {
        GameObject cop = Instantiate(cop_prefab, transform.position + (Vector3.left * 3), Quaternion.identity.normalized);
        cop.transform.LookAt(transform.position);

    }
}
