using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] Animator fade;
    [SerializeField] AudioSource audioSource;

    public void StartFade()
    {
        fade.SetTrigger("Start");
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
