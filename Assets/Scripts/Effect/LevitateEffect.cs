using UnityEngine;

public class LevitateEffect : Effect
{
    
    float lifetime = 0;
    [SerializeField] float force = 60;
    Rigidbody rb;
    private void Start()
    {
        effect_type = "levitate";
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.AddForce(Vector3.up * force, ForceMode.Force);

        if(rb.transform.tag != "Player") 
        {
            Vector3 randomRotation = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f));
            rb.AddRelativeTorque(randomRotation, ForceMode.Impulse);
        }

    }


    private void OnDestroy()
    {
       rb.useGravity = true;
    }
}




