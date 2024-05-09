using SUPERCharacter;
using System;
using TMPro;
using UnityEngine;

public class Walkie : MonoBehaviour, IInteractable
{
    public string dialog;
    public bool hasSpeak;
    public event Action<string> OnSpeak;
    public TMP_Text m_Text;
    private SUPERCharacterAIO player;

    public string Dialog { get { return dialog; } }
    public bool HasSpeak { get { return hasSpeak; } }


    private void Start()
    {
        m_Text=GameObject.Find("Dialogo").GetComponent<TMP_Text>();
        player = FindAnyObjectByType<SUPERCharacterAIO>();
        
    }
    public void SetDialog(string dialog)
    {
        this.dialog = dialog;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            imInteractive();
        }
        if (player != null)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el transform del jugador.");
        }
    }

    public bool imInteractive()
    {
        OnSpeak?.Invoke(dialog); 
        print(dialog);
        m_Text.text = dialog;
        hasSpeak = true;
        return hasSpeak;
        
    }

    private void OnBecameInvisible()
    {
        if (hasSpeak)
        {
            KillWalkie();
        }
    }

    public void KillWalkie()
    {
        Destroy(gameObject);
    }
}