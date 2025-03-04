using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Core
{
    public class MainObject : MonoBehaviour
    {
        [SerializeField] private GameConfigs _configs;

        private GameInitializator _initializator;
        private GameController _gameController;

        public void Awake()
        {
            _gameController = new GameController();
            _initializator = new GameInitializator();
            _initializator.InitGame(_configs, _gameController);
        }

        public void Start()
        {
        }

        public void Update()
        {
            var deltaTime = Time.deltaTime;
            _gameController.Update(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _gameController.LateUpdate(deltaTime);
        }

        public void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _gameController.FixedUpdate(fixedDeltaTime);
        }

        public void OnDestroy()
        {
            _gameController.Dispose();
        }
    }
}