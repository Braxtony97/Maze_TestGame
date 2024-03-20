using Assets.Scripts.Characters.Behaviours;
using Assets.Scripts.GameMagaer;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class Player : Character, IShootable
    {
        public static Player Instance;

        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private LayerMask _floorLayerMask;
        [SerializeField] private Animator _animator;

        private ObjectPooler _pooler;
        private float _timerShoot;

        private void Awake()
        {
            Instance = this;
        }

        protected override void Start()
        {
            base.Start();
            _pooler = ObjectPooler.Instance;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                ClickOnMouse();
            }
        }

        private void ClickOnMouse()
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 1000f, _floorLayerMask ))
            {
                if (raycastHit.collider.gameObject.tag == "Enemy")
                {
                    _movement.StopAgent();
                    SetAngle(raycastHit.collider.gameObject.transform.position);
                    if (_timerShoot <= 0)
                    {
                        Shoot();
                        _timerShoot = _reloadTimeShoot;
                    }
                    else
                        _timerShoot -= Time.deltaTime;
                    
                }
                if (raycastHit.collider.gameObject.tag == "Floor")
                {
                    Move();
                }
            }
        }

        public void Shoot()
        {
            _audioManager.SFXPlay(_audioManager._audioSFXClipList[0]);
            _animator.SetTrigger("Shoot");
            _pooler.SpawnFromPool(_projectileTag, _shootPoint);
        }

        protected override void Move()
        {
            _movement.Move();
        }
    }
}
