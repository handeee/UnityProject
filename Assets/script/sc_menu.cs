using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sc_menu : MonoBehaviour
{
    Scene Current_Scene;
    // Start is called before the first frame update
    void Start()
    {
        Current_Scene = SceneManager.GetActiveScene();
        Debug.Log("Current Scene.Name"+Current_Scene.name+"-Index:"+Current_Scene.buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Func_StartGame()
    {
        Debug.Log("start Game");
        SceneManager.LoadScene(Current_Scene.buildIndex + 1);
    }
}
