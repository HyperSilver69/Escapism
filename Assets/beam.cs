using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

namespace beamSpace
{
    public class beam : MonoBehaviour
    {
        public GameObject beamSpawn;
        public EasyHand hand;

        public void FixedUpdate()
        {
            RaycastHit hit;
            if (EasyInputs.GetTriggerButtonDown(hand))
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Shoot();
                    Debug.Log("SHOT!");
                }
            }
            else
                Debug.Log("Hasnt shot");
        }

        public GameObject beamObject;
        public GameObject instancedBeam;

        public void Shoot()
        {
            if (instancedBeam == null)
            {
                instancedBeam = Instantiate(beamObject, beamSpawn.transform);
                //instancedBeam.GetComponent<Rigidbody>().AddForce(-beamSpawn.transform.up * 1);
                instancedBeam.transform.parent = null;
            }
            else
            {
                return;
            }
        }
    }

}
