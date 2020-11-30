using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private Material _groundMaterial;
    private float _elpTime = 0f;
    private float _range;

    private void Update()
    {
        _range = Random.Range(0, 0.0008f);
        _elpTime += Time.deltaTime;
        if (_elpTime >= GameManager.instance.SpeedDuration)
        {
            _elpTime = 0;
            GameManager.instance.Speed += 2f;
            _groundMaterial.SetFloat("_Curvature", _range);
        }
        transform.position -= (transform.forward * Time.deltaTime).normalized * GameManager.instance.Speed * Time.deltaTime; 
    }
}