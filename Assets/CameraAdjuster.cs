using UnityEngine;
using System.Collections;

public class CameraAdjuster : MonoBehaviour
{
    void Start ()
    {
        var m = camera.projectionMatrix;
        m [0, 2] = -0.05f;
        m [1, 2] = -0.1f;
        camera.projectionMatrix = m;
    }
}