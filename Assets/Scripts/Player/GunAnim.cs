using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnim : MonoBehaviour
{

    public Animator gunAnimator;
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
        gunAnimator.SetBool("GunRecoil", false);
    }
}
