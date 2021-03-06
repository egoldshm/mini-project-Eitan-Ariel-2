﻿using System;
using System.Xml.Serialization;

namespace BE
{
    public class Tester
    {
        #region Private variables

        private int _id;
        private string _lastName;
        private string _firstName;
        private DateTime _dateOfBirth;
        private Gender _gender;
        private long _phoneNumber;
        private Address _address;
        private int _yearsOfExperience;
        private int _maxWeeklyTests;
        private CarType _carType;
        private bool[,] _workDays = new bool[5, 6];
        private float _maxDistance;

        #endregion Private variables

        #region CTORs
        public Tester() {
            _workDays = new bool[5, 6];
            DateOfBirth = DateTime.Today.AddYears(-Configuration.MIN_TESTER_AGE);
        }
        public Tester(int id)
        {
            _workDays = new bool[5, 6];
            this.Id = id;
        }

        public Tester(int id, string lastName, string firstName) : this(id)
        {
            _workDays = new bool[5, 6];
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        }

        public Tester(int id, string lastName, string firstName, DateTime dateOfBirth, Gender gender, long phoneNumber, Address address, int yearsOfExperience, int maxWeeklyTests, CarType carType, bool[,] workDays, float maxDistance) : this(id)
        {
            _workDays = new bool[5, 6];
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.YearsOfExperience = yearsOfExperience;
            this.MaxWeeklyTests = maxWeeklyTests;
            this.CarType = carType;
            this.WorkDays = workDays ?? throw new ArgumentNullException(nameof(workDays));
            this.MaxDistance = maxDistance;
        }

        //copy CTOR for get_all
        public Tester(Tester tester)
        {
            this.Id = tester.Id;
            this.LastName = tester.LastName ?? throw new ArgumentNullException(nameof(LastName));
            this.FirstName = tester.FirstName ?? throw new ArgumentNullException(nameof(FirstName));
            this.DateOfBirth = tester.DateOfBirth;
            this.Gender = tester.Gender;
            this.PhoneNumber = tester.PhoneNumber;
            this.Address = tester.Address;
            this.YearsOfExperience = tester.YearsOfExperience;
            this.MaxWeeklyTests = tester.MaxWeeklyTests;
            this.CarType = tester.CarType;
            this.WorkDays = tester.WorkDays ?? throw new ArgumentNullException(nameof(WorkDays));
            this.MaxDistance = tester.MaxDistance;
        }

        #endregion CTORs

        #region Properties

        public int Id { get => _id; set => _id = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public long PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public Address Address { get => _address; set => _address = value; }
        public int YearsOfExperience { get => _yearsOfExperience; set => _yearsOfExperience = value; }
        public int MaxWeeklyTests { get => _maxWeeklyTests; set => _maxWeeklyTests = value; }
        public CarType CarType { get => _carType; set => _carType = value; }
        [XmlIgnore]
        public bool[,] WorkDays { get => _workDays; set => _workDays = value; }
        public string workDaysTostring
        {
            get
            {
                string str = "";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        str += WorkDays[i, j] ? "1" : "0";
                    }
                }
                return str;
            }
            set
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        WorkDays[i, j] = value[j + i * 6] == '1';
                    }
                }
            }
        }
        public float MaxDistance { get => _maxDistance; set => _maxDistance = value; }

        #endregion Properties

        public override string ToString()
        {
            return Id + " (" + FirstName + " " + LastName + ")";
        }
    }
}