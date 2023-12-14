using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 PositionOffset = Vector3.zero;
    public float LerpSpeed = 5f;

    protected Vector2 targetPos = Vector2.zero;
    protected Vector2 _initialOffset = Vector2.zero;

    private PlayerWeaponHandler _weaponHandler;
    void Start()
    {
        _weaponHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_weaponHandler == null)
            return;

        targetPos = Vector2.Lerp(targetPos, _weaponHandler.AimPosition(), Time.deltaTime * LerpSpeed);
        transform.position = new Vector3(targetPos.x  + PositionOffset.x, targetPos.y + PositionOffset.y, PositionOffset.z);
    }
}
