﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CRUDAPI.Template.NET.Tests
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class UpdateSetupTemplate : UpdateSetupTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            this.Write("\r\n");
            
            #line 14 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	var pks = modelHelper.GetPKColumns(table);
	foreach(var c in table.Columns)
	{
		string val = string.Empty;

		if (!c.IsIdentity && testValsUpdateBefore.ContainsKey(c.Name))
        {
			Type columnType = modelHelper.GetColumnType(c);
            if (testValsUpdateBefore[c.Name] != null)
            {
				if(columnType == typeof(bool))
				{
					val = (bool)testValsUpdateBefore[c.Name] ? "1" : "0";
				}
				else 
				{
					string quote = string.Empty;
					if(columnType == typeof(string) || columnType == typeof(DateTime))
					{
						quote = "'";
					}
					val = quote + testValsUpdateBefore[c.Name].ToString() + quote;
				}
			}
            else
			{
				val = "NULL";
			}
        }
		else
		{
			val = "NULL";
		}

            
            #line default
            #line hidden
            
            #line 49 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelHelper.GenerateVariableDeclaration(c)));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 49 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(val));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 50 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	}

            
            #line default
            #line hidden
            this.Write(" \r\n\r\n\r\nIF(NOT EXISTS(SELECT 1 FROM \r\n\t\t\t\t\t[dbo].[");
            
            #line 56 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("]\r\n\t\t\t\tWHERE \r\n");
            
            #line 58 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	for(int i = 0; i < table.Columns.Count; ++i) 
	{
		var c = table.Columns[i];
		if(!c.IsIdentity)
		{

            
            #line default
            #line hidden
            this.Write("\t(CASE WHEN @");
            
            #line 65 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write(" IS NOT NULL THEN (CASE WHEN [");
            
            #line 65 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write("] = @");
            
            #line 65 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write(" THEN 1 ELSE 0 END) ELSE 1 END) = 1 ");
            
            #line 65 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i + 1 < table.Columns.Count ? "AND" : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 66 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

		}
	}

            
            #line default
            #line hidden
            this.Write(" ))\r\n\t\t\t\t\t\r\nBEGIN\r\n\tINSERT INTO [dbo].[");
            
            #line 72 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("]\r\n\t\t(\r\n");
            
            #line 74 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

for(int i = 0; i < table.Columns.Count; ++i) 
	{
		var c = table.Columns[i];
		if(!c.IsIdentity)
		{

            
            #line default
            #line hidden
            this.Write("\t [");
            
            #line 81 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write("]");
            
            #line 81 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i + 1 < table.Columns.Count ? "," : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 82 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

		}
	}

            
            #line default
            #line hidden
            this.Write("\t\t)\r\n\tSELECT \t\t\r\n\t\t");
            
            #line 88 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

for(int i = 0; i < table.Columns.Count; ++i) 
	{
		var c = table.Columns[i];
		if(!c.IsIdentity)
		{

            
            #line default
            #line hidden
            this.Write("\t @");
            
            #line 95 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            
            #line 95 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i + 1 < table.Columns.Count ? "," : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 96 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

		}
	}

            
            #line default
            #line hidden
            this.Write("END\r\n\r\nSELECT TOP 1 \r\n");
            
            #line 103 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	for(int i = 0; i < pks.Count; ++i)
	{
		var pk = pks[i];

            
            #line default
            #line hidden
            this.Write("\t@");
            
            #line 108 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(pk.Name));
            
            #line default
            #line hidden
            this.Write(" = [");
            
            #line 108 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(pk.Name));
            
            #line default
            #line hidden
            this.Write("]");
            
            #line 108 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i+1 < pks.Count ? ", " : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 109 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	}

            
            #line default
            #line hidden
            this.Write("FROM \r\n\t[dbo].[");
            
            #line 113 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("] e\r\nWHERE\r\n");
            
            #line 115 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	for(int i = 0; i < table.Columns.Count; ++i) 
	{
		var c = table.Columns[i];
		if(!c.IsIdentity)
		{

            
            #line default
            #line hidden
            this.Write("\t(CASE WHEN @");
            
            #line 122 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write(" IS NOT NULL THEN (CASE WHEN [");
            
            #line 122 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write("] = @");
            
            #line 122 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(c.Name));
            
            #line default
            #line hidden
            this.Write(" THEN 1 ELSE 0 END) ELSE 1 END) = 1 ");
            
            #line 122 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i + 1 < table.Columns.Count ? "AND" : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 123 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

		}
	}

            
            #line default
            #line hidden
            this.Write("\r\nSELECT \r\n");
            
            #line 129 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	for(int i = 0; i < pks.Count; ++i)
	{
		var pk = pks[i];

            
            #line default
            #line hidden
            this.Write("\t@");
            
            #line 134 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(pk.Name));
            
            #line default
            #line hidden
            
            #line 134 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i+1 < pks.Count ? ", " : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 135 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

	}

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\Tests\UpdateSetupTemplate.tt"

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

private global::System.Collections.Generic.IDictionary<string,object> _testValsUpdateBeforeField;

/// <summary>
/// Access the testValsUpdateBefore parameter of the template.
/// </summary>
private global::System.Collections.Generic.IDictionary<string,object> testValsUpdateBefore
{
    get
    {
        return this._testValsUpdateBeforeField;
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
bool testValsUpdateBeforeValueAcquired = false;
if (this.Session.ContainsKey("testValsUpdateBefore"))
{
    this._testValsUpdateBeforeField = ((global::System.Collections.Generic.IDictionary<string,object>)(this.Session["testValsUpdateBefore"]));
    testValsUpdateBeforeValueAcquired = true;
}
if ((testValsUpdateBeforeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("testValsUpdateBefore");
    if ((data != null))
    {
        this._testValsUpdateBeforeField = ((global::System.Collections.Generic.IDictionary<string,object>)(data));
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
    public class UpdateSetupTemplateBase
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
