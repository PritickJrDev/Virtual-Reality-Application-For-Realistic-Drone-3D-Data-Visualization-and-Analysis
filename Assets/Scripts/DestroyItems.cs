using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyItems : MonoBehaviour
{
    //public XRNode inputSource;
    //public InputHelpers.Button inputButton;
    //public float inputThreshold = 0.1f;

    public void DestroyItem1()
    {
       // if (Input.GetKeyDown(KeyCode.Mouse0))
      //  {
            Debug.Log("destroyed");
            Destroy(gameObject);
       // }
    }
}
