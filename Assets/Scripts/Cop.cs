using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Cop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogue_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point;
        }

        dialogue_text.transform.parent.gameObject.SetActive(true);
        dialogue_text.text = "FREEZE!!!!";

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
