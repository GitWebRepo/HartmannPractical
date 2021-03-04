namespace HartmannPractical
{
    public interface IByteSerializer
    {
        /// <summary>
        /// Serializes generic into a byte array
        /// </summary>
        /// <typeparam name="T">Type of object to be serialized</typeparam>
        /// <param name="input">Generic object to serialize</param>
        /// <returns>Byte array representation of input</returns>
        byte[] Serialize<T>(T input); 
    }
}
