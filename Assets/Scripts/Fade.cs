using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] Animator fade;
    [SerializeField] AudioSource audioSource;

    public void StartFade()
    {
        FindObjectOfType<GameManager>().AddTime(2);
        fade.SetTrigger("Start");
    }

    public void PlayAudio()
    {
        if (audioSource)
            audioSource.Play();
    }

    public void StopAudio()
    {
        if (audioSource)
            audioSource?.Stop();
    }
}
