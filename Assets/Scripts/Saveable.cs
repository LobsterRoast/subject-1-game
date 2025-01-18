using UnityEngine.SceneManagement;

[System.Serializable]
public class Saveable<T> {
    public T data;
    public int id;
    public int scene_number;
    public Saveable(T data, int id) {
        scene_number = SceneManager.GetActiveScene().buildIndex;
        this.id = id;
        this.data = data;
    }
}
