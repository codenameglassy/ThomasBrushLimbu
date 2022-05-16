using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
  

    [SerializeField] Transform _arm;
    float offset = -90;
    Vector3 _startingSize;
    Vector3 _armStartingSize;
    // Start is called before the first frame update
    void Start()
    {
        _startingSize = transform.localScale;
        _armStartingSize = _arm.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = _arm.position - mousePos;
        Quaternion val = Quaternion.LookRotation(Vector3.forward, perpendicular);
        val *= Quaternion.Euler(0, 0, offset);
        _arm.rotation = val;
    }
}
