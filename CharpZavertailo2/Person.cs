using System;
using System.Text.RegularExpressions;

namespace CharpZavertailo2
{
    class Person
    {
        private DateTime _bDate;
        private string _name;
        private string _surname;
        private string _email;

        public bool IsAdult => Age() >= 18;
        internal string SunSign => GetSunSign(_bDate);
        internal string ChineseSign => GetChineseSign(_bDate);
        internal bool IsBirthday => HappyBDay(_bDate);
        internal int Years => Age();
        internal Person(string name, string surname, string email, DateTime bDay)

        {
            if (Regex.IsMatch(name, @"^[a-zA-Z'-]+$"))
                _name = name;
            else
                throw new InvalidNameException($"{name}");
            if (Regex.IsMatch(surname, @"^[a-zA-Z'-]+$"))
                _surname = surname;
            else
                throw new InvalidSurnameException($"{surname}");
            DateTime now = DateTime.Today;
            int age = now.Year - bDay.Year;
            if (now.Month < bDay.Month || (now.Month == bDay.Month && now.Day < bDay.Day))
                age--;
            int delta = (DateTime.Today - bDay).Days;
            if (age < 135 && delta >= 0)
            {
                _bDate = bDay;
            }
            else if (delta < 0)
            {
                throw new FutureDateException(bDay);
            }
            else
            {
                throw new PastDateException(bDay);

            }
            if (Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                _email = email;

            }
            else
            {
                throw new InvalidEmailException($"{email}");
            }
        }

        private Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        private Person(string name, string surname, DateTime bDay)
        {
            _name = name;
            _surname = surname;
            _bDate = bDay;
        }

        public DateTime BDate
        {
            get => _bDate;
            private set => _bDate = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }


        public string Surname
        {
            get => _surname;
            private set => _surname = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        private bool HappyBDay(DateTime dayOfBirthday)
        {
            return dayOfBirthday.DayOfYear == DateTime.Today.DayOfYear;
        }

        private int Age()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - _bDate.Year;
            if (now.Month < _bDate.Month || (now.Month == _bDate.Month && now.Day < _bDate.Day))
                age--;
            return age;
        }
        private string GetChineseSign(DateTime bDay)
        {
            switch (bDay.Year % 12)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Sheep";
                default:
                    return "Unknown";
            }
        }

        private string GetSunSign(DateTime bDay)
        {
            // According to https://en.wikipedia.org/wiki/Sun_sign_astrology
            switch (bDay.Month)
            {
                case 1:
                    return bDay.Day <= 20 ? "Aquarius" : "Pisces";
                case 2:
                    return bDay.Day <= 19 ? "Pisces" : "Aries";
                case 3:
                    return bDay.Day <= 21 ? "Aries" : "Taurus";
                case 4:
                    return bDay.Day <= 20 ? "Taurus" : "Gemini";
                case 5:
                    return bDay.Day <= 21 ? "Gemini" : "Cancer";
                case 6:
                    return bDay.Day <= 21 ? "Cancer" : "Leo";
                case 7:
                    return bDay.Day <= 24 ? "Leo" : "Virgo";
                case 8:
                    return bDay.Day <= 23 ? "Virgo" : "Libra";
                case 9:
                    return bDay.Day <= 23 ? "Libra" : "Scorpio";
                case 10:
                    return bDay.Day <= 23 ? "Scorpio" : "Sagittarius";
                case 11:
                    return bDay.Day <= 32 ? "Sagittarius" : "Capricorn";
                case 12:
                    return bDay.Day <= 22 ? "Capricorn" : "Aquarius";
                default:
                    return "Unknown";
            }
        }
        public class FutureDateException : Exception
        {
            public FutureDateException(DateTime date) 
                : base($"You have picked future date {date.ToShortDateString()}") { }
        }

        public class PastDateException : Exception
        {
            public PastDateException(DateTime date) 
                : base($"Oh sorry, but you are too old {date.ToShortDateString()}")
            {

            }
        }

        public class InvalidEmailException : Exception
        {
            public InvalidEmailException(string email) 
                : base($"You have entered wrong email: {email}") { }
        }

        public class InvalidNameException : Exception
        {
            public InvalidNameException(string name) 
                : base($"Incorrect name: {name}")
            {
            }
        }

        internal class InvalidSurnameException : Exception
        {
            internal InvalidSurnameException(string name) 
                : base($"Incorrect surname: {name}") { }
        }
    }
}

