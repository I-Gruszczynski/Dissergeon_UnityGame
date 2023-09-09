using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAnim : MonoBehaviour
{
    public Animator shotgunAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecoilComplete()
    {
        shotgunAnimator.SetBool("ShotgunRecoil", false);
    }
}
