namespace MasterProject.Core.Dto
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class DataPoint
    {
        public DataPoint(string x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        [DataMember(Name = "x")]
        public string X = null;

        [DataMember(Name = "y")]
        public double? Y = null;
    }
}