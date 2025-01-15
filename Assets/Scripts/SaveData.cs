using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "Scriptable Objects/SaveData")]

public class SaveData : ScriptableObject {
    private JsonDocument json;
    private JsonElement root;
    public string save_file_path;
    // This could be done in one dictionary, but for faster loading, a separate hashmap is made for each scene.
    private Dictionary<int, Saveable> save_data = new Dictionary<int, Saveable>();
    public void AddSaveData(Saveable data) {
        JsonElement data_element = new JsonElement();
        if (!root.TryGetProperty(data.id.ToString(), out data_element)) {
        }
    }

    [ContextMenu("Commit Save Data")]
    public void CommitSaveData() {
    }
}
