using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSplash : MonoBehaviour
{
    public Transform objTrans;
    private float delay = 0;
    private float pasttime = 0;
    private float when = 1f;
    private Vector3 off;

    public Animator Animator;
    // Start is called before the first frame update

    private void Awake()
    {
        off = new Vector3(Random.Range(-3,3), off.y, off.z);
        off = new Vector3(off.x,Random.Range(-3, 3), off.z);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (when >= delay)
        {
            Animator.SetBool("Splash", true);
            pasttime = Time.deltaTime;
            objTrans.position += off * Time.deltaTime;
            delay += pasttime;

            Debug.Log("Moneta sie rozsypuje");
        }
        else
        {
            Animator.SetBool("Splash", false);
        }
    }
}
