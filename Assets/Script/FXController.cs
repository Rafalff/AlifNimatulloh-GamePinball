using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXController : MonoBehaviour
{
    private void Start()
    {
        // kita langsung hapus game objectnya setelah 1 detik
        Destroy(gameObject, 3.0f);
    }
}
