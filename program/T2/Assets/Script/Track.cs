using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.VisualScripting;
 
public class Track : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public List<GameObject> list1 = new List<GameObject>();
    private Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();
 
                     
 
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject o in list1)
        {
            dict1.Add(o.name, o);
        }
 
        
 
    }

    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;
 
        GameObject o = dict1[name];
        o.transform.position = t.transform.position;
        o.transform.rotation = t.transform.rotation;
        o.SetActive(true);
    }
 
    
 
 
    void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var t in eventArgs.added)
        {
            // Handle added event
            UpdateImage(t);
            
        }
 
        foreach (var t in eventArgs.updated)
        {
            // Handle updated event
            UpdateImage(t);
        }
 
        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
        }
    }
 
    void OnEnable() => manager.trackablesChanged.AddListener(OnChanged);
    void OnDisable() => manager.trackablesChanged.RemoveListener(OnChanged);
 
    
 
    
 
 
    // Update is called once per frame
    void Update()
    {
        
    }
}