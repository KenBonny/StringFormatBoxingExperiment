using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace KenBonny.StringFormatBoxingExperiment
{
    public class StringInterpolationBoxingTests : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Stopwatch _stopwatch;

        public StringInterpolationBoxingTests(ITestOutputHelper output)
        {
            _output = output;
            _stopwatch = Stopwatch.StartNew();
        }


        public void Dispose()
        {
            _stopwatch.Stop();
            _output.WriteLine("Time to process string {0}", _stopwatch.Elapsed.ToString("c"));
        }

        [Fact]
        public void Single_Interpolation_without_ToString()
        {
            var i = 1;
            var format = $"Number: {i}";
        }

        [Fact]
        public void Million_Interpolation_without_ToString()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                var format = $"Number: {i}";
            }
        }

        [Fact]
        public void Single_Interpolation_with_ToString()
        {
            var i = 1;
            var format = $"Number: {i.ToString()}";
        }

        [Fact]
        public void Million_Interpolation_with_ToString()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                var format = $"Number: {i.ToString()}";
            }
        }
    }
}
