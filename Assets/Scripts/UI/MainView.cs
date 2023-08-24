using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private Button _shootBtn;

        public event Action OnShoot;

        private void Awake()
        {
            _shootBtn.onClick.AddListener(ButtonClick);
        }

        private void ButtonClick() => OnShoot?.Invoke();
    }
}