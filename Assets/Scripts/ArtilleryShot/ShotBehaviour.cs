using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShotBehaviour : UnityEngine.MonoBehaviour
    {
        [SerializeField] private GameObject _explosionVFX;
        [SerializeField] private float _speed;
        
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() => _rb.AddRelativeForce(Vector3.forward * _speed * Time.fixedDeltaTime, ForceMode.Impulse);

        private void OnCollisionEnter(Collision other)
        {
            GameObject explosion = Instantiate(_explosionVFX, transform.position, Quaternion.identity);
            ExplosionBehaviour explosionBehaviour = explosion.AddComponent<ExplosionBehaviour>();
            explosionBehaviour.duration = 5;
            Destroy(gameObject);
        }
    }
}