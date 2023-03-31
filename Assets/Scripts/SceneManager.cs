using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private MusicPlayer musicPlayer;
    public AudioMusic audioMusic;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevelOne()
    {
        musicPlayer.PlayMusic(audioMusic);
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
    }
}
