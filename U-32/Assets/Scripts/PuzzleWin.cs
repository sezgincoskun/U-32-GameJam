using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleWin : MonoBehaviour
{
    private int pointsToWin = 25;
    public int points = 0;
    public GameObject winElements;
    public static PuzzleWin instance;
    public AudioClip click;


    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (points >= pointsToWin)
        {
            winElements.SetActive(true);
        }
    }

    public void AddPoints()
    {
        SoundManager.instance.PlaySoundFX(click, 0.3f);
        points++;
    }

    public void DevamEt()
    {
        SoundManager.instance.PlaySoundFX(click, 0.3f);
        SceneManager.LoadScene("Level2");
    }
}
