using System.Collections;
using TMPro;
using UnityEngine;

public class SpellLearned : MonoBehaviour
{
    [SerializeField] private GameObject spellLearnedText;
    [SerializeField] private float fadeTime = 0.1f;
    private TextMeshProUGUI text;


    private void Start()
    {
        text = spellLearnedText.GetComponent<TextMeshProUGUI>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

    }


    public void textIn()
    {

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


    private IEnumerator FadeTextIn()
    {
        yield return StartCoroutine(Fade(0.0f, 1.0f, 1.0f));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(Fade(1.0f, 0.0f, 1.0f));


        
    }


}
