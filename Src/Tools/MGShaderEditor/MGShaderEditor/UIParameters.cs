using System.Globalization;

namespace MGShaderEditor
{


    public class UIbaseParam
    {
        public string Name { get; set; }

    }

    /// <summary>
    /// UI Parameter for .fx float
    /// </summary>
    public class UIFloatParam : UIbaseParam
    {

        public float MinRange { get; set; }
        public float MaxRange { get; set; }

        public float Value { get; set; }

        public UIFloatParam(float _min, float _max)
        {
            MinRange = _min;
            MaxRange = _max;
        }

        public static UIFloatParam FromString(string _inputs, string _value)
        {
            //Inputs => display name, minvalue, maxvalue
            //ex. "Factor", 0.0, 10.0
            var inputs = _inputs.Split(',');
            if (inputs.Length != 3)
                return null;

            string name = inputs[0].Replace("\"", "");

            float min, max;
            if (!float.TryParse(inputs[1], NumberStyles.Float, CultureInfo.InvariantCulture, out min))
                return null;

            if (!float.TryParse(inputs[2], NumberStyles.Float, CultureInfo.InvariantCulture, out max))
                return null;

            //Value 
            //ex. 0.0
            float value;
            if (!float.TryParse(_value, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return null;

            //Create instance
            if (min < max)
            {
                var param = new UIFloatParam(min, max);
                param.Name = name;
                param.Value = value;
                return param;
            }

            return null;
        }

    }

    /// <summary>
    /// UI Parameter for .fx Texture2D
    /// </summary>
    public class UITexture2DParam : UIbaseParam
    {
        public string Value { get; set; }

        public UITexture2DParam(string _slotID)
        {

        }

        public static UITexture2DParam FromString(string _inputs, string _value)
        {
            //Inputs => display name
            //ex. "xAmbiantTex"
            string name = _inputs.Replace("\"", "");

            //Value 
            //ex. "0" -> slotIdx
            string value = _value;

            //Create instance
            var param = new UITexture2DParam(value);
            param.Name = name;
            param.Value = value;
            return param;

        }
    }


}
