using System.Collections;
using TMPro;
using UnityEngine;

public class SpellLearned : MonoBehaviour
{
    [SerializeField] private GameObject spellLearnedText;

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

    private IEnumerator Fade(float startLevel, float endLevel, float time)
    {
        float speed = 1.0f / time;



        for (float t = 0.0f; t < 1.0; t += Time.deltaTime * speed)
        {
            float a = Mathf.Lerp(startLevel, endLevel, t);
            text.color = new Color(text.color.r,
                text.color.g,
                text.color.b, a);
            yield return 0;
        }
    }

    private IEnumerator FadeTextIn()
    {
        yield return StartCoroutine(Fade(0.0f, 1.0f, 1.0f));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(Fade(1.0f, 0.0f, 1.0f));

    }


}
