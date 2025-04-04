using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DialogueNode {
    public string key;
    public string text;
    public List<String> next = new List<String>();
    public DialogueOptionData[] dialogue_options = new DialogueOptionData[2];
    public string set_default_dialogue_key;
    public Action execution_function;
    public UnityEvent execution;
}