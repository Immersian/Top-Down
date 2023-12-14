using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private RectTransform _reticle;
    // Start is called before the first frame update
    void Start()
    {
        _reticle = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_reticle == null)
        {
            return;
        }
        _reticle.position = Input.mousePosition;

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
    }
}
