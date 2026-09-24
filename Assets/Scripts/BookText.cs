using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BookText : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI bText;

    [SerializeField] private float animationDuration = 3.2f;
    [SerializeField] private float jumpHeight = 150f;
    [SerializeField] private float arcHeight = 150f;
    [SerializeField] private float finalScale = 0.1f;

    [SerializeField] private RectTransform spellTarget;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private float floatingWordScale = 1.3f;

    [SerializeField] private GameObject spell_book;
    private bool isAnimating = false;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isAnimating) return;

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(bText, eventData.position, eventData.pressEventCamera);

        if (linkIndex == -1) return;

        TMP_LinkInfo linkInfo = bText.textInfo.linkInfo[linkIndex];
        string linkId = linkInfo.GetLinkID();
        StartCoroutine(CollectWord(linkId, linkIndex));
        spell_book.GetComponent<Spell_Combo>().SetWord(linkId);
    }

    private IEnumerator CollectWord(string word, int linkIndex)
    {
        isAnimating = true;
        SoundManager.PlaySound(SoundType.WordRip, 0.1f);

        Vector3 startPosition = GetLinkScreenPosition(linkIndex);

        Vector3 targetPosition = GetTargetScreenPosition();

        RemoveLinkFromText(word);

        RectTransform floatingWord = CreateFloatingWord(word);

        floatingWord.transform.position = startPosition;
        floatingWord.transform.localScale = Vector3.one * floatingWordScale;

        yield return StartCoroutine(FlyToSpellbook(floatingWord, startPosition, targetPosition));

       

        playerInput.ActivateInput();
        Destroy(floatingWord.gameObject);

        isAnimating = false;
    }


    private Vector3 GetLinkScreenPosition(
    int linkIndex)
    {
        TMP_LinkInfo linkInfo =
            bText.textInfo.linkInfo[linkIndex];

        int firstCharacterIndex =
            linkInfo.linkTextfirstCharacterIndex;

        int lastCharacterIndex =
            firstCharacterIndex +
            linkInfo.linkTextLength - 1;

        TMP_CharacterInfo firstChar =
            bText.textInfo.characterInfo[
                firstCharacterIndex
            ];

        TMP_CharacterInfo lastChar =
            bText.textInfo.characterInfo[
                lastCharacterIndex
            ];

        Vector3 localCenter =
            (
                firstChar.bottomLeft +
                lastChar.topRight
            ) / 2f;

        Vector3 worldPosition =
            bText.transform.TransformPoint(
                localCenter
            );

        return worldPosition;
    }
    private Vector3 GetTargetScreenPosition()
    {
        return spellTarget.position;
    }

    private void RemoveLinkFromText(string word)
    {
        string text = bText.text;
        
        string search = "<link=\"" + word + "\">";
        string closing = "</link>";

        int startIndex = text.IndexOf(search);

        if(startIndex == -1) return;

        int contentSearch = startIndex + search.Length;
        int contentEnd = text.IndexOf(closing, contentSearch);

        if(contentEnd == -1) return;

        string before= text.Substring(0, startIndex);
        string after = text.Substring(contentEnd + closing.Length);

        bText.text = before + after;

    }

    private RectTransform CreateFloatingWord(string word)
    {
        GameObject wordObject = new GameObject("FloatingWord_" + word);

        wordObject.transform.SetParent(canvas.transform, false);

        RectTransform rectTransform = wordObject.AddComponent<RectTransform>();

        TextMeshProUGUI floatingText = wordObject.AddComponent<TextMeshProUGUI>();

        floatingText.text = word;

        floatingText.fontSize = bText.fontSize;
        floatingText.font = bText.font;
        floatingText.fontStyle = FontStyles.Bold;
        floatingText.alignment = TextAlignmentOptions.Center;
        floatingText.color = Color.red;

        rectTransform.sizeDelta = new Vector2(300f, 100f);

        return rectTransform;
    }

    private IEnumerator FlyToSpellbook(RectTransform word, Vector3 start, Vector3 target)
    {

        float time = 0f;

        Vector3 midpoint = Vector3.Lerp(start, target, 0.5f);

        Vector3 controlPoint = midpoint + Vector3.up * jumpHeight;

        while (time < animationDuration)
        {
            playerInput.DeactivateInput();

            time += Time.deltaTime;

            float t = Mathf.Clamp01(time / animationDuration);

            float smoothT = Mathf.SmoothStep(0f, 1f, t);

            Vector3 position = Mathf.Pow(1f - smoothT, 2f) * start + 2f * (1f - smoothT) * smoothT * controlPoint + Mathf.Pow(smoothT, 2f) * target;

            position += Vector3.up * Mathf.Sin(smoothT * Mathf.PI) * arcHeight;

            word.position = position;

            word.Rotate( 0f, 0f, 360f * Time.deltaTime);

            float scale =Mathf.Lerp(floatingWordScale, finalScale, smoothT);

            word.localScale =
                Vector3.one * scale;

            yield return null;
        }

        word.position =
            target;
    }

    

}
