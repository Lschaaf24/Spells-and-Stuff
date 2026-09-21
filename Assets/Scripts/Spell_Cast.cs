using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using System.Collections.Generic;
using Unity.AppUI.Core;

public class Spell_Cast : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField] private List<GameObject> spells; 

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
            GameObject spell;
            switch (GetComponent<Spell_Combo>().GetSpell()) 
            {
                case("fire"):
                    spell = Instantiate(spells[1], Camera.main.transform.position, Quaternion.identity.normalized);
                    Projectile proj = spell.GetComponent<Projectile>();
                    proj.direction = ray.direction;
                    proj.effect_type = typeof(BurnEffect);
                    spell.transform.position += 2 * proj.direction;

                    break;
                case ("levitate"):
                    Debug.Log("LEVITATE!");

                    if (Physics.Raycast(ray, out hit))
                    {
                        spell = Instantiate(spells[0], hit.point, Quaternion.identity.normalized);
                        AreaEffector ae = spell.GetComponent<AreaEffector>();
                        ae.effect_type = typeof(LevitateEffect);

                        
                    }
                    break;
                case ("pig"):
                    if (Physics.Raycast(ray, out hit)) 
                    {
                        spell = Instantiate(spells[2], hit.collider.transform.position, Quaternion.identity.normalized);
                        Destroy(hit.collider.gameObject);
                    }
                    break;
            }
        }
    }
}
