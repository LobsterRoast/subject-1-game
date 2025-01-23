using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueOption : S1Button
{
    public TextMeshProUGUI tmp;

    public void Init(DialogueOptionData option) {
        gameObject.SetActive(true);
        tmp.text = option.option_text;
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
