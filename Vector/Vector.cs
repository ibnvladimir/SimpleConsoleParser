namespace VectorOperations
{
    public class Vector
    {
        private readonly double _xCoordinate;
        private readonly double _yCoordinate;
        private readonly double _zCoordinate;

        public Vector(double x, double y, double z)
        {
            _xCoordinate = x;
            _yCoordinate = y;
            _zCoordinate = z;
        }

        public override string ToString()
        {
            return $"x:{_xCoordinate}, y:{_yCoordinate}, z:{_zCoordinate}";
        } 

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1._xCoordinate + v2._xCoordinate, v1._yCoordinate + v2._yCoordinate, v1._zCoordinate + v2._zCoordinate) ;
        }
         public static Vector operator *(Vector v, double d)
        {
            return new Vector(v._xCoordinate * d, v._yCoordinate *d, v._zCoordinate *d);
        }
    }
}
