using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoruCevap : MonoBehaviour
{
    public GameObject ilkpanel;
    public GameObject soru1panel;
    public GameObject soru2panel;
    public GameObject soru3panel;
    public GameObject bitirispanel;

    public AudioClip hickirik;
    public AudioClip zort;
    public AudioClip click;
    public AudioClip hoca;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySoundFX(hoca, 1.2f);
            ilkpanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Anladim()
    {
        SoundManager.instance.PlaySoundFX(click, 0.3f);
        ilkpanel.SetActive(false);
        soru1panel.SetActive(true);
    }

    public void Soru1Cevap()
    {
        SoundManager.instance.PlaySoundFX(hickirik, 0.6f);
        soru1panel.SetActive(false);
        soru2panel.SetActive(true);
    }

    public void Soru2Cevap()
    {
        SoundManager.instance.PlaySoundFX(hickirik, 0.6f);
        soru2panel.SetActive(false);
        soru3panel.SetActive(true);
    }

    public void Soru3Cevap()
    {
        SoundManager.instance.PlaySoundFX(hickirik, 0.6f);
        soru3panel.SetActive(false);
        bitirispanel.SetActive(true);
    }

    public void Holey()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void Zort()
    {
        SoundManager.instance.PlaySoundFX(zort, 0.3f);
    }

}
