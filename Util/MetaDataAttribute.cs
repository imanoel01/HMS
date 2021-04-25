using System;
namespace HMS
{
    [AttributeUsage(System.AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class MetaDataAttribute : Attribute
    {
        public MetaDataAttribute(string fieldName, string displayName, FieldType fieldType, string dataUrl = "", string dataValueField = "", string dataDisplayField = "",bool customSelect=false,string customSelectUrl="")
        {
            FieldName = fieldName;
            DisplayName = displayName;
            FieldType = fieldType;
            DataUrl = dataUrl;
            DataValueField = dataValueField;
            DataDisplayField = dataDisplayField;
            CustomSelect=customSelect;
            CustomSelectUrl=customSelectUrl;
        }

        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public FieldType FieldType { get; set; }
        public string DataUrl { get; set; }
        public string DataValueField { get; set; }
        public string DataDisplayField { get; set; }
        public bool CustomSelect { get; set; }
        public string CustomSelectUrl { get; set; }   
    }
}