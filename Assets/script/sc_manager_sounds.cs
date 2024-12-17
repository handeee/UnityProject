using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_manager_sounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> Musics;
    [SerializeField] private AudioSource AudioSrc;
    [SerializeField] private AudioClip currentMusicClip;
    private Scene CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScene=SceneManager.GetActiveScene();
        Debug.Log("Current Scene.Name" + CurrentScene.name + "-Index:" + CurrentScene.buildIndex);
        if (CurrentScene.buildIndex == 1) {
            Debug.Log("play music");
            if (AudioSrc!=null && currentMusicClip != null) {
                this.AudioSrc.clip= currentMusicClip;
                AudioSrc.Play();
                AudioSrc.loop= true;
            }
            else {
                Debug.Log("music clip is null");
            }
        }
    }

    public void playBackgroundMusic(AudioClip audioClip)
    {
        if(AudioSrc!=null && audioClip != null)
        {
            this.AudioSrc.clip= audioClip;
            AudioSrc.Play();
        }
    }

  
}
