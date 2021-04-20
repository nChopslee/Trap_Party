using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private int nextSceneIndex;
    private float transitionTime = 5.0f;
   
    //public MusicControl musicSystem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevel()
    {

        //DontDestroyOnLoad(ps);
        //musicSystem.Stop();
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        
    }

}
