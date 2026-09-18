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
    [SerializeField] private Customer customer;
    private Transform playerCameraRoot;
    Coroutine smoothMove = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Interact(customer.getRoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (in_range)
        {
            Interact(customer.getRoot());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kiosk")
        {
            in_range = true;
        }
    }

    private void Interact(GameObject customerRoot)
    {


        this.GetComponent<FirstPersonController>().enabled = false;
        Transform objectTransform = customerRoot.transform;

        LookSmoothly(objectTransform);


    }

    private void LookSmoothly(Transform objectTransform)
    {
        float time = 1f;

        Vector3 lookat = objectTransform.position;
        lookat.y = transform.position.y;

        if (smoothMove == null)
            smoothMove = StartCoroutine(LookAtSmoothly(transform, lookat, time));
        else
        {
            StopCoroutine(smoothMove);
            smoothMove = StartCoroutine(LookAtSmoothly(transform, lookat, time));
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


    }


}
