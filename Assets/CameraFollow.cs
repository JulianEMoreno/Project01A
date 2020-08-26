using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow = null;

    Vector3 _objectOffset;


    private void Awake()
    {
        //create an offset between this position and object's position 
        _objectOffset = this.transform.position - _objectToFollow.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = _objectToFollow.position + _objectOffset;
    }
}
