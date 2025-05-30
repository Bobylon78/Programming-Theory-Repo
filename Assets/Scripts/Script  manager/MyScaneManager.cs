using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScaneManager : MonoBehaviour
{
    public static MyScaneManager Instance;

    public AudioSource audioSource;
    public AudioClip introClip;
    public AudioClip introLoopClip;
    public AudioClip simulationLoopClip;
    private bool clipJouer = false;

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
    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "Menue_Start")
        {
            JouerAudioIntro();
        }
    }
    public void Lancement()
    {
        SceneManager.LoadScene("Simulation");
        if(simulationLoopClip != null)
        {
            audioSource.clip = simulationLoopClip;
            audioSource.Play();
        }
    }
    void JouerAudioIntro()
    {
        if (audioSource != null && introClip != null)
        {
            audioSource.loop = false;
            audioSource.clip = introClip;
            audioSource.Play();
            StartCoroutine(FinClipIntro());
        }
    }
    System.Collections.IEnumerator FinClipIntro()
    {
        yield return new WaitForSeconds(introClip.length);

        if(introLoopClip !=null)
        {
            audioSource.clip = introLoopClip;
            audioSource.loop = true;
            audioSource.Play();
            clipJouer = true;
        }
    }
}
