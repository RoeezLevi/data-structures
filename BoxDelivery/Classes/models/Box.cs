using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDelivery.Classes
{
    public class Box:IComparable<Box>
    {
        private double _x;
        private double _y;
        private DateTime _expiredate;
        private int _amount;
        public Box(double x, double y,int amount )
        {
            _x = x;
            _y = y;
            _amount = amount;
            _expiredate =DateTime.Now.AddMonths(2) ;
        }
        public Box(double x, double y)
        {
            _x = x;
            _y = y;
            _amount = 1;
            _expiredate = DateTime.Now.AddMonths(2);
        }
        public Box(double x, double y, int amount ,DateTime expiredate)
        {
            _x = x;
            _y = y;
            _amount = amount;
            _expiredate = expiredate;
        }
        public double X { get { return _x; } }
        public double Y { get { return _y; } }
        public int Amount 
        { 
        set { _amount = value; }
            
            get
            {
              return _amount; 
            }
        
        }
        public DateTime ExpireDate 
        {
            set { _expiredate = value; }
            get 
            { return _expiredate; } 
        }
        public double Volume
        {
            get
            {
                return X * X * Y;
            }
        }
        public bool IsEmpty()
        {
            if( _amount == 0 ) 
                return true;
            return false;
        }
        public int CompareTo(Box box2)
        {
            if (this == null && box2 == null)
                return 0;
                if (box2 == null) return 1;
            if(this==null) return -1;
            
            int xComparison = this.X.CompareTo(box2.X);
            if (xComparison != 0)
                return xComparison;

            return this.Y.CompareTo(box2.Y);
        }

        public bool IsExpiered()
        {
            if(DateTime.Now>=ExpireDate) 
                return true;
            return false;
        }
        public bool IsOld()
        {
            if (DateTime.Now.AddMonths(1) >= ExpireDate)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{this.X},{this.Y},{this.ExpireDate}";
        }
    }
}
