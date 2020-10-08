using System;
using System.Collections.Generic;
using System.Text;

namespace PostcodeLookupTool.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostcodeLookup
    {
        string[] GetValidDeliveryOptions(string postcode);
    }
}
