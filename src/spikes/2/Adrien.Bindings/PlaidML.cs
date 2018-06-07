using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;

namespace Adrien.Bindings
{
    public class PlaidML : Library
    {
        #region Constructors
        public PlaidML(Dictionary<string, object> options) : base(options)
        {

        }
        #endregion

        #region Properties
        

        #endregion

        #region Overriden members
        public override LibraryKind Kind { get; } = LibraryKind.PlaidML;
        public override void Setup(Driver driver)
        {
            base.Setup(driver);
            this.Module.Headers.Add(Path.Combine(AssemblyDirectory.FullName, "base.h"));
            this.Module.Headers.Add(Path.Combine(AssemblyDirectory.FullName, "plaidml.h"));
            Info("Creating bindings for PlaidML functions...");
        }

        public override void SetupPasses(Driver driver)
        {
            /*
            base.SetupPasses(driver);
            driver.AddTranslationUnitPass(new MKL_IgnoreFortranAndUpperCaseDeclsPass(this, driver.Generator));
            if (WithoutCommon)
            {
                driver.AddTranslationUnitPass(new MKL_IgnoreCommonDeclsPass(this, driver.Generator));
            }
            if (CBlas)
            {
                driver.AddTranslationUnitPass(new MKL_RemoveCBlasFunctionPrefixPass(this, driver.Generator));
            }
            */
        }
        /// Do transformations that should happen before passes are processed.
        public override void Preprocess(Driver driver, ASTContext ctx)
        {


        }

        /// Do transformations that should happen after passes are processed.
        public override void Postprocess(Driver driver, ASTContext ctx)
        {
            
        }

        public override bool CleanAndFixup()
        {
            if (!base.CleanAndFixup())
            {
                return false;
            }

            //string s = File.ReadAllText(F);
           
            return true;
        }

        #endregion
    }
}
