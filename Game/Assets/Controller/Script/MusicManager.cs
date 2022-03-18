using UnityEngine;
public class MusicManager :OpenFile

{
    public AudioClip Sound1;
    public AudioClip Sound2;
    public AudioSource source;
    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlaySound1()
    {

    
        source.clip = Sound1;
        source.Play();
        source.loop = true;
        DontDestroyOnLoad(source);
    }
    public void PlaySound2()
    {

        source.clip = Sound2;
        source.Play();
        source.loop = true;
        DontDestroyOnLoad(source);
    }
    public void PlaySound3()
    {

        string path = selectFile();
        AudioType audioType = AudioType.MPEG;
        string url = string.Format("file://{0}", path);
        WWW www = new WWW(url);
        source.clip = www.GetAudioClip(true, true, audioType);
        source.Play();
        source.loop = true;
        DontDestroyOnLoad(source);

    }
    public void NoSound()
    {
        source.Stop();
    }
}
