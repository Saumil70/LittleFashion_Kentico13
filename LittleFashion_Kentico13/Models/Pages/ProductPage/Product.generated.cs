//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;

[assembly: RegisterDocumentType(Product.CLASS_NAME, typeof(Product))]

namespace CMS.DocumentEngine.Types.LittleFashion_Kentico13
{
	/// <summary>
	/// Represents a content item of type Product.
	/// </summary>
	public partial class Product : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "LittleFashion_Kentico13.Product";


		/// <summary>
		/// The instance of the class that provides extended API for working with Product fields.
		/// </summary>
		private readonly ProductFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// ProductID.
		/// </summary>
		[DatabaseIDField]
		public int ProductID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("ProductID"), 0);
			}
			set
			{
				SetValue("ProductID", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Product fields.
		/// </summary>
		[RegisterProperty]
		public ProductFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Product fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class ProductFields : AbstractHierarchicalObject<ProductFields>
		{
			/// <summary>
			/// The content item of type Product that is a target of the extended API.
			/// </summary>
			private readonly Product mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="ProductFields" /> class with the specified content item of type Product.
			/// </summary>
			/// <param name="instance">The content item of type Product that is a target of the extended API.</param>
			public ProductFields(Product instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// ProductID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.ProductID;
				}
				set
				{
					mInstance.ProductID = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.Title;
				}
				set
				{
					mInstance.Title = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Product" /> class.
		/// </summary>
		public Product() : base(CLASS_NAME)
		{
			mFields = new ProductFields(this);
		}

		#endregion
	}
}