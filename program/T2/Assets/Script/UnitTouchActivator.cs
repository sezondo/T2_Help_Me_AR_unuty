using UnityEngine;

public class UnitTouchActivator : MonoBehaviour
{
     public GameObject statusPanel; // Inspector에서 캔버스 패널 드래그

    void OnMouseDown()   // 마우스 클릭(PC) 또는 터치(모바일, 콜라이더 필요)
    {
        statusPanel.SetActive(true);
    }
}
