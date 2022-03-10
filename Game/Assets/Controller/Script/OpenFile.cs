#if UNITY_EDITOR
using UnityEditor;
#endif 
using UnityEngine;

public class OpenFile : MonoBehaviour
{  public string selectFile()
    {
        string path = EditorUtility.OpenFilePanel("Overwrite with mp3", "", "mp3");
        return path;
    }
}
