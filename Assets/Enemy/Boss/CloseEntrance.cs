using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEntrance : MonoBehaviour
{
    public ChekIfInBossRoom ck;
    public GameObject Gate;
    public float MaxY;

    public AnimationCurve Ac;
    private float timer;
    public float maxTime;

    private Rigidbody rb;
    private AudioSource Audio;
    private Vector3 InitialPos;
    private Vector3 DesiredPos;
    void Start()
    {
        InitialPos = transform.position;
        DesiredPos = new Vector3(transform.position.x, MaxY, transform.position.z);
        rb = gameObject.GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
    }



    private void FixedUpdate()
    {
        if (ck.IsInBossRoom && transform.position.y <= MaxY)
        {
            if (timer < maxTime)
            {
                timer += Time.fixedDeltaTime;
                rb.position = Vector3.Lerp(InitialPos, DesiredPos, Ac.Evaluate(timer / maxTime));
                Audio.mute = false;
            }
            else
            {
                Audio.mute = true;
                this.enabled = false;
            }


        }
        else
        {
            Audio.mute = true;
        }
    }


}
