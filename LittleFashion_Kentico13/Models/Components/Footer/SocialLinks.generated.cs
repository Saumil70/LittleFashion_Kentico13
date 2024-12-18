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

[assembly: RegisterDocumentType(SocialLinks.CLASS_NAME, typeof(SocialLinks))]

namespace CMS.DocumentEngine.Types.LittleFashion_Kentico13
{
	/// <summary>
	/// Represents a content item of type SocialLinks.
	/// </summary>
	public partial class SocialLinks : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "LittleFashion_Kentico13.SocialLinks";


		/// <summary>
		/// The instance of the class that provides extended API for working with SocialLinks fields.
		/// </summary>
		private readonly SocialLinksFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// SocialLinksID.
		/// </summary>
		[DatabaseIDField]
		public int SocialLinksID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("SocialLinksID"), 0);
			}
			set
			{
				SetValue("SocialLinksID", value);
			}
		}


		/// <summary>
		/// Social Link Text.
		/// </summary>
		[DatabaseField]
		public string SocialLinkText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("SocialLinkText"), @"");
			}
			set
			{
				SetValue("SocialLinkText", value);
			}
		}


		/// <summary>
		/// Social Link.
		/// </summary>
		[DatabaseField]
		public string SocialLink
		{
			get
			{
				return ValidationHelper.GetString(GetValue("SocialLink"), @"");
			}
			set
			{
				SetValue("SocialLink", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with SocialLinks fields.
		/// </summary>
		[RegisterProperty]
		public SocialLinksFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with SocialLinks fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class SocialLinksFields : AbstractHierarchicalObject<SocialLinksFields>
		{
			/// <summary>
			/// The content item of type SocialLinks that is a target of the extended API.
			/// </summary>
			private readonly SocialLinks mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="SocialLinksFields" /> class with the specified content item of type SocialLinks.
			/// </summary>
			/// <param name="instance">The content item of type SocialLinks that is a target of the extended API.</param>
			public SocialLinksFields(SocialLinks instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// SocialLinksID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.SocialLinksID;
				}
				set
				{
					mInstance.SocialLinksID = value;
				}
			}


			/// <summary>
			/// Social Link Text.
			/// </summary>
			public string SocialLinkText
			{
				get
				{
					return mInstance.SocialLinkText;
				}
				set
				{
					mInstance.SocialLinkText = value;
				}
			}


			/// <summary>
			/// Social Link.
			/// </summary>
			public string SocialLink
			{
				get
				{
					return mInstance.SocialLink;
				}
				set
				{
					mInstance.SocialLink = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="SocialLinks" /> class.
		/// </summary>
		public SocialLinks() : base(CLASS_NAME)
		{
			mFields = new SocialLinksFields(this);
		}

		#endregion
	}
}