using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace KenBonny.StringFormatBoxingExperiment
{
    public class StringFormatBoxingTests : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Stopwatch _stopwatch;

        public StringFormatBoxingTests(ITestOutputHelper output)
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
        public void Single_Format_without_ToString()
        {
            var i = 1;
            var format = string.Format("Number: {0}", i);
        }

        [Fact]
        public void Million_Format_without_ToString()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                var format = string.Format("Number: {0}", i);
            }
        }

        [Fact]
        public void Single_Format_with_ToString()
        {
            var i = 1;
            var format = string.Format("Number: {0}", i.ToString());
        }

        [Fact]
        public void Million_Format_with_ToString()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                var format = string.Format("Number: {0}", i.ToString());
            }
        }
    }
}
