﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine2Move : MonoBehaviour
{
    //USED FOR DUMP TRUCK
    [SerializeField] private float speed;
    [SerializeField] private float precision;
    [SerializeField] private Transform[] moveSpots;
    [SerializeField] private Animator machineAnimator;

    private bool enable = false;
    [HideInInspector] public bool tagged = false;
    [HideInInspector] public int lapCount;
    private int arrayPosition = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enable && tagged)
        {
            //transform.position = Vector3.MoveTowards(transform.position, moveSpots[arrayPosition].position, speed * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speed;

            Quaternion lookDirection = Quaternion.LookRotation(moveSpots[arrayPosition].position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, 30 * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveSpots[arrayPosition].position) < precision)
            {
                if (arrayPosition < moveSpots.Length - 1)
                    arrayPosition++;
                else
                {
                    arrayPosition = 0;
                    lapCount++;
                }
            }
        }
    }

    public void start()
    {
        if (enable)
        {
            machineAnimator.SetBool("moving", false);
            enable = false;
        }
        else
        {
            lapCount = 0;
            machineAnimator.SetBool("moving", true);
            enable = true;
        }
    }
}

