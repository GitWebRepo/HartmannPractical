using HartmannPractical.Data;
using System;
using System.Linq;

namespace HartmannPractical
{
    public class PracticalTest : IPracticalTest
    {
        /// <summary>
        /// Expected result from serializing SampleData
        /// </summary>
        private static readonly byte[] EXPECTED_RESULT = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x54, 0x65, 0x73, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x74, 0x9B, 0x99, 0x7D, 0x43, 0xD8, 0x08 };

        private readonly IByteSerializer _byteSerializer;

        public PracticalTest(IByteSerializer serializer)
        {
            _byteSerializer = serializer;
        }

        /// <summary>
        /// Validates if practical assignment is successfully implemented
        /// </summary>
        /// <returns>Validation result</returns>
        public bool Validate()
        {
            // Sample data to be serialized
            var sampleData = new SampleData
            {
                Id = 1,
                Name = "Test",
                CreatedOn = new DateTime(2020, 08, 18, 13, 50, 0),
                Features = SampleFlags.A | SampleFlags.C
            };

            // Serializes sample data and compares result
            return _byteSerializer?.
                Serialize(sampleData).
                SequenceEqual(EXPECTED_RESULT) ?? false;
        }
    }
}
