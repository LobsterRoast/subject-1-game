using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DialogueController : MonoBehaviour
{
    private static GameObject dialogue_box;
    private static TextMeshProUGUI tmp;
    private static DialogueOption option_1;
    private static DialogueOption option_2;
    private Saveable<int> initial_node_getter;
    private bool dialogue_active;

    public bool options_open = false;
    public List<DialogueNode> dialogue_trees = new List<DialogueNode>();
    public DialogueNode active_dialogue_node;
    public SaveData save_data;
    public Dictionary<int, DialogueNode> dialogue_nodes = new Dictionary<int, DialogueNode>();
    public int save_id;
    private IEnumerator UpdateText() {
        tmp.text = "";
        for (int i = 1; (i <= active_dialogue_node.text.Length) && dialogue_active == true; i++) {
            tmp.text = active_dialogue_node.text.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    public void EndDialogue() {
        dialogue_box.SetActive(false);
        dialogue_active = false;
        save_data.SaveObj(initial_node_getter);
        CloseOptions();
    }

    private void CreateOptions() {
        options_open = true;
        tmp.enabled = false;
        option_1.Init(active_dialogue_node.dialogue_options[0]);
        option_2.Init(active_dialogue_node.dialogue_options[1]);
    }
    private void CloseOptions() {
        options_open = false;
        tmp.enabled = true;
        option_1.Close();
        option_2.Close();
    }
    private void ChangeNode(int index = 0) {
        active_dialogue_node = active_dialogue_node.next[index];
        initial_node_getter.data = active_dialogue_node.change_default_dialogue_tree;
        StartCoroutine(UpdateText());
    }
    public void Advance(int index) {
        ChangeNode(index);
        CloseOptions();
    }

    // Returns true if dialogue continues, and false if dialogue ends
    public bool Advance() {
        if (options_open) return true;
        if (active_dialogue_node.next.Count == 1) {
            ChangeNode();
            return true;
        }
        else if (active_dialogue_node.next.Count < 1) {
            EndDialogue();
            return false;
        }
        else {
            CreateOptions();
            return true;
        }
    }
    public void StartDialogue() {
        dialogue_active = true;
        active_dialogue_node = dialogue_trees[initial_node_getter.data];
        initial_node_getter.data = active_dialogue_node.change_default_dialogue_tree;
        dialogue_box.SetActive(true);
        StartCoroutine(UpdateText());
    }
    void Start() {
        initial_node_getter = new Saveable<int>(0, save_id);
        try {
            initial_node_getter = save_data.LoadObj(initial_node_getter);
        }
        catch(NullReferenceException _e) {}
        tmp = GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>();
        option_1 = GameObject.FindWithTag("Option1").GetComponent<DialogueOption>();
        option_2 = GameObject.FindWithTag("Option2").GetComponent<DialogueOption>();
        dialogue_box = GameObject.FindWithTag("DialogueBox");
        option_1.gameObject.SetActive(false);
        option_2.gameObject.SetActive(false);
        dialogue_box.SetActive(false);
    }
    void Update()
    {       
    }
}