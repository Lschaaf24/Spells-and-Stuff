using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float textSpeed;

    private string[] lines;
    private int index;

    private bool isTyping;

    private void Start()
    {
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (lines == null)
            return;

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("MOUSE CLICK");

            if (isTyping)
            {
                StopAllCoroutines();

                textComponent.text = lines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        if (dialogueLines == null || isTyping == true)
        {
            Debug.LogWarning("Tried to start dialogue with no dialogue lines.");
            return;
        }

        index = 0;
        gameObject.SetActive(true);
        lines = dialogueLines;

        textComponent.text = string.Empty;

        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;

            textComponent.text = string.Empty;

            StartCoroutine(TypeLine());
        }
        else
        {
            UIManager.instance.setCurrentState(UIState.play);

            Debug.Log("DIALOGUE FINISHED");
        }
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;

        yield return null;

        foreach (char c in lines[index])
        {
            textComponent.text += c;

            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }



}
