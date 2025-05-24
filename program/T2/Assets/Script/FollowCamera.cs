using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform player;
    private float sensitivity = 0.35f;
    float rotationY = 0;
    public Vector3 offset = new Vector3(0, 6, -8);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = p.position + new Vector3(0,6,-8);
        /*
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            rotationY += mouseX * sensitivity;
        }
        */
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Moved)
            {
                rotationY += touch.deltaPosition.x * sensitivity;
            }
        }
        
        Quaternion rotation = Quaternion.Euler(0, rotationY, 0); // 이만큼 돌릴꺼다
        Vector3 rotatedOffset = rotation * offset;  // 어디다가? 카메라에 다가
        Vector3 targetPosition = player.position + rotatedOffset; // 그리고 그 방향백터에 플레이어와의 거리를 더해서 태양과 지구저럼 공전시킬꺼다 즉 rotatedOffset의 방향을 회전시키는것

        transform.position = targetPosition;//Vector3.Lerp(transform.position, targetPosition, 2 * Time.deltaTime);
        transform.LookAt(player.position + Vector3.up * 1.5f);


    }
    
    
}
