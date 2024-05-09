using SUPERCharacter;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CleanUp : Mission, IInteractable
    {
        public override event Action<IMission> OnMissionCompleted;
        [SerializeField] Fade fade;
        

        public bool imInteractive()
        {
            if (hasFinished) return false;

            hasFinished = true;
            isEnabled = false;
            OnMissionCompleted?.Invoke(this);
            fade.StartFade();

            return true;
        }

        private void OnTriggerEnter(Collider other)
        {
            imInteractive();
        }
    }
}