using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour

{
    private static MusicManager musicManager;

    public AudioClip Sound1;
    public AudioClip Sound2;
    //public AudioClip Sound3;

    public AudioSource audioSource;
    string[] musicPath ;

    public void Awake()
    {
        audioSource.Play();
    }
    public void PlaySound1()
    {
        audioSource.clip = Sound1;
        audioSource.Play();
        DontDestroyOnLoad(audioSource);
    }
    public void PlaySound2()
    {
        audioSource.clip = Sound2;
        audioSource.Play();
        DontDestroyOnLoad(audioSource);
    }
    public void PlaySound3()
    {
        //audioSource.clip = Sound3;
        //audioSource.Play();
        //DontDestroyOnLoad(audioSource);
        string path = EditorUtility.OpenFilePanel("Overwrite with mp3","","mp3");
        musicPath = path.Split('/');
        string music = musicPath[musicPath.Length - 1];
        if (path.Length != 0)
        {
            Debug.Log(path);
            Debug.Log(music);

            //audioSource.clip = Resources.Load<AudioClip>(path);
           // audioSource = Get;
            DontDestroyOnLoad(audioSource);
        }
    }
    public void NoSound()
    {
        audioSource.Stop();
    }
}
