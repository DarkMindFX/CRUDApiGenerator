﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CRUDAPI.Template.NET.API
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class IServiceDalTemplate : IServiceDalTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            this.Write("\r\nusing ");
            
            #line 14 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(RootNamespace));
            
            #line default
            #line hidden
            this.Write(".Interfaces.Entities;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing Sy" +
                    "stem.Text;\r\n\r\nnamespace ");
            
            #line 19 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(RootNamespace));
            
            #line default
            #line hidden
            this.Write(".Services.Dal\r\n{\r\n    public interface I");
            
            #line 21 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("Dal : IDalBase<");
            
            #line 21 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n        ");
            
            #line 23 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write(" Get(");
            
            #line 23 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

            var pks = modelHelper.GetPKColumns(table);
            for(int i = 0; i < pks.Count; ++i)
            {
            var pk = pks[i];
        
            
            #line default
            #line hidden
            
            #line 28 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelHelper.DbTypeToType(pk)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 28 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(pk.Name));
            
            #line default
            #line hidden
            
            #line 28 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i+1 < pks.Count ? "," : string.Empty));
            
            #line default
            #line hidden
            
            #line 28 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n        bool Delete(");
            
            #line 30 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

            for(int i = 0; i < pks.Count; ++i)
            {
            var pk = pks[i];
        
            
            #line default
            #line hidden
            
            #line 34 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelHelper.DbTypeToType(pk)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 34 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(pk.Name));
            
            #line default
            #line hidden
            
            #line 34 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i+1 < pks.Count ? "," : string.Empty));
            
            #line default
            #line hidden
            
            #line 34 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n    ");
            
            #line 36 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

            foreach(var c in table.Columns)
            {
                if(!string.IsNullOrEmpty(c.FKRefTable))
                {
    
            
            #line default
            #line hidden
            this.Write("        IList<");
            
            #line 42 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("> GetBy");
            
            #line 42 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 42 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelHelper.DbTypeToType(c)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 42 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n    ");
            
            #line 43 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

                }
            }
    
            
            #line default
            #line hidden
            this.Write("\r\n    ");
            
            #line 48 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

            if(IsSoftDelete && table.HasColumn(SoftDeleteField))
            {
        
            
            #line default
            #line hidden
            this.Write("        bool Erase(");
            
            #line 52 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

            for(int i = 0; i < pks.Count; ++i)
            {
            var pk = pks[i];
        
            
            #line default
            #line hidden
            
            #line 56 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelHelper.DbTypeToType(pk)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 56 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(pk.Name));
            
            #line default
            #line hidden
            
            #line 56 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i+1 < pks.Count ? "," : string.Empty));
            
            #line default
            #line hidden
            
            #line 56 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(");\r\n        ");
            
            #line 57 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

            }
        
            
            #line default
            #line hidden
            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\IServiceDalTemplate.tt"

private string _RootNamespaceField;

/// <summary>
/// Access the RootNamespace parameter of the template.
/// </summary>
private string RootNamespace
{
    get
    {
        return this._RootNamespaceField;
    }
}

private global::CRUDAPI.DataModel.DataTable _tableField;

/// <summary>
/// Access the table parameter of the template.
/// </summary>
private global::CRUDAPI.DataModel.DataTable table
{
    get
    {
        return this._tableField;
    }
}

private global::CRUDAPI.DataModel.ModelHelper _modelHelperField;

/// <summary>
/// Access the modelHelper parameter of the template.
/// </summary>
private global::CRUDAPI.DataModel.ModelHelper modelHelper
{
    get
    {
        return this._modelHelperField;
    }
}

private bool _IsSoftDeleteField;

/// <summary>
/// Access the IsSoftDelete parameter of the template.
/// </summary>
private bool IsSoftDelete
{
    get
    {
        return this._IsSoftDeleteField;
    }
}

private string _SoftDeleteFieldField;

/// <summary>
/// Access the SoftDeleteField parameter of the template.
/// </summary>
private string SoftDeleteField
{
    get
    {
        return this._SoftDeleteFieldField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool RootNamespaceValueAcquired = false;
if (this.Session.ContainsKey("RootNamespace"))
{
    this._RootNamespaceField = ((string)(this.Session["RootNamespace"]));
    RootNamespaceValueAcquired = true;
}
if ((RootNamespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("RootNamespace");
    if ((data != null))
    {
        this._RootNamespaceField = ((string)(data));
    }
}
bool tableValueAcquired = false;
if (this.Session.ContainsKey("table"))
{
    this._tableField = ((global::CRUDAPI.DataModel.DataTable)(this.Session["table"]));
    tableValueAcquired = true;
}
if ((tableValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("table");
    if ((data != null))
    {
        this._tableField = ((global::CRUDAPI.DataModel.DataTable)(data));
    }
}
bool modelHelperValueAcquired = false;
if (this.Session.ContainsKey("modelHelper"))
{
    this._modelHelperField = ((global::CRUDAPI.DataModel.ModelHelper)(this.Session["modelHelper"]));
    modelHelperValueAcquired = true;
}
if ((modelHelperValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("modelHelper");
    if ((data != null))
    {
        this._modelHelperField = ((global::CRUDAPI.DataModel.ModelHelper)(data));
    }
}
bool IsSoftDeleteValueAcquired = false;
if (this.Session.ContainsKey("IsSoftDelete"))
{
    this._IsSoftDeleteField = ((bool)(this.Session["IsSoftDelete"]));
    IsSoftDeleteValueAcquired = true;
}
if ((IsSoftDeleteValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("IsSoftDelete");
    if ((data != null))
    {
        this._IsSoftDeleteField = ((bool)(data));
    }
}
bool SoftDeleteFieldValueAcquired = false;
if (this.Session.ContainsKey("SoftDeleteField"))
{
    this._SoftDeleteFieldField = ((string)(this.Session["SoftDeleteField"]));
    SoftDeleteFieldValueAcquired = true;
}
if ((SoftDeleteFieldValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("SoftDeleteField");
    if ((data != null))
    {
        this._SoftDeleteFieldField = ((string)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class IServiceDalTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
