using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedController : MonoBehaviour
{

    public Color juiceColor;
    public GameObject juiceVFX;
    public float juiceSize = 1;
    private bool sliced = false;

    private void OnTriggerEnter(Collider other) {
        if(other.tag != "Player") return;
    }

    public void SliceObject(){
        if(sliced) return;
        var rbs = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.velocity = (rb.transform.up + rb.transform.right) * 3.5f;
            rb.isKinematic = false;
        }
        var vfx = Instantiate(juiceVFX,transform.position,Quaternion.identity);
        vfx.transform.localScale *= juiceSize;
        var particle = vfx.GetComponent<ParticleSystem>().main.startColor;
        particle.color = juiceColor;
        Destroy(vfx,1f);
        GetComponent<Collider>().enabled = false;
        GameManager.IncreaseCoins(10);
    }

}
