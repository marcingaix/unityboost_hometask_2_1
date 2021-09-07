using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{

    public GameObject clockMarkerSmallPrefab;
    public GameObject clockMarkerBigPrefab;
    public GameObject clockArrowHoursPrefab;
    public GameObject clockArrowSecondsPrefab;

    private List<GameObject> markerInstances = new List<GameObject>();

    private GameObject hoursArrow;
    private GameObject secondsArrow;

    // Start is called before the first frame update
    void Start()
    {
        HourMarkersInit();
        ArrowsInit();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateArrows();
    }

    private void HourMarkersInit()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject marker;
            if (i % 3 == 0)
            {
                marker = Instantiate(clockMarkerBigPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else
            {
                marker = Instantiate(clockMarkerSmallPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
            marker.transform.Rotate(360f / 12 * i, 0, 0);
            markerInstances.Add(marker);
        }
    }

    private void ArrowsInit()
    {
        hoursArrow = Instantiate(clockArrowHoursPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        secondsArrow = Instantiate(clockArrowSecondsPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void UpdateArrows()
    {
        hoursArrow.transform.localRotation = Quaternion.Euler(-(System.DateTime.Now.Hour - 12) * 30, 0, 0); // 12*30 = 360
        secondsArrow.transform.localRotation = Quaternion.Euler(-System.DateTime.Now.Second * 6, 0, 0); // 60*6 = 360
    }

}
