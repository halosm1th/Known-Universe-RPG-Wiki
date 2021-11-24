using System;

namespace VoicesFromTheVoidArticles
{
    public class TravellerDateTime : IComparable<TravellerDateTime>
    {
        public int Day
        {
            get => _day;
            set
            {
                if (value < 1)
                {
                    _day = 1;
                }else if (value > 31)
                {
                    _day = 31;
                }
                else
                {
                    _day = value;
                }
            }
        }

        public int Month
        {
            get => _month;
            set
            {
                if (value < 1)
                {
                    _month = 1;
                }
                else if (value > 12)
                {
                    _month = 12;
                }
                else
                {
                    _month = value;
                }
            }
        }

        public int Century
        {
            get => _cen;
            set
            {
                if (value < 0)
                {
                    _cen = 0;
                }
                else if (value > 999)
                {
                    _cen = 999;
                }
                else
                {
                    _cen = value;
                }
            }
        }

        public int Millennium
        {
            get => _mil;
            set
            {
                if (value < 1)
                {
                    _mil = 1;
                }
                else if (value > 99)
                {
                    _mil = 99;
                }
                else
                {
                    _mil = value;
                }
            }
        }

        public int Year => (_mil * 1000) + _cen;

        private int _day = 1;
        private int _month = 1;
        private int _cen = 390;
        private int _mil = 83;

        public TravellerDateTime(int day = 1, int month = 1, int mil = 83, int cen = 390)
        {
            Day = day;
            Month = month;
            Millennium = mil;
            Century = cen;
        }

        public string ToIsoTime()
        {
            return $"{Millennium.ToString()}{Century.ToString()}-{Month.ToString()}-{Day.ToString()}";
        }

        public string ToEarthStandardTime()
        {
            return $"{_mil}{_cen}-{_month}-{_day}";
        }

        public override string ToString()
        {
            return $"{_day}/{_month}/{_mil}{_cen}";
        }

        public int CompareTo(TravellerDateTime date)
        {
            if (date == null)
            {
                return 1;
            }
            
            //If the millennium isn't the same as us.
            if (date.Millennium != Millennium)
            {
                //If the other is earlier then we are we put them behind us, if its bigger it comes after
                return Millennium.CompareTo(date.Millennium);
            }


            //If we don't have the same century
            if (date.Century != Century)
            {
                return Century.CompareTo(date.Century);

            }

            //We check if they're different months
            if (date.Month != Month)
            {
                return Month.CompareTo(date.Month);
            }

            //If everything else is equal, then we compare days.
            return Day.CompareTo(date.Day);
        }
    }
}