using System;
using Player;
using Tomi.TomiScripts;
using UnityEngine;

public class PlayerController : ManagedUpdateBehaviour
{
    private PlayerModel _playerModel;
    private Vector3 _direction = Vector3.zero;
    private bool _prevStatusV;
    private bool _prevStatusH;
    private bool _moveH;

    // Todas estas variables eran locales y se optimizo[?] al guardarlas de manera permanente
    // ya que no se crean y destruyen en cada update
    private float _v;
    private float _h;
    private bool _statusH;
    private bool _statusV;

    // cantidad de disparos por seg.
    [SerializeField] private float fireRate = 1f;

    // El tiempo en el que se disparó la última bala
    private float _lastFireTime;

    private void Awake()
    {
        _playerModel = GetComponent<PlayerModel>();
    }


    public override void UpdateMe()
    {
        //MoveLogic();
    }

#if UNITY_EDITOR && ENABLE_UPDATE
    private void Update()
    {
        MoveLogic();
        ShootLogic();
    }
#endif

    private void MoveLogic()
    {
        _v = Input.GetAxisRaw("Vertical");
        _h = Input.GetAxisRaw("Horizontal");

        _statusH = Input.GetButton("Horizontal");
        _statusV = Input.GetButton("Vertical");

        if (_statusH && !_prevStatusH)
            _moveH = true;
        if ((_statusV && !_prevStatusV) || !_statusH)
            _moveH = false;

        _direction = Vector3.zero;

        if (_statusV && !_moveH)
            _direction.z += _v;
        else if (_statusH) _direction.x += _h;

        _prevStatusV = _statusV;
        _prevStatusH = _statusH;

        _playerModel.Move(_direction);
    }

    private void ShootLogic()
    {
        if (!Input.GetKey(KeyCode.Space) || !(Time.time > _lastFireTime + 1f / fireRate)) return;
        _playerModel.PoolShoot();
        _lastFireTime = Time.time;
    }
}