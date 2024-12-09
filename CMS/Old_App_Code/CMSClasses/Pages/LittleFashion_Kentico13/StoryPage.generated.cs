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

[assembly: RegisterDocumentType(StoryPage.CLASS_NAME, typeof(StoryPage))]

namespace CMS.DocumentEngine.Types.LittleFashion_Kentico13
{
	/// <summary>
	/// Represents a content item of type StoryPage.
	/// </summary>
	public partial class StoryPage : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "LittleFashion_Kentico13.StoryPage";


		/// <summary>
		/// The instance of the class that provides extended API for working with StoryPage fields.
		/// </summary>
		private readonly StoryPageFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// StoryPageID.
		/// </summary>
		[DatabaseIDField]
		public int StoryPageID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("StoryPageID"), 0);
			}
			set
			{
				SetValue("StoryPageID", value);
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
		/// Gets an object that provides extended API for working with StoryPage fields.
		/// </summary>
		[RegisterProperty]
		public StoryPageFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with StoryPage fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class StoryPageFields : AbstractHierarchicalObject<StoryPageFields>
		{
			/// <summary>
			/// The content item of type StoryPage that is a target of the extended API.
			/// </summary>
			private readonly StoryPage mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="StoryPageFields" /> class with the specified content item of type StoryPage.
			/// </summary>
			/// <param name="instance">The content item of type StoryPage that is a target of the extended API.</param>
			public StoryPageFields(StoryPage instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// StoryPageID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.StoryPageID;
				}
				set
				{
					mInstance.StoryPageID = value;
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
		/// Initializes a new instance of the <see cref="StoryPage" /> class.
		/// </summary>
		public StoryPage() : base(CLASS_NAME)
		{
			mFields = new StoryPageFields(this);
		}

		#endregion
	}
}