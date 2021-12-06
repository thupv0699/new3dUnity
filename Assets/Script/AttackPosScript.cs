using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPosScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject car;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H)){
            GameObject newCar = Instantiate(car);
        }

    }
}
