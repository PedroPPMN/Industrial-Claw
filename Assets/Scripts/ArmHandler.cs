using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmHandler : MonoBehaviour
{
    #region cube
    private GameObject cube;
    #endregion

    #region particle effects variables
    private ParticleSystem particles;
    private GameObject particle_effects;
    #endregion

    #region animations variables
    private GameObject animator_ref;
    private Animator anim;
    #endregion

    #region IndustrialArm refs
    string root = "IndustrialArm/industrial_robot_arm_claw";

    GameObject base_ref;
    GameObject arm_ref;
    GameObject head_ref;
    GameObject controller_end1_ref;
    GameObject controller_end2_ref;
    GameObject controller_left_arm_ref;
    GameObject controller_right_arm_ref;
    GameObject controller_left_pincer_ref;
    GameObject controller_right_pincer_ref;

    #endregion

    private float timer = 30.0f;

    void Start()
    {

        base_ref = GameObject.Find(root + "/controller_base");
        arm_ref = GameObject.Find(root + "/controller_base/controller_arm");
        head_ref = GameObject.Find(root + "/controller_base/controller_arm/bone_arm/controller_head");
        controller_end2_ref = GameObject.Find(root + "/controller_base/controller_arm/bone_arm/controller_head/bone_head/controller_end_02");
        controller_end1_ref = GameObject.Find(root + "/controller_base/controller_arm/bone_arm/controller_head/bone_head/controller_end_02/controller_end_01");
        controller_left_arm_ref = GameObject.Find(root + "/controller_base/controller_arm/bone_arm/controller_head/bone_head/controller_end_02/controller_end_01/claw_snap/Base/controller_left_arm");
        controller_right_arm_ref = GameObject.Find(root + "/controller_base/controller_arm/bone_arm/controller_head/bone_head/controller_end_02/controller_end_01/claw_snap/Base/controller_right_arm");
        controller_left_pincer_ref = GameObject.Find(root + "/controller_base/controller_arm/bone_arm/controller_head/bone_head/controller_end_02/controller_end_01/claw_snap/Base/controller_left_arm/controller_left_pincer");
        controller_right_pincer_ref = GameObject.Find(root + "/controller_base/controller_arm/bone_arm/controller_head/bone_head/controller_end_02/controller_end_01/claw_snap/Base/controller_right_arm/controller_right_pincer");

        particle_effects = GameObject.Find("Particles/Firework");
        cube = GameObject.Find("Cube");
        animator_ref = GameObject.Find(root);

        anim = animator_ref.GetComponent<Animator>();
        particles = particle_effects.GetComponent<ParticleSystem>();

        particles.Stop();
        anim.GetComponent<Animator>().enabled = false;
    }

    private void FixedUpdate()
    {
        TickTimer();
    }

    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            PlayAnimation();
        }

        if (Input.GetKeyDown("2"))
        {
            BackToStart();
        }
    }

    #region utility/others
    void TickTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            particles.Stop();
            timer = 30.0f;
        }
    }

    void PlayFireworks()
    {
        particles.Play();
    }
    
    public void ReleaseObject()
    {
        cube.GetComponent<AttachManager>().ReleaseObject();
    }
    #endregion

    #region play/stop animations
    public void PlayAnimation()
    {
        anim.GetComponent<Animator>().enabled = true;
        anim.Play("MoveCube");
    }

    public void BackToStart()
    {
        anim.Play("BackToStart");
    }
    #endregion

    #region moviment manager

    public void MoveBase(float value)
    {
        base_ref.transform.localRotation = Quaternion.Euler(-90, 0,- value * 360);
    }
    public void MoveArm(float value)
    {
        arm_ref.transform.localRotation = Quaternion.Euler(85, -90,- value * 360);
    }
    public void MoveHead(float value)
    {
        head_ref.transform.localRotation = Quaternion.Euler(-5, 0,- value * 360);
    }
    public void MoveControllerEnd1(float value)
    {
        Debug.Log(controller_end1_ref.name);
        controller_end1_ref.transform.localRotation = Quaternion.Euler(0,- value * 360, 0);
    }
    public void MoveControllerEnd2(float value)
    {
        Debug.Log(controller_end2_ref.name);
        controller_end2_ref.transform.localRotation = Quaternion.Euler(value * 360, 0, 175);
    }
    public void MoveArmsPincer(float value)
    {
        controller_left_arm_ref.transform.localRotation = Quaternion.Euler(0, 0, 20-(value * 120));

        controller_right_arm_ref.transform.localRotation = Quaternion.Euler(0, 0, (value*120) - 170);
    }
    public void MovePincers(float value)
    {
        controller_left_pincer_ref.transform.localRotation = Quaternion.Euler(0, 0, 150 + (value * 120));
        controller_right_pincer_ref.transform.localRotation = Quaternion.Euler(0, 0, -(value * 120));
    }
    #endregion
}
