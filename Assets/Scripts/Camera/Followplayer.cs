using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1_24_25
{
    public class CameraController : MonoBehaviour
    {
        public Transform Target => _player ? _player?.transform : _target;

        [Header("FOLLOW")]
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _sizeBoxCast;
        [SerializeField] private Vector2 _offsetBoxCast;
        [Range(0, 1)][SerializeField] private float _smoothTime = .1f;

        private Vector2 _velocity;
        private PlayerContollers _player;

        private void Awake()
        {
            _target = Object.FindFirstObjectByType<PlayerContollers>().transform;
            _target.TryGetComponent(out _player);
        }

        void Start()
        {

        }

        void Update()
        {
            var limiteMin = transform.TransformPoint(-_sizeBoxCast) + (Vector3)_offsetBoxCast;
            var limiteMax = transform.TransformPoint(_sizeBoxCast) + (Vector3)_offsetBoxCast;

            var isOutH = Target.position.x < limiteMin.x || Target.position.x > limiteMax.x;
            var isOutV = Target.position.y < limiteMin.y || Target.position.y > limiteMax.y;

            float targetOutX = isOutH ? Target.position.x - _offsetBoxCast.x : transform.position.x;
            float targetOutY = isOutV ? Target.position.y - _offsetBoxCast.y : transform.position.y;
            Vector2 targetOut = new(targetOutX, targetOutY);

            Vector3 targetPos;
            if (_smoothTime <= 0)
            {
                var speedDelta = _player ? _player.speedMove : 5;
                targetPos = Vector2.MoveTowards(transform.position, targetOut, Time.deltaTime * speedDelta);
            }
            else
                targetPos = Vector2.SmoothDamp(transform.position, targetOut, ref _velocity, _smoothTime);

            targetPos.z = transform.position.z;
            transform.position = targetPos;
        }

        public void ChangeTarget(Transform newTarget) => _target = newTarget;


        private void OnDrawGizmosSelected()
        {
            var offsetPos = transform.position + (Vector3)_offsetBoxCast;
            var sizeCross = .25f;

            Gizmos.color = _sizeBoxCast.x < 0 || _sizeBoxCast.y < 0 ? new Color(1, 0, 0, .25f) : new Color(0, 1, 0, .25f);
            Gizmos.DrawCube(offsetPos, _sizeBoxCast * 2);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(offsetPos, _sizeBoxCast * 2);
            Gizmos.DrawLine(offsetPos + Vector3.left * sizeCross, offsetPos + Vector3.right * sizeCross);
            Gizmos.DrawLine(offsetPos + Vector3.down * sizeCross, offsetPos + Vector3.up * sizeCross);
        }
    }
}