using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public static Collect instance;

    public int GoogleLogoAmount = 0;
    public int CourseraLogoAmount = 0;
    public int AcademyLogoAmount = 0;

    public int score;

    public Text GoogleLogoText;
    public Text CourseraLogoText;
    public Text AcademyLogoText;
    public Text scoreText;

    public AudioClip collet;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CollectGoogle"))
        {
            GoogleLogoAmount++;
            GoogleLogoText.text = GoogleLogoAmount.ToString();
            AddScore(25);
            SoundManager.instance.PlaySoundFX(collet, 0.4f);
            Destroy(collision.gameObject, 0);
        }

        if (collision.CompareTag("CollectCoursera"))
        {
            CourseraLogoAmount++;
            CourseraLogoText.text = CourseraLogoAmount.ToString();
            AddScore(15);
            SoundManager.instance.PlaySoundFX(collet, 0.4f);
            Destroy(collision.gameObject, 0);
        }

        if (collision.CompareTag("CollectAcademy"))
        {
            AcademyLogoAmount++;
            AcademyLogoText.text = AcademyLogoAmount.ToString();
            AddScore(20);
            SoundManager.instance.PlaySoundFX(collet, 0.4f);
            Destroy(collision.gameObject, 0);
        }
    }


    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    public void MateryalleriVer()
    {
        GoogleLogoAmount -= 3;
        CourseraLogoAmount -= 3;
        AcademyLogoAmount -= 3;
        GoogleLogoText.text = GoogleLogoAmount.ToString();
        CourseraLogoText.text = CourseraLogoAmount.ToString();
        AcademyLogoText.text = AcademyLogoAmount.ToString();
    }
}
