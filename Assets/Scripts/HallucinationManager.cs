using System.Collections;
using UnityEngine;

public class HallucinationManager : MonoBehaviour
{
    [SerializeField] Animator animators;
    float hallucionationGap;
    State state;
    int hallucinationIdx;

    enum State
    {
        None,
        Running,
        Waiting
    }

    public void ShowHallucination()
    {
        var rand = UnityEngine.Random.Range(0, 3);

        animators.enabled = true;
        animators.SetTrigger("Start");
    }

    public void StopHallucinations()
    {
        state = State.None;
        hallucinationIdx = 0;
        animators.enabled = false;
    }

    private void ChangeDay()
    {
        hallucionationGap = 0;
        state = State.None;
    }
}

public interface IHallucination
{

}