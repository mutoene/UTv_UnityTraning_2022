using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    // 銃のOVRGrabbable
    [SerializeField] private OVRGrabbable _grabbable;
    
    // 左右のOVRGrabberがアタッチされたオブジェクト
    [SerializeField] private GameObject _OVRGrabberLObj;
    [SerializeField] private GameObject _OVRGrabberRObj;

    // 弾の生成位置
    [SerializeField] private GameObject _firePos;
    // 弾のPrefab
    [SerializeField] private GameObject _shellPrefab;
    // 発射時に加える力
    [SerializeField] private float _power;

    private OVRGrabber _currentHand;
    
    private void Update()
    {
        // 掴まれている時
        if (_grabbable.isGrabbed)
        {
            _currentHand = _grabbable.grabbedBy;

            // 左手で掴まれており、左のトリガーボタンが押されたとき
            if (_currentHand.gameObject == _OVRGrabberLObj && OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                Fire();
            }
            // 右手で掴まれており、右のトリガーボタンが押されたとき
            else if (_currentHand.gameObject == _OVRGrabberRObj && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                Fire();
            }
        }
    }

    /// <summary>
    /// 弾を_firePosに生成し、力を加える
    /// </summary>
    private void Fire()
    {
        var shell = Instantiate(_shellPrefab, _firePos.transform.position, _firePos.transform.rotation);
        shell.GetComponent<Rigidbody>().AddForce(_firePos.transform.forward * _power, ForceMode.Impulse);
    }
}
