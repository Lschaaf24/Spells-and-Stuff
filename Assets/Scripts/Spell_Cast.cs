using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using System.Collections.Generic;
using Unity.AppUI.Core;
using System;
using TMPro;
using Unity.InferenceEngine;

public class Spell_Cast : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField] private List<GameObject> spells;
    [SerializeField] private GameObject cop_prefab;
    [SerializeField] private TextMeshProUGUI dialogue_text;


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
        if (_input.cast && UIManager.instance.currentState == UIState.play)
        {
            Debug.Log("CAST SPELL!");
            _input.cast = false;
            GameObject spell;
            bool spell_cast = false;
            switch (GetComponent<Spell_Combo>().GetSpell()) 
            {
                case("fire"):
                    spell = Instantiate(spells[1], Camera.main.transform.position, Quaternion.identity.normalized);
                    Projectile proj = spell.GetComponent<Projectile>();
                    proj.direction = ray.direction;
                    proj.effect_type = typeof(BurnEffect);
                    spell.transform.position += 2 * proj.direction;
                    spell_cast = true;
                    SoundManager.PlaySound(SoundType.FireSpell, 0.1f);

                    break;
                case ("levitate"):
                    Debug.Log("LEVITATE!");

                    if (Physics.Raycast(ray, out hit))
                    {
                        spell = Instantiate(spells[0], hit.point, Quaternion.identity.normalized);
                        AreaEffector ae = spell.GetComponent<AreaEffector>();
                        ae.effect_type = typeof(LevitateEffect);
                        spell_cast = true;
                        SoundManager.PlaySound(SoundType.LevitateSpell, 0.1f);

                    }
                    break;
                case ("pig"):
                    if (Physics.Raycast(ray, out hit)) 
                    {
                        if (!hit.collider.gameObject.GetComponent<PigEffect>() && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Spellable"))) 
                        {
                            hit.collider.gameObject.AddComponent<PigEffect>().SetPigMesh(spells[2]);
                        }
                        spell_cast = true;
                        SoundManager.PlaySound(SoundType.PigSpell, 0.1f);
                    }
                    break;
                case ("tall"):
                    if(Physics.Raycast(ray, out hit)) 
                    {
                        if (!hit.collider.gameObject.GetComponent<TallEffect>() && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Spellable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))) 
                        {
                            Debug.Log(hit.collider.gameObject.AddComponent<TallEffect>().GetEffectType());
                            spell_cast = true;
                            SoundManager.PlaySound(SoundType.TallSpell, 0.1f);
                        }
                    }
                    break;
                case ("freeze"):
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (!hit.collider.gameObject.GetComponent<FreezeEffect>() && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Spellable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable")))
                        {
                            GameObject cop = hit.collider.gameObject.AddComponent<FreezeEffect>().SpawnCop(cop_prefab, spells[3]);
                            cop.GetComponent<Cop>().SetDialgoueText(dialogue_text);
                            spell_cast = true;
                            SoundManager.PlaySound(SoundType.FreezeSpell, 0.1f);
                        }
                    }
                    break;
                case ("bird"):
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (!hit.collider.gameObject.GetComponent<BirdEffect>() && !hit.collider.gameObject.GetComponent<PigEffect>() && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Spellable")))
                            {
                                hit.collider.gameObject.AddComponent<BirdEffect>().SetBirdMesh(spells[5]);
                            }
                            spell_cast = true;
                             
                            SoundManager.PlaySound(SoundType.BirdSpell, 0.1f);

                        }

                       
                    }
                    break;
                case ("cloud"):
                    break;
                case ("fire_sprite"):
                    Debug.Log("FIRE SPRITE");
                    spell = Instantiate(spells[4], Camera.main.transform.position , Quaternion.identity.normalized);
                    spell.transform.position += 2 * ray.direction;
                    spell.GetComponent<FollowPlayer>().SetTarget(this.transform.parent.gameObject);
                    spell_cast = true;
                    SoundManager.PlaySound(SoundType.FireSpiritSpell, 0.1f);
                    break;
            }


            if (spell_cast)
            {
                GetComponent<Spell_Combo>().ResetWords();
               
            }
        }
        else { _input.cast = false; }

    }
}
