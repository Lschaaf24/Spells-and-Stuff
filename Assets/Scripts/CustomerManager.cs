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
    [SerializeField] private Dialogue dialogue;
    private Customer currentCustomer;
    private Customer newCustomer;
    public Customer CurrentCustomer => currentCustomer;
    private CustomerData data;
    private string customerWinCondition;
    private string secondCustomerWinCondition;
    private float timer = 0;
    private int index = 0;
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


        if(index == 3)
        {
            index = 0;
        }

            data = customers[index];
            index++;
            customerWinCondition = data.Spell;
            secondCustomerWinCondition = data.SecondSpell;

        
            newCustomer = Instantiate(
            data.prefab,
            spawnPoint.position,
            spawnPoint.rotation
            ).GetComponent<Customer>();
            currentCustomer = newCustomer;

            Debug.Log(secondCustomerWinCondition);

            SoundManager.PlaySound(SoundType.NewCustomer, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        checkSpell();

        if (won || lose)
        {
            timer += Time.deltaTime;
        }

        if(timer >= respawntimer && dialogue.Done == true)
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
              

              if((currentCustomer.GetComponent<Effect>().GetEffectType() == customerWinCondition || currentCustomer.GetComponent<Effect>().GetEffectType() == secondCustomerWinCondition) && !(won || lose))
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
            else if((currentCustomer.GetComponent<Effect>().GetEffectType() != customerWinCondition && currentCustomer.GetComponent<Effect>().GetEffectType() != secondCustomerWinCondition) && !(won || lose))
            {
                currentCustomer.GetComponent<Rigidbody>().useGravity = false;
                lose = true;

                currentCustomer.GetComponent<CustomerInteraction>().Interact(currentCustomer.gameObject);
                Debug.Log(currentCustomer.GetComponent<Effect>().GetEffectType());
                Debug.Log(currentCustomer.GetComponent<Effect>() != null);
                
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
