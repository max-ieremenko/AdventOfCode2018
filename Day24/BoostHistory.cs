namespace Day24
{
    internal sealed class BoostHistory
    {
        private int _leftBorder;
        private int _rightBorder;

        public int? MinBoost => _rightBorder == _leftBorder && _leftBorder > 0 ? _rightBorder : (int?)null;

        public int GetNext()
        {
            if (_rightBorder == 0)
            {
                return _leftBorder + 1000;
            }

            var diff = _rightBorder - _leftBorder;
            if (diff > 1)
            {
                diff /= 2;
            }

            return _rightBorder - diff;
        }

        public void Validate(int value, bool lastBoostTest)
        {
            if (lastBoostTest)
            {
                _rightBorder = value;
            }
            else
            {
                _leftBorder = value;

                if (_rightBorder > 0 && (_rightBorder - _leftBorder == 1))
                {
                    _leftBorder = _rightBorder;
                }
            }
        }
    }
}
