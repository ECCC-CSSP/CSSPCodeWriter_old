﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using CSSPModels;
using CSSPEnums;
using CSSPServices;
using CSSPGenerateCodeBase;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter
    {
        private void GenerateGetList2WhereTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() 2 Where");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_2Where_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 0, 10000, """", """", ""{ TypeName }ID,GT,2|{ TypeName }ID,LT,5"", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() 2 Where");
            sb.AppendLine(@"");
        }
    }
}
