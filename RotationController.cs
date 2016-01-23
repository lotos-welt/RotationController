/************************************************
RotationController.cs

Copyright (c) 2016 LotosLabo

This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
************************************************/

using UnityEngine;
using System.Collections;

/* オブジェクト回転クラス. */
[AddComponentMenu("LotoLabo/Event/RotationController")]
public class RotationController : MonoBehaviour {

    /// <summary>
    /// 回転するオブジェクト.
    /// </summary>
    public GameObject targetObject;

    /// <summary>
    /// 回転速度.
    /// </summary>
    private float rotationSpeed;

    /// <summary>
    /// ドラッグイベントハンドラ.
    /// </summary>
    public event System.EventHandler Drag;

    void Start() {
        // イベントの登録.
        this.Drag += DragHandler;

    // 端末の時は遅くする.
    #if UnityAndroid  || UnityiOS                                
            rotationSpeed = 0.01f;
    #endif

    // PCの時は早くする.
    #if UnityEditor_Windows || UnityEditor_Mac
            rotationSpeed = 0.1f;
    #endif
    }

    /// <summary>
    /// ドラッグ処理.
    /// </summary>
    private void OnDrag(Vector2 delta) {
        // イベントの登録.
        if (Drag != null) Drag(this, new System.EventArgs());
        float yMove = -delta.x * rotationSpeed * 10;

        // 回転.
        targetObject.transform.Rotate(0.0f, yMove, 0.0f, Space.World);
    }

    /// <summary>
    /// イベントハンドラー.
    /// </summary>
    void DragHandler(object sender, System.EventArgs e){
    }
    
}
