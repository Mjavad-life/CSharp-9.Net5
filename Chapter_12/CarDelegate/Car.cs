﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    public class Car
    {

        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        // Is the car alive or dead?
        private bool _carIsDead;


        // Class constructors.
        public Car() { }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }


        // 1) Define a delegate type.
        // this delegate accepts any method returning void
        // and its parameter type is string
        public delegate void CarEngineHandler(string msgForCaller);

        // 2) Define a member variable of this delegate.
        private CarEngineHandler _listOfHandlers;

        // 3) Add registration function for the caller.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            _listOfHandlers = methodToCall;
        }


        // 4) Implement the Accelerate() method to invoke the delegate's
        // invocation list under the correct circumstances.
        public void Accelerate(int delta)
        {
            // If this car is "dead," send dead message.
            if (_carIsDead)
            {
                _listOfHandlers?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                
                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrentSpeed))
                {
                    _listOfHandlers?.Invoke("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                {
                    _carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }
}
