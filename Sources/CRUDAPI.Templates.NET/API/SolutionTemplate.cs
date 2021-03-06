// ------------------------------------------------------------------------------
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
    
    #line 1 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class SolutionTemplate : SolutionTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            
            #line 12 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

	var functionProjects = new Dictionary<string, string>();

            
            #line default
            #line hidden
            this.Write("\r\nMicrosoft Visual Studio Solution File, Format Version 12.00\r\n# Visual Studio Ve" +
                    "rsion 17\r\nVisualStudioVersion = 17.0.32014.148\r\nMinimumVisualStudioVersion = 10." +
                    "0.40219.1\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.Common\", \"C" +
                    "RUD.Common\\CRUD.Common.csproj\", \"{F0238ADA-9D26-4F20-AF10-CF24EBB8AA3F}\"\r\nEndPro" +
                    "ject\r\nProject(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"Services\", \"Services\"" +
                    ", \"{812EC8C4-DF64-4E7E-93BC-FA8CF25A095A}\"\r\nEndProject\r\nProject(\"{2150E333-8FDC-" +
                    "42A3-9474-1A3956D46DE8}\") = \"Tests\", \"Tests\", \"{2820586E-CE98-444F-AD08-12F2E4CA" +
                    "835B}\"\r\nEndProject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.DT" +
                    "O\", \"CRUD.DTO\\CRUD.DTO.csproj\", \"{242244DE-FCCA-4226-9F9A-E6FCD9EEA125}\"\r\nEndPro" +
                    "ject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.DAL.MSSQL\", \"CRU" +
                    "D.DAL.MSSQL\\CRUD.DAL.MSSQL.csproj\", \"{76C4AFCB-22F6-4CB1-ACFC-CEC8027254CD}\"\r\nEn" +
                    "dProject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.Interfaces\"," +
                    " \"CRUD.Interfaces\\CRUD.Interfaces.csproj\", \"{F08C05FC-2F7B-4281-9B29-81537F670FD" +
                    "3}\"\r\nEndProject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.Utils" +
                    "\", \"CRUD.Utils\\CRUD.Utils.csproj\", \"{2EED79EF-A4FE-45AB-A1B9-796ECD3B9473}\"\r\nEnd" +
                    "Project\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUDTemplate.API\"," +
                    " \"Services\\CRUD.API\\CRUDTemplate.API.csproj\", \"{C79E6270-2B15-46BD-B228-CCD4FE82" +
                    "CEA8}\"\r\nEndProject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"Test.E2" +
                    "E.CRUD.API\", \"Tests\\Test.CRUD.API\\Test.E2E.CRUD.API.csproj\", \"{708E8211-8E38-42F" +
                    "D-8DB7-DA42509FFE3E}\"\r\nEndProject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F755" +
                    "6}\") = \"Test.CRUD.DAL.MSSQL\", \"Tests\\Test.CRUD.DAL.MSSQL\\Test.CRUD.DAL.MSSQL.csp" +
                    "roj\", \"{4A00A7A1-8666-41B6-8381-73C008CE8A93}\"\r\nEndProject\r\nProject(\"{9A19103F-1" +
                    "6F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.DAL.EF\", \"CRUD.DAL.EF\\CRUD.DAL.EF.csproj\"," +
                    " \"{26AAE746-CF68-4ED3-BB04-255722C70102}\"\r\nEndProject\r\nProject(\"{9A19103F-16F7-4" +
                    "668-BE54-9A1E7A4F7556}\") = \"Test.CRUD.Common\", \"Tests\\Test.CRUD.Common\\Test.CRUD" +
                    ".Common.csproj\", \"{32E54D18-F5AA-4567-931A-05EF290A5C5D}\"\r\nEndProject\r\nProject(\"" +
                    "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"Test.CRUD.DAL.EF\", \"Tests\\Test.CRUD." +
                    "DAL.EF\\Test.CRUD.DAL.EF.csproj\", \"{0B252E9F-686A-41EC-BE4C-ED7504D63475}\"\r\nEndPr" +
                    "oject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.Services.DAL\", " +
                    "\"CRUD.Services.DAL\\CRUD.Services.DAL.csproj\", \"{86ADDCE8-6E78-400A-9646-E22F58C6" +
                    "1AA5}\"\r\nEndProject\r\nProject(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"Functio" +
                    "ns\", \"Functions\", \"{6D7BA996-E702-42BE-B715-344F9C58DC75}\"\r\nEndProject\r\nProject(" +
                    "\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.Functions.Common\", \"Functions\\" +
                    "CRUD.Functions.Common\\CRUD.Functions.Common.csproj\", \"{9F812B84-46D3-439C-A380-7" +
                    "82D8D0CEADA}\"\r\nEndProject\r\n");
            
            #line 52 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

	foreach(var t in tables)
	{
		var guid = Guid.NewGuid().ToString().ToUpper();
		functionProjects.Add(t.Name, guid);
		var funProjName = string.Format(FunctionProjectNameTemplate, t.Name);
		var funProjPath = string.Format("Functions\\{0}\\{0}.csproj", funProjName);

            
            #line default
            #line hidden
            this.Write("Project(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"");
            
            #line 60 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(funProjName));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            #line 60 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(funProjPath));
            
            #line default
            #line hidden
            this.Write("\" , \"{");
            
            #line 60 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(guid));
            
            #line default
            #line hidden
            this.Write("}\"\r\nEndProject\r\n");
            
            #line 62 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

	}

            
            #line default
            #line hidden
            this.Write("Project(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"CRUD.Services.Common\", \"CRUD" +
                    ".Services.Common\\CRUD.Services.Common.csproj\", \"{95579090-C899-42F2-89AC-068EA5C" +
                    "6D808}\"\r\nEndProject\r\nProject(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"Test.F" +
                    "unctions.Common\", \"Tests\\Test.Functions.Common\\Test.Functions.Common.csproj\", \"{" +
                    "23809777-E3CC-4D0A-900E-E29EDA123E01}\"\r\nEndProject\r\nProject(\"{9A19103F-16F7-4668" +
                    "-BE54-9A1E7A4F7556}\") = \"Test.E2E.CRUD.Functions\", \"Tests\\Test.E2E.Functions\\Tes" +
                    "t.E2E.CRUD.Functions.csproj\", \"{E47E0CD9-9665-4B97-8494-0BC23A414F08}\"\r\nEndProje" +
                    "ct\r\nGlobal\r\n\tGlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n\t\tDebu" +
                    "g|Any CPU = Debug|Any CPU\r\n\t\tRelease|Any CPU = Release|Any CPU\r\n\tEndGlobalSectio" +
                    "n\r\n\tGlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n\t\t{F0238ADA-9D2" +
                    "6-4F20-AF10-CF24EBB8AA3F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{F0238ADA-9" +
                    "D26-4F20-AF10-CF24EBB8AA3F}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{F0238ADA-9" +
                    "D26-4F20-AF10-CF24EBB8AA3F}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{F023" +
                    "8ADA-9D26-4F20-AF10-CF24EBB8AA3F}.Release|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{" +
                    "242244DE-FCCA-4226-9F9A-E6FCD9EEA125}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t" +
                    "\t{242244DE-FCCA-4226-9F9A-E6FCD9EEA125}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t" +
                    "\t{242244DE-FCCA-4226-9F9A-E6FCD9EEA125}.Release|Any CPU.ActiveCfg = Release|Any " +
                    "CPU\r\n\t\t{242244DE-FCCA-4226-9F9A-E6FCD9EEA125}.Release|Any CPU.Build.0 = Release|" +
                    "Any CPU\r\n\t\t{76C4AFCB-22F6-4CB1-ACFC-CEC8027254CD}.Debug|Any CPU.ActiveCfg = Debu" +
                    "g|Any CPU\r\n\t\t{76C4AFCB-22F6-4CB1-ACFC-CEC8027254CD}.Debug|Any CPU.Build.0 = Debu" +
                    "g|Any CPU\r\n\t\t{76C4AFCB-22F6-4CB1-ACFC-CEC8027254CD}.Release|Any CPU.ActiveCfg = " +
                    "Release|Any CPU\r\n\t\t{76C4AFCB-22F6-4CB1-ACFC-CEC8027254CD}.Release|Any CPU.Build." +
                    "0 = Release|Any CPU\r\n\t\t{F08C05FC-2F7B-4281-9B29-81537F670FD3}.Debug|Any CPU.Acti" +
                    "veCfg = Debug|Any CPU\r\n\t\t{F08C05FC-2F7B-4281-9B29-81537F670FD3}.Debug|Any CPU.Bu" +
                    "ild.0 = Debug|Any CPU\r\n\t\t{F08C05FC-2F7B-4281-9B29-81537F670FD3}.Release|Any CPU." +
                    "ActiveCfg = Release|Any CPU\r\n\t\t{F08C05FC-2F7B-4281-9B29-81537F670FD3}.Release|An" +
                    "y CPU.Build.0 = Release|Any CPU\r\n\t\t{2EED79EF-A4FE-45AB-A1B9-796ECD3B9473}.Debug|" +
                    "Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{2EED79EF-A4FE-45AB-A1B9-796ECD3B9473}.Debu" +
                    "g|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{2EED79EF-A4FE-45AB-A1B9-796ECD3B9473}.Rele" +
                    "ase|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{2EED79EF-A4FE-45AB-A1B9-796ECD3B9473" +
                    "}.Release|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{C79E6270-2B15-46BD-B228-CCD4FE82" +
                    "CEA8}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{C79E6270-2B15-46BD-B228-CCD4FE" +
                    "82CEA8}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{C79E6270-2B15-46BD-B228-CCD4FE" +
                    "82CEA8}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{C79E6270-2B15-46BD-B228-" +
                    "CCD4FE82CEA8}.Release|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{708E8211-8E38-42FD-8" +
                    "DB7-DA42509FFE3E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{708E8211-8E38-42FD" +
                    "-8DB7-DA42509FFE3E}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{708E8211-8E38-42FD" +
                    "-8DB7-DA42509FFE3E}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{708E8211-8E3" +
                    "8-42FD-8DB7-DA42509FFE3E}.Release|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{4A00A7A1" +
                    "-8666-41B6-8381-73C008CE8A93}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{4A00A7" +
                    "A1-8666-41B6-8381-73C008CE8A93}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{4A00A7" +
                    "A1-8666-41B6-8381-73C008CE8A93}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{" +
                    "4A00A7A1-8666-41B6-8381-73C008CE8A93}.Release|Any CPU.Build.0 = Release|Any CPU\r" +
                    "\n\t\t{26AAE746-CF68-4ED3-BB04-255722C70102}.Debug|Any CPU.ActiveCfg = Debug|Any CP" +
                    "U\r\n\t\t{26AAE746-CF68-4ED3-BB04-255722C70102}.Debug|Any CPU.Build.0 = Debug|Any CP" +
                    "U\r\n\t\t{26AAE746-CF68-4ED3-BB04-255722C70102}.Release|Any CPU.ActiveCfg = Release|" +
                    "Any CPU\r\n\t\t{26AAE746-CF68-4ED3-BB04-255722C70102}.Release|Any CPU.Build.0 = Rele" +
                    "ase|Any CPU\r\n\t\t{32E54D18-F5AA-4567-931A-05EF290A5C5D}.Debug|Any CPU.ActiveCfg = " +
                    "Debug|Any CPU\r\n\t\t{32E54D18-F5AA-4567-931A-05EF290A5C5D}.Debug|Any CPU.Build.0 = " +
                    "Debug|Any CPU\r\n\t\t{32E54D18-F5AA-4567-931A-05EF290A5C5D}.Release|Any CPU.ActiveCf" +
                    "g = Release|Any CPU\r\n\t\t{32E54D18-F5AA-4567-931A-05EF290A5C5D}.Release|Any CPU.Bu" +
                    "ild.0 = Release|Any CPU\r\n\t\t{0B252E9F-686A-41EC-BE4C-ED7504D63475}.Debug|Any CPU." +
                    "ActiveCfg = Debug|Any CPU\r\n\t\t{0B252E9F-686A-41EC-BE4C-ED7504D63475}.Debug|Any CP" +
                    "U.Build.0 = Debug|Any CPU\r\n\t\t{0B252E9F-686A-41EC-BE4C-ED7504D63475}.Release|Any " +
                    "CPU.ActiveCfg = Release|Any CPU\r\n\t\t{0B252E9F-686A-41EC-BE4C-ED7504D63475}.Releas" +
                    "e|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{86ADDCE8-6E78-400A-9646-E22F58C61AA5}.De" +
                    "bug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{86ADDCE8-6E78-400A-9646-E22F58C61AA5}." +
                    "Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{86ADDCE8-6E78-400A-9646-E22F58C61AA5}." +
                    "Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{86ADDCE8-6E78-400A-9646-E22F58C6" +
                    "1AA5}.Release|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{9F812B84-46D3-439C-A380-782D" +
                    "8D0CEADA}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{9F812B84-46D3-439C-A380-78" +
                    "2D8D0CEADA}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{9F812B84-46D3-439C-A380-78" +
                    "2D8D0CEADA}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{9F812B84-46D3-439C-A" +
                    "380-782D8D0CEADA}.Release|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{95579090-C899-42" +
                    "F2-89AC-068EA5C6D808}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{95579090-C899-" +
                    "42F2-89AC-068EA5C6D808}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{95579090-C899-" +
                    "42F2-89AC-068EA5C6D808}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{95579090" +
                    "-C899-42F2-89AC-068EA5C6D808}.Release|Any CPU.Build.0 = Release|Any CPU\r\n\t\t{2380" +
                    "9777-E3CC-4D0A-900E-E29EDA123E01}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{23" +
                    "809777-E3CC-4D0A-900E-E29EDA123E01}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{23" +
                    "809777-E3CC-4D0A-900E-E29EDA123E01}.Release|Any CPU.ActiveCfg = Release|Any CPU\r" +
                    "\n\t\t{23809777-E3CC-4D0A-900E-E29EDA123E01}.Release|Any CPU.Build.0 = Release|Any " +
                    "CPU\r\n\t\t{E47E0CD9-9665-4B97-8494-0BC23A414F08}.Debug|Any CPU.ActiveCfg = Debug|An" +
                    "y CPU\r\n\t\t{E47E0CD9-9665-4B97-8494-0BC23A414F08}.Debug|Any CPU.Build.0 = Debug|An" +
                    "y CPU\r\n\t\t{E47E0CD9-9665-4B97-8494-0BC23A414F08}.Release|Any CPU.ActiveCfg = Rele" +
                    "ase|Any CPU\r\n\t\t{E47E0CD9-9665-4B97-8494-0BC23A414F08}.Release|Any CPU.Build.0 = " +
                    "Release|Any CPU\r\n\r\n");
            
            #line 142 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

	foreach(var t in tables)
	{
		var guid = functionProjects[t.Name];

            
            #line default
            #line hidden
            this.Write("\t\t{");
            
            #line 147 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(guid));
            
            #line default
            #line hidden
            this.Write("}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n\t\t{");
            
            #line 148 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(guid));
            
            #line default
            #line hidden
            this.Write("}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n\t\t{");
            
            #line 149 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(guid));
            
            #line default
            #line hidden
            this.Write("}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n\t\t{");
            
            #line 150 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(guid));
            
            #line default
            #line hidden
            this.Write("}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");
            
            #line 151 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

	}

            
            #line default
            #line hidden
            this.Write(@"	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
		{C79E6270-2B15-46BD-B228-CCD4FE82CEA8} = {812EC8C4-DF64-4E7E-93BC-FA8CF25A095A}
		{708E8211-8E38-42FD-8DB7-DA42509FFE3E} = {2820586E-CE98-444F-AD08-12F2E4CA835B}
		{4A00A7A1-8666-41B6-8381-73C008CE8A93} = {2820586E-CE98-444F-AD08-12F2E4CA835B}
		{32E54D18-F5AA-4567-931A-05EF290A5C5D} = {2820586E-CE98-444F-AD08-12F2E4CA835B}
		{0B252E9F-686A-41EC-BE4C-ED7504D63475} = {2820586E-CE98-444F-AD08-12F2E4CA835B}
		{9F812B84-46D3-439C-A380-782D8D0CEADA} = {6D7BA996-E702-42BE-B715-344F9C58DC75}
");
            
            #line 165 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

	foreach(var t in tables)
	{
		var guid = functionProjects[t.Name];

            
            #line default
            #line hidden
            this.Write("\t\t{");
            
            #line 170 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(guid));
            
            #line default
            #line hidden
            this.Write("} = {6D7BA996-E702-42BE-B715-344F9C58DC75}\r\n");
            
            #line 171 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

	}

            
            #line default
            #line hidden
            this.Write(@"		{23809777-E3CC-4D0A-900E-E29EDA123E01} = {2820586E-CE98-444F-AD08-12F2E4CA835B}
		{E47E0CD9-9665-4B97-8494-0BC23A414F08} = {2820586E-CE98-444F-AD08-12F2E4CA835B}
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {CCC25D44-E0EE-4AA8-BD23-47C384963292}
	EndGlobalSection
EndGlobal
");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\Projects\CRUDApiGenerator\Sources\CRUDAPI.Templates.NET\API\SolutionTemplate.tt"

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

private string _FunctionProjectNameTemplateField;

/// <summary>
/// Access the FunctionProjectNameTemplate parameter of the template.
/// </summary>
private string FunctionProjectNameTemplate
{
    get
    {
        return this._FunctionProjectNameTemplateField;
    }
}

private global::System.Collections.Generic.IList<CRUDAPI.DataModel.DataTable> _tablesField;

/// <summary>
/// Access the tables parameter of the template.
/// </summary>
private global::System.Collections.Generic.IList<CRUDAPI.DataModel.DataTable> tables
{
    get
    {
        return this._tablesField;
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
bool FunctionProjectNameTemplateValueAcquired = false;
if (this.Session.ContainsKey("FunctionProjectNameTemplate"))
{
    this._FunctionProjectNameTemplateField = ((string)(this.Session["FunctionProjectNameTemplate"]));
    FunctionProjectNameTemplateValueAcquired = true;
}
if ((FunctionProjectNameTemplateValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("FunctionProjectNameTemplate");
    if ((data != null))
    {
        this._FunctionProjectNameTemplateField = ((string)(data));
    }
}
bool tablesValueAcquired = false;
if (this.Session.ContainsKey("tables"))
{
    this._tablesField = ((global::System.Collections.Generic.IList<CRUDAPI.DataModel.DataTable>)(this.Session["tables"]));
    tablesValueAcquired = true;
}
if ((tablesValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("tables");
    if ((data != null))
    {
        this._tablesField = ((global::System.Collections.Generic.IList<CRUDAPI.DataModel.DataTable>)(data));
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
    public class SolutionTemplateBase
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
