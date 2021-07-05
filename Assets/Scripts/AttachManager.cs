using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachManager : MonoBehaviour
{
    private GameObject claw_ref;

    float points = -500;

    GameObject scoreboard_ref;

    void Start()
    {
        claw_ref = GameObject.Find("IndustrialArm/industrial_robot_arm_claw/controller_base/controller_arm/bone_arm/controller_head/bone_head/controller_end_02/controller_end_01/claw_snap");
        scoreboard_ref = GameObject.Find("Canvas/ScoreBoard/Text");
    }

    #region get/release events
    void GetObject()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Collider>().isTrigger = true;
        transform.SetParent(claw_ref.transform);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void ReleaseObject()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Collider>().isTrigger = false;
        this.transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == claw_ref.transform.name)
        {
            GetObject();

        }else if (other.name == "Plataforma 1" || other.name == "Plataforma 2")
        {
            AddPoints();
        }
        else
        {
            RemovePoints();
        }
    }

    public void AddPoints()
    {
        points += 500;
        scoreboard_ref.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
        Debug.Log(points);
    }

    public void RemovePoints()
    {
        points -= 250;
        scoreboard_ref.GetComponent<TMPro.TextMeshProUGUI>().text = points.ToString();
        Debug.Log(points);
    }
    #endregion
}
