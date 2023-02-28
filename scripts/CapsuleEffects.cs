using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Capsule")
        {
            transform.Rotate(0.3f, 0, 0);
        }
    }
}
