using UnityEngine;

public class TallEffect : Effect
{
    Vector3 target_scale = Vector3.one;
    Vector3 current_scale = Vector3.one;
    float scale_time = 100.0f;
    float elapsed_time = 0.0f;

    bool applied = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effect_type = "tall";
        current_scale = transform.localScale;
        target_scale = new Vector3(current_scale.x, current_scale.y * 2, current_scale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(applied) return;

        elapsed_time += Time.deltaTime;
        if (target_scale.y != current_scale.y)
        {
            current_scale = new Vector3(current_scale.x, Mathf.Lerp(current_scale.y, target_scale.y, elapsed_time / scale_time), current_scale.z);
            transform.localScale = current_scale;
        }
        else 
        {
            applied = true;
        }

    }
}
