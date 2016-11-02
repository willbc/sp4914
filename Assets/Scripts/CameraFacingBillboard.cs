using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour {

    Camera m_Camera;

    void Start() {
        //Transform player = GameObject.Find("Player");
        //m_Camera = player.transform.Find("MainCamera").GetComponent<Camera>();
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update() {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
