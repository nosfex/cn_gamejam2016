using UnityEngine;
using System.Collections;
public class CamManagerSlider : MonoBehaviour
{
    public Player Bad;
    public Player Good;
    public Camera myCamera;
    // Use this for initialization
    void Start()
    {
        myCamera = gameObject.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        CamScroler();
    }
    public void CamScroler()
    {
        float x = (Good.gameObject.transform.position.x + Bad.gameObject.transform.position.x) / 2;

        x = Mathf.Clamp(x, 632.0f, 640.0f);
        Vector3 midPoint = new Vector3(x, myCamera.gameObject.transform.position.y, myCamera.gameObject.transform.position.z);
        myCamera.gameObject.transform.position = midPoint;
    }
}