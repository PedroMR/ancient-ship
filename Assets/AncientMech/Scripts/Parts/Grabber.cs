 using UnityEngine;
 using System.Collections;
 
 public class Grabber : MonoBehaviour
 {
     public LayerMask m_MagneticLayers;
     public Vector3 m_Position;
     public float m_MagnetRadius;
     public float m_TrappedRadius;
     public float m_Force;
 
     void FixedUpdate ()
     {
         Collider[] colliders;
         Rigidbody rigidbody;
 
         var position = transform.TransformPoint(m_Position);
         colliders = Physics.OverlapSphere (position, m_MagnetRadius, m_MagneticLayers);
         foreach (Collider collider in colliders)
         {
             var theirTransform = (Transform) collider.transform;
             if ((theirTransform.position - position).sqrMagnitude < m_TrappedRadius*m_TrappedRadius) {
                //  theirTransform.parent = transform;
                 theirTransform.gameObject.layer = LayerMask.NameToLayer("Player");
                 var joint = theirTransform.gameObject.AddComponentIfRequired<FixedJoint>();
                joint.connectedBody = gameObject.GetComponent<Rigidbody>();
                 continue;
             }
             rigidbody = (Rigidbody) collider.gameObject.GetComponent (typeof (Rigidbody));
             if (rigidbody == null)
             {
                 continue;
             }

             rigidbody.AddExplosionForce (m_Force * -1, position, m_MagnetRadius);
         }
     }
 
     void OnDrawGizmosSelected ()
     {
         var position = transform.TransformPoint(m_Position);
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere (position, m_MagnetRadius);
         Gizmos.color = Color.blue;
         Gizmos.DrawWireSphere (position, m_TrappedRadius);
     }
 }