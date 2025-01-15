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

    [ContextMenu("Save")]
    void Save() {
        position = transform.position;
        rotation = transform.rotation;
        scale = transform.localScale;
        save_data.AddSaveData(this);
        save_data.CommitSaveData();
        Debug.Log(JsonUtility.ToJson(this, true));
    }

    void Start() {
        scene_number = SceneManager.GetActiveScene().buildIndex;
    }
}