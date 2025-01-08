using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    Scene currentScene;
    public GameObject restartButton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        restartButton = GameObject.Find("Restart");
        restartButton.SetActive(false);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Detects if the player object still exists
        if (player == null)
        {
            restartButton.SetActive(true);  
        }
    }

    // When called this function reloads the level, resetting it to its initial state
    public void Restart()
    {
        SceneManager.LoadScene(currentScene.path);

    }
}
