using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using System.Data.SqlClient;
using System.Data;
using CSSPGenerateCodeBase;
using CSSPModelsGenerateCodeHelper;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter : GenerateCodeBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        protected CSSPDBContext dbCSSPDB { get; set; }
        protected CSSPDBContext dbTestDB { get; set; }
        private ModelsCodeWriter modelsGenerateCodeHelper { get; set; }
        #endregion Properties

        #region Constructors
        /// <summary>
        ///     Constructor
        /// </summary>
        public ServicesCodeWriter()
        {
            dbCSSPDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerCSSPDB);
            dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB);

            modelsGenerateCodeHelper = new ModelsCodeWriter();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
