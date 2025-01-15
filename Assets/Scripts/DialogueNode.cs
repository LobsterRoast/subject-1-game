using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueNode {
    public string text;
    public List<DialogueNode> next = new List<DialogueNode>();
    public DialogueOptionData[] dialogue_options = new DialogueOptionData[2];

}