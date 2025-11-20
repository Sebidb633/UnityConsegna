using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ControllerPlayer : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField]
    private float inputZ;
    [SerializeField]
    private float inputX;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private AudioSource bonusEffect;
    [SerializeField]
    private AudioSource livesEffect;
    
    private Renderer rend;
    private Color originalColor;
    [SerializeField]
    private Color collectedColor;
    [SerializeField]
    private float colorDuration;

    private bool isInvincible = false;
    [SerializeField]
    private float invincibilityTime;

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().linearVelocity = new Vector3(inputX * speed, 0, inputZ * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameObject coin = collision.gameObject;
            coin.GetComponent<Collider>().enabled = false;
            rend = collision.gameObject.GetComponent<Renderer>();
            if (rend != null)
            {
                StartCoroutine(CollectEffect(rend, collision.gameObject));
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!isInvincible)
            {
                StartCoroutine(HandleEnemyHit());
            }
        }
    }

    private IEnumerator HandleEnemyHit()
    {
        isInvincible = true;
        livesEffect.Play();
        gameManager.LoseLife();

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
    }

    IEnumerator CollectEffect(Renderer rend, GameObject coin)
    {
        rend.material.color = collectedColor;
        bonusEffect.Play();
        gameManager.UpdateScore();
        yield return new WaitForSeconds(colorDuration);
        Destroy(coin);
    }

}
