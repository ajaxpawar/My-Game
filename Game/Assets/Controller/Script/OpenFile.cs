using System.Collections.Generic;
using System.IO;
using UnityEngine;
using EasyUI.Toast;

public class OpenFile : MonoBehaviour
{
    public string path = "";
    public string selectFile()
    {
        //Toast.Show("Avalable in Windows Only...");

#if UNITY_EDITOR
        if (Application.platform == RuntimePlatform.Android)
        {
            Toast.Show("Avalable in Windows Only...");
        }
        else
        {
            Toast.Show("Windows");
            path = UnityEditor.EditorUtility.OpenFilePanel("Overwrite with mp3", "", "mp3");
        }



#endif

        return path;
    }
}
