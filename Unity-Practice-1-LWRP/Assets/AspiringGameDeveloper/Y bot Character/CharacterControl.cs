using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AspringGameProgrammer
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
        Grounded,
        Attack,
    }
    public class CharacterControl : MonoBehaviour
    {
        public Animator skinnedMesh;
        public Material skinnedMaterial;

        public float movementSpeed;
        public float gravityMultiplier;
        public float pullGravity;

        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attack;

        public List<GameObject> bottomSpheres = new List<GameObject>();
        public List<GameObject> frontSpheres = new List<GameObject>();

        public List<Collider> ragdollParts = new List<Collider>();

        private List<TriggerDetectors> triggerDetectors = new List<TriggerDetectors>();

        private void Awake()
        {
            bool switchBack = false;
            if (!isFacing()) switchBack = true;

            faceForward(true);

            //setRagdollParts();
            createSpheres();

            if (switchBack) faceForward(false);
        }

        public void setRagdollParts()
        {
            ragdollParts.Clear();
            Collider[] colliders = GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                if (col.gameObject != gameObject)
                {
                    col.isTrigger = true;
                    ragdollParts.Add(col);
                    if (null == col.GetComponent<TriggerDetectors>()) col.gameObject.AddComponent<TriggerDetectors>();
                }
            }
        }

        public List<TriggerDetectors> getAllTriggerDetector()
        {
            if(triggerDetectors.Count == 0)
            {
                TriggerDetectors[] allTriggers = GetComponentsInChildren<TriggerDetectors>();

                foreach(TriggerDetectors t in allTriggers)
                {
                    triggerDetectors.Add(t);
                }
            }
            return triggerDetectors;
        }

        public void turnOnRagdoll()
        {
            getRigidbody.useGravity = false;
            getRigidbody.velocity = Vector3.zero;
            GetComponent<BoxCollider>().enabled = false;
            skinnedMesh.enabled = false;
            skinnedMesh.avatar = null;
            foreach (Collider col in ragdollParts)
            {
                col.isTrigger = false;
                col.attachedRigidbody.velocity = Vector3.zero;
            }
        }

        private void FixedUpdate()
        {
            if (getRigidbody.velocity.y < 0f) getRigidbody.velocity -= Vector3.up * gravityMultiplier;
            if (getRigidbody.velocity.y > 0f && !jump) getRigidbody.velocity -= Vector3.up * pullGravity;
        }

        public void createSpheres()
        {
            BoxCollider box = GetComponent<BoxCollider>();

            float top = box.bounds.center.y + box.bounds.extents.y;
            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;

            GameObject bottomFront = createSphereEdge(new Vector3(0f, bottom, front));
            GameObject bottomBack = createSphereEdge(new Vector3(0f, bottom, back));
            bottomSpheres.Add(bottomFront);
            bottomSpheres.Add(bottomBack);

            GameObject topFront = createSphereEdge(new Vector3(0f, top, front));
            frontSpheres.Add(topFront);
            frontSpheres.Add(bottomFront);

            float bottomSphereSection = (bottomBack.transform.position - bottomFront.transform.position).magnitude / 5f;
            replicateSphere(bottomBack, Vector3.forward, bottomSphereSection, 4, bottomSpheres);

            float frontSphereSection = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
            replicateSphere(bottomFront, Vector3.up, frontSphereSection, 9, frontSpheres);
        }

        public void replicateSphere(GameObject startPosition, Vector3 direction, float section, float iterations, List<GameObject> spheres)
        {
            for (int i = 0; i < iterations; i++)
            {
                Vector3 position = startPosition.transform.position + (direction * section * (i + 1));
                GameObject newSphere = createSphereEdge(position);
                spheres.Add(newSphere);
            }
        }

        public Rigidbody getRigidbody
        {
            get
            {
                return GetComponent<Rigidbody>();
            }
        }

        public void changeMaterial()
        {
            if (null == skinnedMaterial) Debug.LogError("No material Specified!");
            Renderer[] allRenderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer render in allRenderers)
            {
                if (render.gameObject != gameObject) render.material = skinnedMaterial;
            }
        }

        public GameObject createSphereEdge(Vector3 position)
        {
            return Instantiate(Resources.Load("SphereEdge"), position, Quaternion.identity, transform) as GameObject;
        }

        public void characterMove(float speedGraph, float speedForward)
        {
            transform.Translate(Vector3.forward * speedGraph * speedForward * Time.deltaTime);
        }

        public void faceForward(bool isForward)
        {
            if (isForward) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            else transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        bool isFacing()
        {
            if (transform.forward.z > 0f) return true;
            else return false;
        }
    }
}
