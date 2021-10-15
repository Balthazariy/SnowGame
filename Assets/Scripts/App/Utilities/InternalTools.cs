using DG.Tweening;

namespace SnowGame.Helpers
{
    public class InternalTools
    {
        public static Sequence DoActionDelayed(TweenCallback action, float delay = 0f)
        {
            if (action == null)
                return null;

            Sequence sequence = DOTween.Sequence();
            sequence.PrependInterval(delay);
            sequence.AppendCallback(action);

            return sequence;
        }
    }
}