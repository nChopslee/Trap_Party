using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private int nextSceneIndex;
    private float transitionTime = 5.0f;
    private GameObject ps;
    private GameObject pd;
    private float dt = 5.0f;
    private bool hasTransitionStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("ScoreText");
        DontDestroyOnLoad(ps);
        pd = GameObject.Find("PlayerDeaths");
        DontDestroyOnLoad(pd);

    }

    private void Update()
    {
        Debug.Log("dt = " + dt);
        if (hasTransitionStarted)
        {
            dt -= Time.deltaTime;
            Debug.Log("dt = " + dt);
        }

        if(dt < 0.0f)
        {
            hasTransitionStarted = false;
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        


        Debug.Log("We're in the if statement, scene transition in bound");
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);



   

    }

    public void startTransition()
    {
        hasTransitionStarted = true;
        Debug.Log("Transition has started" + hasTransitionStarted);
    }



}
