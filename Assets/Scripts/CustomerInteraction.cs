using StarterAssets;
using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CustomerInteraction : MonoBehaviour
{

    private CustomerManager customerManager;
    private Customer customer;
    private Dialogue dialogue;
    [SerializeField] private FirstPersonController firstPersonController;
    private bool once = false;
    Coroutine smoothMove = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Interact(customer.getRoot());
        customerManager = FindFirstObjectByType<CustomerManager>();
        firstPersonController = FindFirstObjectByType<FirstPersonController>();
        dialogue = FindFirstObjectByType<Dialogue>(FindObjectsInactive.Include);
        Debug.Log(dialogue);
        dialogue.gameObject.SetActive(false);

      /*  string[] newLines = { "THANKS", "FOR THAT" };
        dialogue.AddLines(newLines);*/

    }

    public void Interact(GameObject customerRoot)
    {
        customer = customerManager.CurrentCustomer;
        firstPersonController.enabled = false;
        Transform objectTransform = customerRoot.GetComponent<Customer>().getRoot().transform;

        //LookSmoothly(objectTransform);
 /*       string[] newLines = { "THANKS", "FOR THAT" };
        dialogue.AddLines(newLines);*/

        firstPersonController.enabled = true;

        if (customerManager.won == true && customerManager.lose == false && !once)
        {
            StartWinCustomerDialogue(customer);
            once = true;
        }
        else if (customerManager.won == false && customerManager.lose == true && !once)
        {
            StartLoseCustomerDialogue(customer);
            once = true;

        }
        else if (customerManager.won == false && customerManager.lose == false)
        {
            StartCustomerDialogue(customer);
        }

    }

    public void StartCustomerDialogue(Customer customer)
    {
        
        UIManager.instance.setCurrentState(UIState.dialogue);
        dialogue.StartDialogue(customer.DialogueLines);

    }

    public void StartWinCustomerDialogue(Customer customer)
    {
        UIManager.instance.setCurrentState(UIState.dialogue);
        dialogue.StartDialogue(customer.WinDialogueLines);

    }

    public void StartLoseCustomerDialogue(Customer customer)
    {
        UIManager.instance.setCurrentState(UIState.dialogue);
        dialogue.StartDialogue(customer.LoseDialogueLines);

    }


    /*private void LookSmoothly(Transform objectTransform)
    {
        float time = 1f;

        Vector3 lookat = objectTransform.position;
        lookat.y = transform.position.y;



        if (smoothMove == null)
            smoothMove = StartCoroutine(LookAtSmoothly(firstPersonController.transform, lookat, time));
        else
        {
            StopCoroutine(smoothMove);
            smoothMove = StartCoroutine(LookAtSmoothly(firstPersonController.transform, lookat, time));
        }

    }

    IEnumerator LookAtSmoothly(Transform objectToMove,Vector3 worldpos, float duration)
    {

        Quaternion currentRot = objectToMove.rotation;
        Quaternion newRot = Quaternion.LookRotation(worldpos -
            objectToMove.position, objectToMove.TransformDirection(Vector3.up));

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToMove.rotation =
                Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }


        firstPersonController.transform.rotation = Quaternion.Euler(0,firstPersonController.transform.rotation.eulerAngles.y,0);


    }*/


}
