using System;
using Configs;
using UnityEngine;
using Utils.FactoryTool;

namespace Views
{
    public class ResourceView : PoolableMonoBehaviour
    {
        [SerializeField] private ResourceConfig _config;

        private bool _isMove;
        private float _moveDuration;
        private float _elapsedTime;
        private Vector3 _startPos;
        private float _height;
        
        public int type => _config.resource.type;
        
        private Action onMoveEnd;
        
        public override void Init()
        {
            _moveDuration = _config._moveTime;
        }
        
        public void MoveToParent(float posY, Action action = null)
        {
            _startPos = transform.position;
            _height = posY;
            _elapsedTime = 0.0f;
            _isMove = true;
            onMoveEnd = action;
        }
        
        private void Update()
        {
            if (_isMove)
            {
                _elapsedTime += Time.deltaTime;
                var percentageComplete = _elapsedTime / _moveDuration;
                transform.position = Vector3.Lerp(
                    _startPos, 
                    new Vector3(transform.parent.position.x, _height, transform.parent.position.z),
                    percentageComplete);
            
                if (Mathf.Clamp01(percentageComplete) >= 1.0f)
                {
                    transform.position = new Vector3(transform.parent.position.x, _height, transform.parent.position.z);
                    transform.forward = transform.parent.forward;
                    _isMove = false;
                    onMoveEnd?.Invoke();
                }
            }
        }
    }
}