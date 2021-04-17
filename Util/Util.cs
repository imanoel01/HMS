using System.Collections.Generic;
using System.Reflection;
using System;
using HMS.Model;
using HMS.EntityModel;

namespace HMS
{
    public static class Util
    {

        internal static IList<ModelMetaData> GetMetaData<T>()
        {

            List<ModelMetaData> metaData = new List<ModelMetaData>();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                ModelMetaData model = new ModelMetaData();
                foreach (var attr in property.CustomAttributes)
                {
                    if (attr.AttributeType == typeof(MetaDataAttribute))
                    {
                        model.Field = (string)attr.ConstructorArguments[0].Value;
                        model.FieldName = (string)attr.ConstructorArguments[1].Value;
                        model.FieldType = Enum.GetName(attr.ConstructorArguments[2].ArgumentType, attr.ConstructorArguments[2].Value);
                        model.DataUrl = (string)attr.ConstructorArguments[3].Value;
                        model.DataValueField = (string)attr.ConstructorArguments[4].Value;
                        model.DataDisplayField = (string)attr.ConstructorArguments[5].Value;

                    }
                    if (!string.IsNullOrWhiteSpace(model.FieldName))
                    {
                        metaData.Add(model);
                    }
                }
            }
            return metaData;
        }

        internal static IList<ModelMetaData> GetCustomerMetaData()
        {
            return GetMetaData<CustomerModel>();
        }

          internal static IList<ModelMetaData> GetRoomTypeMetaData()
        {
            return GetMetaData<RoomTypeModel>();
        }

        internal static IList<ModelMetaData> GetRoomMetaData(){
            return GetMetaData<RoomModel>();
        }

            internal static IList<ModelMetaData> GetRoomStatusMetaData(){
            return GetMetaData<RoomStatusModel>();
        }

        
    }
}