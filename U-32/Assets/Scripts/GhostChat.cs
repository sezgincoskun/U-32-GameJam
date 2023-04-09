using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChat : MonoBehaviour
{

    public GameObject chatWindow;
    public AudioClip button;
    public GameObject particle;

    private void Start()
    {
        chatWindow.SetActive(false);
    }

    public void Continue()
    {
        SoundManager.instance.PlaySoundFX(button, 0.5f);
        chatWindow.SetActive(false);
        Time.timeScale = 1;
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            chatWindow.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
