using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBreakable : MonoBehaviour
{
    public GameObject wall, brokenwall;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            wall.SetActive(false);
            Instantiate(brokenwall,transform.position,transform.rotation);
        }
    }
}
