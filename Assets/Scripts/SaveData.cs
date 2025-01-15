using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Text.Json.Nodes;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SaveData", menuName = "Scriptable Objects/SaveData")]

public class SaveData : ScriptableObject {
    // Save data is handled via json
    // Yes, it's easily manipulatable so people could theoretically put themselves at the end of the game.
    // That's the point. You paid for the game; if you wanna skip 90% of it, that's your perogative.
    private JsonNode root;
    public string save_file_path;
    
    // Saved object data is broken up by scenes. This function ensures that a scene
    // already has an element in the json file.
    private void EnsureSceneDataExists(int scene_number) {
        Debug.Log(Application.persistentDataPath);
        JsonObject root_object = root.AsObject();
        string scene_number_string = scene_number.ToString();
        if (!root_object.ContainsKey(scene_number_string))
            root_object[scene_number_string] = new JsonObject();
    }
    public void LoadJsonData(string file_name) {
        save_file_path = Path.Combine(Application.persistentDataPath, file_name);
        root = JsonNode.Parse(File.ReadAllText(save_file_path));
    }
    public List<Saveable> LoadSceneData() {
        List<Saveable> scene_objects_data = new List<Saveable>();
        int current_scene = SceneManager.GetActiveScene().buildIndex;

        return scene_objects_data;
    }
    public void AddSaveData(Saveable data) {
        LoadJsonData("Test.json");
        EnsureSceneDataExists(data.scene_number);
        string id_string = data.id.ToString();
        string scene_number_string = data.scene_number.ToString();
        if (!root[scene_number_string].AsObject().ContainsKey(id_string)) {
            root[scene_number_string][id_string] = new JsonObject();
        }
        root[scene_number_string][id_string] = JsonNode.Parse(JsonUtility.ToJson(data, true));
    }
    public void CommitSaveData() {
        FileStream json_file = File.OpenWrite(save_file_path);
        byte[] bytes = Encoding.UTF8.GetBytes(root.ToJsonString());
        json_file.Write(bytes);
        json_file.Dispose();
    }
}
