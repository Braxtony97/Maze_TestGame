using Assets.Scripts.Characters.Behaviours;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class Player : Character, IShootable
    {
        public static Player Instance;

        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private LayerMask _floorLayerMask;

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
                    if (_timerShoot <= 0)
                    {
                        Debug.Log("Enemy");
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
            _pooler.SpawnFromPool(_projectileTag, _shootPoint);
        }

        protected override void Move()
        {
            _movement.Move();
        }
    }
}
