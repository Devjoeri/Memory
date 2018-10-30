using System.Windows.Controls;

namespace Memory
{
    /// <summary>
    /// Deze class wordt gebruikt om te navigeren tussen schermen in de main screen
    /// die te zien is tijdens het opstarten van de game.
    /// </summary>
    public interface INavigator
    {
        void Navigate(Page p);
    }
}