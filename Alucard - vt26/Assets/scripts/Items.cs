using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class Items : ScriptableObject
{
    public string itemID;

    public int itemCount;

    public Sprite itemIcon;
   
}
public static class ScriptableObjectExtension
{
    public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
    {
        if (scriptableObject == null)
        {
            Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object");

            return (T)ScriptableObject.CreateInstance(typeof(T));
        }

        T instance = UnityEngine.Object.Instantiate(scriptableObject);

        instance.name = scriptableObject.name; //remove (Clone) from the name

        return instance;
    }
    
       


    
}


