using UnityEngine;

namespace Scripts
{
    public class MainPresenter : MonoBehaviour
    {
        [SerializeField] private MainView _view;
        [SerializeField] private ArtilleryBehaviour _artillery;

        private void Start() => _view.OnShoot += _artillery.Shoot;

        private void OnDisable() => _view.OnShoot -= _artillery.Shoot;
    }
}