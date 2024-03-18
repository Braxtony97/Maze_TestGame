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
        [SerializeField] protected string _projectileTag;
        [SerializeField] protected Transform _shootPoint;
        [SerializeField] private PlayerMovement _movement;

        private ObjectPooler _pooler;

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
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject.tag == "Enemy")
                {
                    Shoot();
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
