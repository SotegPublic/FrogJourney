using Platformer.Core;
using System;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerSlideDetector
    {
        private ISlideDetectingModel _slideDetectingModel;
        private LayerMask _groundLayer;

        private ContactPoint2D[] _contacts = new ContactPoint2D[2];

        public PlayerSlideDetector(ISlideDetectingModel slideDetectingModel)
        {
            _slideDetectingModel = slideDetectingModel;
            _groundLayer = LayerMask.NameToLayer(LayersNames.GROUND);
        }

        public void OnPlayerCollisionEnter(Collision2D collision)
        {
            if(collision.gameObject.layer == _groundLayer && !_slideDetectingModel.IsSlideOnWall)
            {
                collision.GetContacts(_contacts);

                if (Math.Abs(_contacts[0].normal.x) == 1)
                {
                    _slideDetectingModel.SetIsSlideOnWall(true);
                }
            }
        }

        public void OnPlayerCollisionExit(Collision2D collision)
        {
            if (collision.gameObject.layer == _groundLayer && _slideDetectingModel.IsSlideOnWall)
            {
                _slideDetectingModel.SetIsSlideOnWall(false);
            }
        }
    }
}
