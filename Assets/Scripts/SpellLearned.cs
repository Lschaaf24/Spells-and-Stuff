using System.Collections;
using TMPro;
using UnityEngine;

public class SpellLearned : MonoBehaviour
{
    [SerializeField] private GameObject spellLearnedText;
    [SerializeField] private float fadeTime = 0.1f;
    private TextMeshProUGUI text;

    private float increment;
    private bool fadeIn;

    private void Start()
    {
        text = spellLearnedText.GetComponent<TextMeshProUGUI>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

    }

    private void Update()
    {
       
    }


    public void textIn()
    {
        fadeIn = true;

        StartCoroutine(FadeTextIn());
    }

    public TextMeshProUGUI getText()
    {
        return text;
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float alpha = Mathf.Lerp(
                startAlpha,
                endAlpha,
                elapsed / duration
            );

            SetAlpha(alpha);

            yield return null;
        }

        SetAlpha(endAlpha);
    }
    private void SetAlpha(float alpha)
    {
        Color color = text.color;
        color.a = alpha;
        text.color = color;
    }


    //private IEnumerator Fade(float startLevel, float endLevel, float time)
    //{
    //    float speed = 1.0f / time;

    //    for (float t = 0.0f; t < 1.0; t += Time.deltaTime * speed)
    //    {
    //        float a = Mathf.Lerp(startLevel, endLevel, t);
    //        text.color = new Color(text.color.r,
    //            text.color.g,
    //            text.color.b, a);
    //        yield return null;
    //    }
    //}

    private IEnumerator FadeTextIn()
    {
        yield return StartCoroutine(Fade(0.0f, 1.0f, 1.0f));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(Fade(1.0f, 0.0f, 1.0f));


        
    }


}
