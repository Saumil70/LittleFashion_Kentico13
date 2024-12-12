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

[assembly: RegisterDocumentType(Inventory.CLASS_NAME, typeof(Inventory))]

namespace CMS.DocumentEngine.Types.LittleFashion_Kentico13
{
	/// <summary>
	/// Represents a content item of type Inventory.
	/// </summary>
	public partial class Inventory : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "LittleFashion_Kentico13.Inventory";


		/// <summary>
		/// The instance of the class that provides extended API for working with Inventory fields.
		/// </summary>
		private readonly InventoryFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// ProductListingID.
		/// </summary>
		[DatabaseIDField]
		public int ProductListingID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("ProductListingID"), 0);
			}
			set
			{
				SetValue("ProductListingID", value);
			}
		}


		/// <summary>
		/// FirstTitle.
		/// </summary>
		[DatabaseField]
		public string FirstTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FirstTitle"), @"");
			}
			set
			{
				SetValue("FirstTitle", value);
			}
		}


		/// <summary>
		/// SecondTitle.
		/// </summary>
		[DatabaseField]
		public string SecondTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("SecondTitle"), @"");
			}
			set
			{
				SetValue("SecondTitle", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Inventory fields.
		/// </summary>
		[RegisterProperty]
		public InventoryFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Inventory fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class InventoryFields : AbstractHierarchicalObject<InventoryFields>
		{
			/// <summary>
			/// The content item of type Inventory that is a target of the extended API.
			/// </summary>
			private readonly Inventory mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="InventoryFields" /> class with the specified content item of type Inventory.
			/// </summary>
			/// <param name="instance">The content item of type Inventory that is a target of the extended API.</param>
			public InventoryFields(Inventory instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// ProductListingID.
			/// </summary>
			public int ProductListingID
			{
				get
				{
					return mInstance.ProductListingID;
				}
				set
				{
					mInstance.ProductListingID = value;
				}
			}


			/// <summary>
			/// FirstTitle.
			/// </summary>
			public string FirstTitle
			{
				get
				{
					return mInstance.FirstTitle;
				}
				set
				{
					mInstance.FirstTitle = value;
				}
			}


			/// <summary>
			/// SecondTitle.
			/// </summary>
			public string SecondTitle
			{
				get
				{
					return mInstance.SecondTitle;
				}
				set
				{
					mInstance.SecondTitle = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Inventory" /> class.
		/// </summary>
		public Inventory() : base(CLASS_NAME)
		{
			mFields = new InventoryFields(this);
		}

		#endregion
	}
}