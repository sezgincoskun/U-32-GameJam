using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Sifre : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject passWindow;
    public GameObject matWindow;

    public Collect collect;
    public AudioClip click;

    public void EntPass()
    {
        if (input.text == "1987")
        {
            SoundManager.instance.PlaySoundFX(click, 0.3f);
            SceneManager.LoadScene("Level3");
            Time.timeScale = 1;
        }
        else
        {
            SoundManager.instance.PlaySoundFX(click, 0.3f);
            input.text = "Sifre Yanlis";
        }
    }


    public void Ver()
    {
        if (collect.GoogleLogoAmount > 2 && collect.CourseraLogoAmount > 2 && collect.AcademyLogoAmount > 2)
        {
            SoundManager.instance.PlaySoundFX(click, 0.3f);
            collect.MateryalleriVer();
            matWindow.SetActive(false);
            passWindow.SetActive(true);
        }

    }

    public void Verme()
    {
        SoundManager.instance.PlaySoundFX(click, 0.3f);
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            matWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
