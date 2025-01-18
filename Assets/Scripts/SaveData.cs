using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Text.Json.Nodes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;
using UnityEditor.Search.Providers;

[CreateAssetMenu(fileName = "SaveData", menuName = "Scriptable Objects/SaveData")]

public class SaveData : ScriptableObject {
    // Save data is handled via json
    // Yes, it's easily manipulatable so people could theoretically put themselves at the end of the game.
    // That's the point. You paid for the game; if you wanna skip 90% of it, that's your perogative.
    private JsonNode root;
    public string save_file_path;

    private int ObjectCountInScene(string scene_number_string) {
        return root[scene_number_string].AsObject().Count;
    }
    
    // Saved object data is broken up by scenes. This function ensures that a scene
    // already has an element in the json file.
    private void EnsureSceneDataExists(int scene_number) {
        JsonObject root_object = root.AsObject();
        string scene_number_string = scene_number.ToString();
        if (!root_object.ContainsKey(scene_number_string))
            root_object[scene_number_string] = new JsonObject();
    }
    public void LoadJsonData(string file_name) {
        save_file_path = Path.Combine(Application.persistentDataPath, file_name);
        root = JsonNode.Parse(File.ReadAllText(save_file_path));
    }
    public void CommitSaveData() {
        File.WriteAllText(save_file_path, root.ToJsonString());
    }
    public void SaveObj(Saveable<int> data) {
        LoadJsonData("Test.json");
        EnsureSceneDataExists(data.scene_number);
        string id_string = data.id.ToString();
        string scene_number_string = data.scene_number.ToString();
        if (!root[scene_number_string].AsObject().ContainsKey(id_string)) {
            root[scene_number_string][id_string] = new JsonObject();
        }
        root[scene_number_string][id_string] = JsonNode.Parse(JsonUtility.ToJson(data, true));
        CommitSaveData();
    }
    public Saveable<int> LoadObj(Saveable<int> saveable) {
        LoadJsonData("Test.json");
        string scene_number_string = saveable.scene_number.ToString();
        string id_string = saveable.id.ToString();
        if (!root.AsObject().ContainsKey(scene_number_string)) throw new NullReferenceException();
        if (!root[scene_number_string].AsObject().ContainsKey(id_string)) throw new NullReferenceException();
        string object_json_data = root[scene_number_string][id_string].ToJsonString();
        return JsonUtility.FromJson<Saveable<int>>(object_json_data);
    }
}
