using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScaneManager : MonoBehaviour
{
    public static MyScaneManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void Lancement()
    {
        SceneManager.LoadScene("Simulation");
    }
}
