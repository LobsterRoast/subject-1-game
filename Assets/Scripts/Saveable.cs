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
    public Transform parent;
    public int id;
    public int scene_number;

    [ContextMenu("Save")]
    public void SaveAll() {
        foreach (Saveable saveable in FindObjectsByType<Saveable>(FindObjectsSortMode.None)) {
            saveable.Save();
        }
    }
    public void Save() {
        position = transform.localPosition;
        rotation = transform.rotation;
        scale = transform.localScale;
        parent = transform.parent;
        save_data.AddSaveData(this);
        save_data.CommitSaveData();
    }
    [ContextMenu("Load")]
    public void StartLoad() {
        save_data.LoadSceneData();
    }
    public void Load() {
        transform.parent = parent;
        transform.localPosition = position;
        transform.rotation = rotation;
        transform.localScale = scale;
    }

    void Start() {
        scene_number = SceneManager.GetActiveScene().buildIndex;
    }
}