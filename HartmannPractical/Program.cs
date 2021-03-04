using System;
using System.Linq;
using HartmannPractical.Data;

namespace HartmannPractical
{
    class Program
    {
        static void Main(string[] args)
        {
            ///IByteSerializer serializer = null;
            ByteSerializer serializer = new ByteSerializer();

            IPracticalTest test = new PracticalTest(serializer);

            if (test.Validate())
                Console.WriteLine("IByteSerializer implementation is correct");
            else
                Console.WriteLine("IByteSerializer implemetnation is not correct");

            Console.Read();
        }
    }
}
