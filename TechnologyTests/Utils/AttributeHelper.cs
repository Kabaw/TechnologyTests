using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TechnologyTests.Utils;

public class AttributeHelper
{
    public static T GetAtribute<T>(Type objType) where T : Attribute
    {
        var attri = Attribute.GetCustomAttribute(objType, typeof(T));

        if (attri is null)
            throw new NullReferenceException($"The class of type '{objType}' do not has the specified attribute");

        return (T)attri;
    }
}

//public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
//{
//    var attrType = typeof(T);
//    var property = instance.GetType().GetProperty(propertyName);
//    return (T)property.GetCustomAttributes(attrType, false).First();
//}

//var name = player.GetAttributeFrom<DisplayAttribute>(nameof(player.PlayerDescription)).Name;
//var maxLength = player.GetAttributeFrom<MaxLengthAttribute>(nameof(player.PlayerName)).Length;