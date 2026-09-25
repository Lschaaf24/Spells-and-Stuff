using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Cop : MonoBehaviour
{
    float dialogue_time = 3.0f;
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

        

    }
    // Update is called once per frame
    void Update()
    {
        dialogue_time -= Time.deltaTime;
        if(dialogue_time < 0) 
        {
            UIManager.instance.setCurrentState(UIState.play);
            Destroy(this);
        }
    }

    public void SetDialgoueText(TextMeshProUGUI text) 
    {
        dialogue_text = text;
    }
}
