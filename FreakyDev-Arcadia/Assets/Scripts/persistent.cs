using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistent : MonoBehaviour
{

     private static persistent instance;

    void Awake()
    {
        // if (instance == null)
        // {
        //     instance = this;  // Set this as the active instance
        //     DontDestroyOnLoad(gameObject);  // Make this object persistent
        // }
        // else
        // {
        //     Destroy(gameObject);  // Destroy duplicate objects
        // }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
