using UnityEngine;
using System.Collections;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 60.0f;

    GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;
    GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {
        if (m_target) {
            //if (m_lastKnownPosition != m_target.transform.position) {
                //m_lastKnownPosition = m_target.transform.position;
                //m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            //}

            Debug.Log(transform.rotation);
            Debug.Log(m_lookAtRotation);
            //if (transform.rotation != m_lookAtRotation) {
//                m_lookAtRotation.x = 0.0f;
//                m_lookAtRotation.y = 0.0f;
//                m_lookAtRotation.z = 0.0f;
//                m_lookAtRotation.w = 0.0f;
                Vector3 lookPosition = m_target.transform.position - (transform.forward);
//                Debug.Log(player.transform.position);
//                Debug.Log(lookPosition);
                //lookPosition.y = 0;
                lookPosition.z = 0;
                //lookPosition.x = 0;
                float xTemp;
                float yTemp;
                float zTemp;
                zTemp = lookPosition.z;
                lookPosition.z = lookPosition.y;
                lookPosition.y = zTemp;
                Quaternion lookRotation = Quaternion.LookRotation(lookPosition);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * speed);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            //}
        }
    }

    public void SetTarget(GameObject target) {
        m_target = target;
    }
}