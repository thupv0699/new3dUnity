using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamPosScript : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject attackPos;
    [SerializeField] GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            GameObject carObject = Instantiate(car, transform.position, transform.rotation);
        }
    }
}
