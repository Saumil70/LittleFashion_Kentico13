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

[assembly: RegisterDocumentType(FAQs.CLASS_NAME, typeof(FAQs))]

namespace CMS.DocumentEngine.Types.LittleFashion_Kentico13
{
	/// <summary>
	/// Represents a content item of type FAQs.
	/// </summary>
	public partial class FAQs : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "LittleFashion_Kentico13.FAQs";


		/// <summary>
		/// The instance of the class that provides extended API for working with FAQs fields.
		/// </summary>
		private readonly FAQsFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// FAQsID.
		/// </summary>
		[DatabaseIDField]
		public int FAQsID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("FAQsID"), 0);
			}
			set
			{
				SetValue("FAQsID", value);
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
		/// Gets an object that provides extended API for working with FAQs fields.
		/// </summary>
		[RegisterProperty]
		public FAQsFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with FAQs fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class FAQsFields : AbstractHierarchicalObject<FAQsFields>
		{
			/// <summary>
			/// The content item of type FAQs that is a target of the extended API.
			/// </summary>
			private readonly FAQs mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="FAQsFields" /> class with the specified content item of type FAQs.
			/// </summary>
			/// <param name="instance">The content item of type FAQs that is a target of the extended API.</param>
			public FAQsFields(FAQs instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// FAQsID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.FAQsID;
				}
				set
				{
					mInstance.FAQsID = value;
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
		/// Initializes a new instance of the <see cref="FAQs" /> class.
		/// </summary>
		public FAQs() : base(CLASS_NAME)
		{
			mFields = new FAQsFields(this);
		}

		#endregion
	}
}