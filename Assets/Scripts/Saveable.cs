using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

[System.Serializable]
public class Saveable : MonoBehaviour
{
    public SaveData save_data;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public int id;
    public int scene_number;
    public virtual void Save() {}
    public virtual void Load() {}

    [ContextMenu("Save All")]
    public void SaveAll() {
        foreach (Saveable saveable in FindObjectsByType<Saveable>(FindObjectsSortMode.None)) {
            saveable.SaveableSave();
        }
    }


    [ContextMenu("Load All")]
    public void LoadAll() {
        foreach (Saveable saveable in FindObjectsByType<Saveable>(FindObjectsSortMode.None)) {
            saveable.SaveableLoad();
        }
    }

    [ContextMenu("Save")]
    public void SaveableSave() {
        transform.parent = null;
        position = transform.position;
        rotation = transform.rotation;
        scale = transform.localScale;
        Save();
    }
    [ContextMenu("Load")]
    public void SaveableLoad() {
        transform.parent = null;
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
        Load();
    }
    void Start() {
        scene_number = SceneManager.GetActiveScene().buildIndex;
    }
}