using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RedPotion : MonoBehaviour, IItem
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
