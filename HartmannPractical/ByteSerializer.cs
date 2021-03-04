using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using HartmannPractical.Data;

namespace HartmannPractical
{    
    public class ByteSerializer : IByteSerializer
    {
        /// <summary>
        /// Serializes generic into a byte array
        /// </summary>
        /// <typeparam name="T">Type of object to be serialized</typeparam>
        /// <param name="input">Generic object to serialize</param>
        /// <returns>Byte array representation of input</returns>      
         
        public byte[] Serialize<T>(T input)
        {                       
            // Sort by order attribute
            var values = typeof(T).GetProperties()             
             .OrderBy(p => Attribute.IsDefined(p, typeof(OrderAttribute)) ? p.GetCustomAttribute<OrderAttribute>().Position : int.MaxValue)
             .Select(p => p.GetValue(input))             
             .ToArray();

            // Pad by maximum length attribute
            var list = new List<string>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            
            int countValues = 0; // Values counter for length attribute location
                        
            foreach (PropertyInfo property in properties)
            {                
                var attr = (StringLengthAttribute[])property.GetCustomAttributes(typeof(StringLengthAttribute), false);
                string str = property.Name.ToString();

                char pad = ' ';
                if (attr.Length > 0)
                {
                    str = str.PadRight(attr[0].MaximumLength, pad);
                    list.Add(str);
                }
                else
                {
                    if (values[countValues].ToString() != "False") // Do not add properties without order attribute            
                        list.Add(values[countValues].ToString());
                }
                countValues++; 
            }            

            // DateTime.Ticks to convert DateTime to bytes
            DateTime dateTime;
            StringBuilder sb = new StringBuilder();
            
            foreach (string s in list)
            {
                var isDateTime = DateTime.TryParse(s, out dateTime);
                if (isDateTime)
                {
                    DateTime dt = DateTime.Parse(s);
                    long a = dt.Ticks;
                    sb.Append(BitConverter.GetBytes(a));
                }                
                sb.Append(s);
            }

            // ASCII encoding
            byte[] byteArray = Encoding.ASCII.GetBytes(sb.ToString());            

            return byteArray;                       
        }
    }
}
