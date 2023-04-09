using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public AudioClip click;

    public void Basla()
    {
        SoundManager.instance.PlaySoundFX(click, 0.3f);
        SceneManager.LoadScene("Level1");
    }

    public void Cik()
    {
        SoundManager.instance.PlaySoundFX(click, 0.3f);
        Application.Quit();
    }
}
