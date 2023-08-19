using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BumperControl : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;
    public float multiplier;
    public Color color;
    private Renderer rendererz;
    private Animator animator;
    public AudioManager audioManager;
    public VFXManager VFXManager;
    public ScoreManager scoreManager;
    public float score;


    private void Start()
    {
        // karena material ada pada component Rendered, maka kita ambil renderernya
        rendererz = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        // kita akses materialnya dan kita ubah warna nya saat Start
        rendererz.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            animator.SetTrigger("Hit");
            audioManager.PlaySFX(collision.transform.position);
            VFXManager.PlayVFX(collision.transform.position);
            scoreManager.AddScore(score);
        }
    }
}
