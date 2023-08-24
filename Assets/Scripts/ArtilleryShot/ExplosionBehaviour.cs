using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class ExplosionBehaviour : MonoBehaviour
    {
        [SerializeField] private float _duration;
        private WaitForSeconds _waitFor;

        private void Awake()
        {
            _waitFor = new WaitForSeconds(_duration);
            StartCoroutine(DestroyCoroutine());
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return _waitFor;
            Destroy(gameObject);
        }
    }
}