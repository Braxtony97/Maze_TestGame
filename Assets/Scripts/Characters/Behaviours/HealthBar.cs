using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Characters.Behaviours
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Image _healthBarFill;
        [SerializeField] private Character _character;

        private void Awake()
        {
            _character.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _character.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float valuesAsPercantage)
        {
            _healthBarFill.fillAmount = valuesAsPercantage;
        }

        private void LateUpdate()
        {
            transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
            transform.Rotate(0, 180, 0);
        }
    }
}
