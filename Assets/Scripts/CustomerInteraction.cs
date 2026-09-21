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

    [SerializeField] private bool in_range = false;
    private CustomerManager customerManager;
    private Customer customer;
    private Dialogue dialogue;
    [SerializeField] private FirstPersonController firstPersonController;


    Coroutine smoothMove = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Interact(customer.getRoot());
        customerManager = FindFirstObjectByType<CustomerManager>();
        firstPersonController = FindFirstObjectByType<FirstPersonController>();
        dialogue = FindFirstObjectByType<Dialogue>();
        Debug.Log(dialogue);
        dialogue.gameObject.SetActive(false);
    }

    public void Interact(GameObject customerRoot)
    {
        customer = customerManager.CurrentCustomer;
        firstPersonController.enabled = false;
        Transform objectTransform = customerRoot.GetComponent<Customer>().getRoot().transform;

        LookSmoothly(objectTransform);

        firstPersonController.enabled = true;
        StartCustomerDialogue(customer);
    }

    public void StartCustomerDialogue(Customer customer)
    {
        dialogue.gameObject.SetActive(true);
        dialogue.StartDialogue(customer.DialogueLines);
    }

    private void LookSmoothly(Transform objectTransform)
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


        Quaternion newRotation = Quaternion.Euler(0,firstPersonController.transform.rotation.eulerAngles.y,0);


    }


}
