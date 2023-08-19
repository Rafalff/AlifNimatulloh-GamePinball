using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;

    private SwitchState state;
    private Renderer rendererz;
    public ScoreManager scoreManager;
    public float score;
    public AudioManager audioManager;
    public VFXManager VFXManager;

    private void Start()
    {
        rendererz = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();
            audioManager.PlaySwitchSFX(other.transform.position);
            VFXManager.PlaySwitchVFX(other.transform.position);
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            rendererz.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            rendererz.material = offMaterial;
            StartCoroutine(BlinkTimerStart(2));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
        scoreManager.AddScore(score);
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            rendererz.material = onMaterial;
            Debug.Log("Renderer material set to onMaterial.");
            yield return new WaitForSeconds(0.5f);
            rendererz.material = offMaterial;
            Debug.Log("Renderer material set to offMaterial.");
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(3));
        Debug.Log("Blink coroutine finished.");
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}