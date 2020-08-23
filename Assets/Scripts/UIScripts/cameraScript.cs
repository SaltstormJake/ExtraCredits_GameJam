﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    private Vector3 offset = new Vector3(0,15,-10);
    private float sensitivity = 10.0f;
    private Camera thisCam;
    private float rotationX;
    private float rotationY;
    void Awake()
    {
        thisCam = transform.GetChild(0).gameObject.GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(player.transform);
        transform.position = player.transform.position;
        thisCam.transform.localPosition = offset;
        Cursor.lockState = CursorLockMode.Locked;
        //transform.localPosition += offset;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse Y") * -sensitivity;
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -50, 25);
    }

    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }


}
