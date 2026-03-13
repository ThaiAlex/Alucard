using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blood_Gauge : MonoBehaviour
{
    public int maxBlood = 20;
    public int currentBlood = 0;
    private Movement speed;

    public void Start()
    {
        speed = FindFirstObjectByType<Movement>();
    }

    public void Update()
    {
        if (currentBlood >= maxBlood)
        {
            currentBlood = maxBlood;
        }

        if (currentBlood == maxBlood)
        {
            Debug.Log("MAX BLOOD");
            if (currentBlood > 0)
            {
                StartCoroutine(BloodPower());
            }
        }

        if (currentBlood <= 1)
        {
            StartCoroutine(PowerStop());
        }
    }

    public void GainBlood(int bloodSpill)
    {
        currentBlood += bloodSpill;

    }
    IEnumerator BloodPower()
    {
        Debug.Log("Bloodpower");
        while (currentBlood > 0)
        {
            speed.moveSpeed = 8f;
            speed.jumpForce = 1200f;
            speed.cooldown = 1f;
            currentBlood -= 1;
            yield return new WaitForSeconds(0.25f);
        }
    }
    IEnumerator PowerStop()
    {
        speed.moveSpeed = 5f;
        speed.jumpForce = 1000f;
        speed.cooldown = 2f;
        Debug.Log("StopPower");
        yield return new WaitForSeconds(0.25f);
    }


}