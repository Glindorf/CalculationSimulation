using System;

namespace CalculationSimulation
{


    /// <summary>
    /// This class simulates a calculation of a value depending on
    /// an x and y value. The calculation takes about 500 milliseconds.
    /// However, the simulator may optionally use a cache to speed
    /// up the caluclation.
    /// </summary>
    public class Simulator
    {
        #region Instance fields
        private Random _generator;
        private bool _useCache;
        private Cache _cache;
        public static int NoValue = -1;
        #endregion

        #region Constructor
        /// <summary>
        /// Only create the cache if specified
        /// </summary>
        public Simulator()
        {
            _generator = new Random();
            _useCache = false;

            _cache = (_useCache ? new Cache() : null);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simulate a calculation, possibly using a cached value.
        /// </summary>
        public int Calculate(int x, int y)
        {
            int result = NoValue;

            if (x < TableSettings.TableX && x >= 0 && y < TableSettings.TableY && y >= 0)
            {
                if (_useCache)
                {
                    result = _cache.Lookup(x, y);
                }

                if (result == NoValue)
                {
                    result = DoCalculation(x, y);

                    if (_useCache)
                    {
                        _cache.Insert(x, y, result);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Simulate an actual calculation
        /// </summary>
        private int DoCalculation(int x, int y)
        {
            Pause(500);
            return _generator.Next(1, 1000);
        }

        /// <summary>
        /// Pause for the specified number of milliseconds
        /// </summary>
        private void Pause(int mSecs)
        {
            System.Threading.Thread.Sleep(mSecs);
        } 
        #endregion
    }
}
