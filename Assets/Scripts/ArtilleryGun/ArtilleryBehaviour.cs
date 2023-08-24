using Unity.Mathematics;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(AudioSource), typeof(Animator))]
    public class ArtilleryBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioClip _shootClip;
        [SerializeField] private AudioClip _gearsClip;
        [SerializeField] private Transform _bulletPos;
        [SerializeField] private GameObject _bullet;
        
        private AudioSource _audio;
        private Animator _animator;

        private static readonly int ShootingVariableHash = Animator.StringToHash("IsShooting");
        
        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate() => _animator.SetBool(ShootingVariableHash, false);

        public void Shoot()
        {
            _animator.SetBool(ShootingVariableHash, true);
        }
        
        public void SpawnBullet() => Instantiate(_bullet, _bulletPos.position, _bulletPos.rotation);

        public void PlayShootSound() => PlaySound(_shootClip);

        public void PlayGearsSound() => PlaySound(_gearsClip);

        private void PlaySound(AudioClip clip)
        {
            _audio.Stop();
            _audio.clip = clip;
            _audio.Play();
        }
    }
}