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
    public virtual void Save() {
    }
    public virtual void Load() {
    }

    void Start() {
        scene_number = SceneManager.GetActiveScene().buildIndex;
    }
}