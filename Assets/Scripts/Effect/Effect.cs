using UnityEngine;

public class Effect : MonoBehaviour
{
    protected string effect_type;
    protected float lifetime = 2.0f;

    
    public string GetEffectType() 
    {
        return effect_type;
    }
}
