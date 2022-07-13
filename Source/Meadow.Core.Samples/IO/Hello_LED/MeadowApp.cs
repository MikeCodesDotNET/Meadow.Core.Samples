﻿using Meadow;
using Meadow.Devices;
using Meadow.Hardware;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hello_LED
{
    public class MeadowApp : App<F7FeatherV2>
    {
        IDigitalOutputPort _redLED;
        IDigitalOutputPort _blueLED;
        IDigitalOutputPort _greenLED;

        public override Task Initialize()
        {
            Console.WriteLine("Creating Outputs");
            _redLED = Device.CreateDigitalOutputPort(Device.Pins.OnboardLedRed);
            _blueLED = Device.CreateDigitalOutputPort(Device.Pins.OnboardLedBlue);
            _greenLED = Device.CreateDigitalOutputPort(Device.Pins.OnboardLedGreen);

            return Task.CompletedTask;
        }

        public override Task Run()
        {
            var state = false;
            var stateCount = 0;

            while (true)
            {
                state = !state;

                Console.WriteLine($" Count: {++stateCount}, State: {state}");

                _redLED.State = state;
                Thread.Sleep(200);
                _greenLED.State = state;
                Thread.Sleep(200);
                _blueLED.State = state;
                Thread.Sleep(200);
            }

            return Task.CompletedTask;
        }
    }
}