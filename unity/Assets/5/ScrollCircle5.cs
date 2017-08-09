using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollCircle5 : ScrollRect
{
    public Action startDrag;
    public Action<Vector3> dragging;
    public Action endDrag;

    private float recoveryTime = 0.1f;//值越大恢复越快
    private float mRadius;
    private bool isOnEndDrag = false;
    private Vector3 offsetVector3 = Vector3.zero;

    void Start()
    {
        inertia = false;
        movementType = MovementType.Unrestricted;
        //计算摇杆块的半径  
        mRadius = (transform as RectTransform).sizeDelta.x * 0.5f;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (startDrag != null)
            startDrag();
    }
    public override void OnScroll(PointerEventData data)
    {
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        isOnEndDrag = false;
        var contentPostion = this.content.anchoredPosition;
        if (contentPostion.magnitude > mRadius)
        {
            contentPostion = contentPostion.normalized * mRadius;
            SetContentAnchoredPosition(contentPostion);
        }

        if (dragging != null)
            dragging(offsetVector3);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!isOnEndDrag)
            isOnEndDrag = true;
        if (endDrag != null)
            endDrag();
    }

    void Update()
    {
        UpdateContent();
    }

    /// <summary>  
    /// 摇杆小球复位  
    /// </summary>  
    public void UpdateContent()
    {
        if (isOnEndDrag)
        {
            if (content.localPosition == Vector3.zero)
                isOnEndDrag = false;
            float x = Mathf.Lerp(content.localPosition.x, 0.0f, recoveryTime);
            float y = Mathf.Lerp(content.localPosition.y, 0.0f, recoveryTime);
            content.localPosition = new Vector3(x, y, content.localPosition.z);
        }
        CalculateOffset();
    }
    /// <summary>  
    /// 计算偏移量  
    /// </summary>  
    private void CalculateOffset()
    {
        offsetVector3 = content.localPosition / mRadius;
    }
    ///// <summary>  
    ///// 获取偏移量大小  
    ///// 偏移量范围是[-1,1]  
    ///// </summary>  
    ///// <returns></returns>  
    //public Vector3 GetOffsetVector3()
    //{
    //    return offsetVector3;
    //}
}