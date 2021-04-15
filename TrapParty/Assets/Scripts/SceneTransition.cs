using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private int nextSceneIndex;
    private float transitionTime = 5.0f;
    private GameObject ps;
    
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("AdditiveScene", LoadSceneMode.Additive);
        //nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //ps = GameObject.FindGameObjectWithTag("PlayerScores");
    }

    public void LoadLevel()
    {
        //DontDestroyOnLoad(ps);
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        
    }

}
