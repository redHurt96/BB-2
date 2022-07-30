using UnityEngine;

namespace RH.Utilities.Gizmos
{
    public class GizmosSphere : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.red;
        [SerializeField] private float _radius = 1f;

        private void Start()
        {
            if (!Application.isEditor)
                Destroy(this);
        }

        private void OnDrawGizmos()
        {
            UnityEngine.Gizmos.color = _color;
            UnityEngine.Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}