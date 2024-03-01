using System;

namespace AS.Framework
{
    namespace GefestCapital.PromoterMama.Main
    {
        public class GuiUpdater : BaseUpdater
        {
            private DateTime _lastUpdateDateTime;
            private double _deltaTime;

            private void OnGUI()
            {
                UpdateDeltaTime();

                foreach (var updatable in updatables)
                {
                    updatable.Update(_deltaTime);
                }
            }

            private void UpdateDeltaTime()
            {
                if (_lastUpdateDateTime == DateTime.MinValue)
                {
                    _deltaTime = 0;
                }
                else
                {
                    _deltaTime = (DateTime.Now - _lastUpdateDateTime).TotalSeconds;
                }
            }
        }
    }
}