using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class PlaceOnPlane : MonoBehaviour
{
    
    public GameObject previewPrefab;    // 미리보기용 프리팹 (반투명 등
    public GameObject objectToPlace; // 여기다가 Level_Start 프리팹 연결
    public string gameSceneName = "GameScene"; // 전환할 씬 이름
    private GameObject previewObject;
    private ARRaycastManager arRaycastManager;
    

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        previewObject = Instantiate(previewPrefab);
        previewObject.SetActive(false);
    }

    void Update()
    {
         if (arRaycastManager.Raycast(new Vector2(Screen.width/2, Screen.height/2), hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            previewObject.SetActive(true);
            previewObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);

            // 2. 화면 터치 시 해당 위치에 실제 오브젝트 배치 + 씬 전환
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                previewObject.SetActive(false);
                ARPlacementInfo.position = previewObject.transform.position;
                ARPlacementInfo.rotation = previewObject.transform.rotation;
                ARPlacementInfo.scale = previewObject.transform.localScale;

                // 씬 이동 (게임 메인 씬 이름 넣어주기)
                SceneManager.LoadScene(gameSceneName);
            }
        }
        else
        {
            previewObject.SetActive(false);
        }
    }
}
