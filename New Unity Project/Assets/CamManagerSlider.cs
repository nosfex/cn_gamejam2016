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
        myCamera.gameObject.transform.position = new Vector3((Good.gameObject.transform.position.x + Bad.gameObject.transform.position.x) / 2, myCamera.gameObject.transform.position.y, myCamera.gameObject.transform.position.z);
    }
}