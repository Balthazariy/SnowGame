using SnowGame.Data;

namespace SnowGame
{
    public interface ISoundManager
    {
        bool IsMute { get; set; }

        void PlaySound(Enumerators.SoundType soundType, bool random = false, SoundParameters parameters = null);

        void StopSound(Enumerators.SoundType soundType);

        void UpdateSoundStatus();
    }
}