namespace FastPayDB.DatabaseModels.Base;

public class BaseFormSettingModel:BaseDataModel
{
        /// <summary>
        /// Gets or sets name for related field
        /// </summary>
        public string Name { get; set; } 
        
        /// <summary>
        /// Gets or sets default value
        /// </summary>
        public string? DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets IsHaveLabel
        /// </summary>
        public bool IsHaveLabel { get; set; } = true;
        
         /// <summary>
        /// Gets or sets LabelText ar/en
        /// </summary>
        public string? LabelText { get; set; } 
         
         /// <summary>
        /// Gets or sets ControlHint ar/en
        /// </summary>
        public string? ControlHint { get; set; } 
        
        /// <summary>
        /// Gets or sets IsRequired
        /// </summary>
        public string? Required { get; set; } 
        
        /// <summary>
        /// Gets or sets RequiredErrorMsg
        /// </summary>
        public string? RequiredErrorMsg { get; set; }
        
        /// <summary>
        /// Gets or sets Max Length
        /// </summary>
        public string? MaxLength { get; set; } 
        
        /// <summary>
        /// Gets or sets Max Length Error Msg
        /// </summary>
        public string? MaxLengthErrorMsg { get; set; }
        
        /// <summary>
        /// Gets or sets Min Length
        /// </summary>
        public string? MinLength { get; set; } 
        
        /// <summary>
        /// Gets or sets Min Length Error Msg
        /// </summary>
        public string? MinLengthErrorMsg { get; set; }
        
        /// <summary>
        /// Gets or sets IsUnique
        /// </summary>
        public bool? IsUnique { get; set; } 
        
        /// <summary>
        /// Gets or sets UniqueErrorMsg
        /// </summary>
        public string? UniqueErrorMsg { get; set; }
        
         /// <summary>
        /// Gets or sets ValidationExpression
        /// </summary>
        public string? ValidationExpression { get; set; } 
        
        /// <summary>
        /// Gets or sets ValidationExpressionErrorMsg
        /// </summary>
        public string? ValidationExpressionErrorMsg { get; set; }

        /// <summary>
        /// Gets or sets DataType DataTypeEnum [
        /// 1.Int
        /// 2.Float
        /// 3.String
        /// 4.Date
        /// ]
        /// </summary>
        public int DataType { get; set; } = 3; // String
        
        /// <summary>
        /// Gets or sets ControlType ControlTypeEnum [
        /// 1.DropList
        /// 2.CheckList
        /// 3.RadioList
        /// 4.TextDate
        /// 5.TextInt
        /// 6.TextFloat
        /// 7.TextEmail
        /// 8.TextPhone
        /// 9.TextMultiline
        /// 10.TextLabel
        /// 11.TextString
        /// 12.TextPassword
        /// 13.Checkbox
        /// 14.Setting
        /// ]
        /// </summary>
        public int ControlType { get; set; } = 11; // TextString
        
         /// <summary>
        /// Gets or sets position
        /// </summary>
        public int Position { get; set; } = 0;
        
        /// <summary>
        /// Gets or sets GeneralDescription ar/en
        /// </summary>
        public string? GeneralDescription { get; set; }
        
        /// <summary>
        /// Gets or sets setting value if ControlType = Setting
        /// </summary>
        public string? SettingValue { get; set; }
        
         /// <summary>
        /// Gets or sets is ready only to prevent user from update data
        /// </summary>
        public bool? IsReadOnly { get; set; }

         /// <summary>
         /// Gets or sets iAppliedFor
         /// </summary>
         public string AppliedFor { get; set; } = "None";


}