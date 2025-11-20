using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float gravity = -9.8f;
    [SerializeField]
    private GameManager gm;

    private void Start()

    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * gravity + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
