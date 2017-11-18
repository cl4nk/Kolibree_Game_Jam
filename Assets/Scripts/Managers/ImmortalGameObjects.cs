using UnityEngine;

public class ImmortalGameObjects : MonoBehaviour
{
    public GameObject[] GameObjects;

	void Awake()
    {
        foreach (GameObject gameobject in GameObjects)
            DontDestroyOnLoad(gameobject);
    }
}
