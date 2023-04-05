using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Material glass;
    private bool hasBounced = false;
    public beamSpace.beam beamScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshRenderer>().material == glass)
        {
            if (!hasBounced)
            {
                Vector3 direction = collision.contacts[0].normal;
                GetComponent<Rigidbody>().AddForce(-direction * 6);
                hasBounced = true;
            }
            else
            {
                Destroy(gameObject);
                beamScript.instancedBeam = null;
            }
        }
        else
        {
            Destroy(gameObject);
            beamScript.instancedBeam = null;
        }
    }
}
