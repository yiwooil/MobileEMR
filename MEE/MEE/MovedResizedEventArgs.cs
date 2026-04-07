using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEE
{
    class MovedResizedEventArgs : EventArgs
    {
        public const int MOVE = 1;
        public const int RESIZE = 2;

        public const int LEFT = 1;
        public const int RIGHT = 2;
        public const int UP = 3;
        public const int DOWN = 4;

        private int mMoveOrResize;
        private int mDirection;
        private int mValue;

        public MovedResizedEventArgs(int moveOrResize, int direction, int value)
        {
            mMoveOrResize = moveOrResize;
            mDirection = direction;
            mValue = value;
        }

        public int GetMoveOrResize()
        {
            return mMoveOrResize;
        }

        public int GetDirection()
        {
            return mDirection;
        }

        public int GetValue()
        {
            return mValue;
        }

    }
}
