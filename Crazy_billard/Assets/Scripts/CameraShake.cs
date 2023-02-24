using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private Tween shake;

    private Vector3 initialPos;

    private void Start()
    {
        initialPos = this.transform.position;    
    }

    public void ShakeCam()
    {
        shake?.Kill();
        this.transform.position = initialPos;
        shake = this.transform.DOShakePosition(0.5f);
    }
}
