using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager Instance { get; private set; }

    public string lastPortalID;  // ID på portalen som användes

    public string targetPortalID; // ID för var man ska spawna

    public string lastScene;  // Scenen man kom ifrån


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

