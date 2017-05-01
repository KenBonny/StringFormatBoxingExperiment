using System;
using System.Diagnostics;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace KenBonny.StringFormatBoxingExperiment
{
    public class StringBuilderBoxingTests : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Stopwatch _stopwatch;

        public StringBuilderBoxingTests(ITestOutputHelper output)
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
        public void Single_Append_without_ToString()
        {
            var i = 1;
            var format = new StringBuilder("Number: ").Append(i).ToString();
        }

        [Fact]
        public void Million_Append_without_ToString()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                var format = new StringBuilder("Number: ").Append(i).ToString();
            }
        }

        [Fact]
        public void Single_Append_with_ToString()
        {
            var i = 1;
            var format = new StringBuilder("Number: ").Append(i.ToString()).ToString();
        }

        [Fact]
        public void Million_Append_with_ToString()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                var format = new StringBuilder("Number: ").Append(i.ToString()).ToString();
            }
        }
    }
}
