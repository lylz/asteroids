using System.Collections.Generic;

public interface IGameController
{
    public List<IAsteroid> Asteroids { get; }
    public List<IUFO> UFOs { get; }
}

public class GameController : IGameController
{
    #region Singleton

    private static GameController _instance = new GameController();

    private GameController() { }
    
    public static GameController GetInstance()
    {
        return _instance;
    }

    #endregion

    private List<IAsteroid> _asteroids = new List<IAsteroid>();
    public List<IAsteroid> Asteroids { get => _asteroids; }

    private List<IUFO> _ufos = new List<IUFO>();
    public List<IUFO> UFOs { get => _ufos; }
}
