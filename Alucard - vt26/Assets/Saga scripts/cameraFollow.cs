using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;

    private Bounds  _cameraBounds;
    private Vector3 _targetPostion;
    private Camera _mainCamera;
    

    private void Awake() => _mainCamera = Camera.main;



    void Start()
    {
        offset = transform.position - target.position;

        var height = _mainCamera.orthographicSize;
        var width = height * _mainCamera.aspect;

        var minX = Globals.WorldBounds.min.x;
        var minY = Globals.WorldBounds.min.y;
        
        var maxX = Globals.WorldBounds.max.x;
        var maxY = Globals.WorldBounds.max.y;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(
            new Vector3 (minX , minY , 0.0f),
            new Vector3 (maxX , maxY , 0.0f)
            );
    }

    // Update is called once per frame
    void Update()
    {
        _targetPostion = target.position + offset;
        _targetPostion = GetCameraBounds();

        transform.position = _targetPostion;
    }

    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(_targetPostion.x, _cameraBounds.min.x, _cameraBounds.max.x),
            Mathf.Clamp(_targetPostion.y, _cameraBounds.min.y, _cameraBounds.max.y),
            transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector3(_cameraBounds.min.x, 0, 0),1);
        Gizmos.DrawCube(new Vector3(_cameraBounds.max.x, 0, 0), Vector3.one);
        Gizmos.DrawCube(new Vector3(0, _cameraBounds.min.y, 0), Vector3.one);
        Gizmos.DrawCube(new Vector3(0, _cameraBounds.max.y, 0), Vector3.one);
    }
}
