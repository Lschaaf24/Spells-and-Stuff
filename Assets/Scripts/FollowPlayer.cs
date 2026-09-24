
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    [SerializeField] GameObject body;
    Vector3 last_pos;

    bool kicked = false;

    ParticleSystem poof;

    [SerializeField] float lifetime = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        this.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        poof = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!kicked)
        {
            agent.destination = target.transform.position;

            if (last_pos != transform.position)
            {

                gameObject.transform.LookAt(target.transform.position);
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles + new Vector3(90, -90, 0));
            }
            else
            {
                body.transform.LookAt(target.transform.position + new Vector3(0, 1.375f, 0));
                body.transform.rotation = Quaternion.Euler(body.transform.rotation.eulerAngles + new Vector3(-90, 90, 0));

            }

            last_pos = transform.position;
        }
        else
        {
            lifetime -= Time.deltaTime;
            if (lifetime < 0.4f && !poof.isPlaying) 
            {
                poof.Play();
            }
            else if(lifetime < 0) 
            {
                Destroy(gameObject);
            }
        }

    }

    public void SetTarget(GameObject t)
    {
        target = t;
    }

    public void BeginDemise() 
    {
        kicked = true;
    }
}
