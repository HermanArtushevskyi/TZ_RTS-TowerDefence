using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts
{
    public class ExplosionBehaviour : MonoBehaviour
    {
        [FormerlySerializedAs("_duration")] public float duration;
        private WaitForSeconds _waitFor;

        private void Awake()
        {
            _waitFor = new WaitForSeconds(duration);
            StartCoroutine(DestroyCoroutine());
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return _waitFor;
            Destroy(gameObject);
        }
    }
}