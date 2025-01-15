using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueOption : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public void Init(DialogueOptionData option) {
        gameObject.SetActive(true);
        tmp.text = option.option_text;
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public static void ResetButtons() {
        EventSystem.current.SetSelectedGameObject(null);
    }
}

[Serializable]
public class DialogueOptionData {
    public string option_text;
}
