using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    public Material normalMaterial; // Assign this material in the Inspector
    public Material maxHoldMaterial; // Assign this material in the Inspector

    private Renderer renderer;
    private bool isHold;

    private void Start()
    {
        isHold = false;
        renderer = GetComponent<Renderer>(); // Initialize the renderer
        renderer.material = normalMaterial; // Set the initial material
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            // Update the color based on hold time
            float normalizedTime = Mathf.Clamp01(timeHold / maxTimeHold);
            renderer.material.Lerp(normalMaterial, maxHoldMaterial, normalizedTime);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        renderer.material = normalMaterial; // Reset the material color
    }
}
