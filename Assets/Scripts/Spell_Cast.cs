using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Spell_Cast : MonoBehaviour
{
    private StarterAssetsInputs _input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		_input = transform.parent.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.allCameras[0].transform.position, Camera.allCameras[0].transform.forward);
        if (_input.cast)
        {
            Debug.Log("CAST SPELL!");
            _input.cast = false;
            switch (GetComponent<Spell_Combo>().GetSpell()) 
            {
                case("fire"):
                    break;
                case ("levitate"):
                    Debug.Log("LEVITATE!");

                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform object_hit = hit.transform;
                        if(!object_hit.GetComponent<LevitateEffect>() || !object_hit.GetComponent<Rigidbody>()) 
                        {
                            object_hit.AddComponent<LevitateEffect>();
                        }
                    }
                    break;
                case ("pig"):
                    break;
            }
        }
    }
}
