using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMotor : MonoBehaviour
{
    #region Variables
    [Header("Main Camera Properties")]
    [SerializeField]private Transform _player;
    [SerializeField]private Vector3 _offset = new Vector3(0, 5.0f, -10.0f);
    [SerializeField] private Vector3 _rotate = new Vector3(35, 0, 0);

    public bool isMoving { set; get; }
    #endregion
    
    #region Main Methods
    private void LateUpdate()
    {
        Vector3 DesiredPosition1 = _player.position + _offset;
        transform.position = Vector3.Lerp(_player.position + _offset, DesiredPosition1, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotate), 0.1f);
    }
    #endregion
}
