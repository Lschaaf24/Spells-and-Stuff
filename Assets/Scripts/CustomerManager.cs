using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private CustomerData[] customers;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public bool won = false;
    [SerializeField] public bool lose = false;
    [SerializeField] private float respawntimer = 5;
    private Customer currentCustomer;
    private Customer newCustomer;
    public Customer CurrentCustomer => currentCustomer;
    private string customerWinCondition;
    private float timer = 0;
    void Start()
    {
        SpawnCustomer();
    }

    private void SpawnCustomer()
    {
        won = false;
        lose = false;
        timer = 0;
        /* if(currentCustomer != null)
         {
             Destroy(currentCustomer);
         }*/
        CustomerData data = customers[Random.Range(0,customers.Length)];

        customerWinCondition = data.Spell;
        newCustomer = Instantiate(
        data.prefab,
        spawnPoint.position,
        spawnPoint.rotation
        ).GetComponent<Customer>();
        currentCustomer = newCustomer;

        Debug.Log(customerWinCondition);

        

    }

    // Update is called once per frame
    void Update()
    {
        checkSpell();

        if (won || lose)
        {
            timer += Time.deltaTime;
        }

        if(timer >= respawntimer)
        {
            RespawnCustomer();
        }


    }

    private void RespawnCustomer()
    {
        if (currentCustomer != null)
        {
            Destroy(currentCustomer.gameObject);
            currentCustomer = null;
        }

        SpawnCustomer();
    }

    public void checkSpell()
    {
          if (currentCustomer.GetComponent<Effect>() != null)
          {
              

              if(currentCustomer.GetComponent<Effect>().GetEffectType() == customerWinCondition && !won)
              {
                  Debug.Log("WIN");
                
                  currentCustomer.GetComponent<Rigidbody>().useGravity = false;
               
                won = true;
                currentCustomer.GetComponent<CustomerInteraction>().Interact(currentCustomer.gameObject);
                /* if (!dialogue_started)
                 {
                     currentCustomer.GetComponent<CustomerInteraction>().StartWinCustomerDialogue(currentCustomer);
                     dialogue_started = true;
                 }*/
                /*if(UIManager.instance.currentState != UIState.dialogue)
                {
                    Destroy(currentCustomer.gameObject);

                    SpawnCustomer();
                }*/

              }
            else if(currentCustomer.GetComponent<Effect>().GetEffectType() != customerWinCondition && !won)
            {
                lose = true;
                currentCustomer.GetComponent<CustomerInteraction>().Interact(currentCustomer.gameObject);
                Debug.Log("LOSE");
                /*if (UIManager.instance.currentState != UIState.dialogue)
                {
                    Destroy(currentCustomer.gameObject);

                    SpawnCustomer();
                }*/
                /*  Destroy(currentCustomer.gameObject);
                    SpawnCustomer();*/
            }

               


          }



    }

}
