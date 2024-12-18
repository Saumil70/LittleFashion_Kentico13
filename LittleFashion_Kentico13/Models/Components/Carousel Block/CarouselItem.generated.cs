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

[assembly: RegisterDocumentType(CarouselItem.CLASS_NAME, typeof(CarouselItem))]

namespace CMS.DocumentEngine.Types.LittleFashion_Kentico13
{
	/// <summary>
	/// Represents a content item of type CarouselItem.
	/// </summary>
	public partial class CarouselItem : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "LittleFashion_Kentico13.CarouselItem";


		/// <summary>
		/// The instance of the class that provides extended API for working with CarouselItem fields.
		/// </summary>
		private readonly CarouselItemFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// CarouselItemID.
		/// </summary>
		[DatabaseIDField]
		public int CarouselItemID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CarouselItemID"), 0);
			}
			set
			{
				SetValue("CarouselItemID", value);
			}
		}


		/// <summary>
		/// Carousel Image.
		/// </summary>
		[DatabaseField]
		public string CarouselImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CarouselImage"), @"");
			}
			set
			{
				SetValue("CarouselImage", value);
			}
		}


		/// <summary>
		/// Carousel Title.
		/// </summary>
		[DatabaseField]
		public string CarouselTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CarouselTitle"), @"");
			}
			set
			{
				SetValue("CarouselTitle", value);
			}
		}


		/// <summary>
		/// Button Text.
		/// </summary>
		[DatabaseField]
		public string ButtonText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ButtonText"), @"");
			}
			set
			{
				SetValue("ButtonText", value);
			}
		}


		/// <summary>
		/// Button Link.
		/// </summary>
		[DatabaseField]
		public string ButtonLink
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ButtonLink"), @"");
			}
			set
			{
				SetValue("ButtonLink", value);
			}
		}


		/// <summary>
		/// Carousel Description.
		/// </summary>
		[DatabaseField]
		public string CarouselDescription
		{
			get
			{
				return ValidationHelper.GetString(GetValue("CarouselDescription"), @"");
			}
			set
			{
				SetValue("CarouselDescription", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with CarouselItem fields.
		/// </summary>
		[RegisterProperty]
		public CarouselItemFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with CarouselItem fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CarouselItemFields : AbstractHierarchicalObject<CarouselItemFields>
		{
			/// <summary>
			/// The content item of type CarouselItem that is a target of the extended API.
			/// </summary>
			private readonly CarouselItem mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CarouselItemFields" /> class with the specified content item of type CarouselItem.
			/// </summary>
			/// <param name="instance">The content item of type CarouselItem that is a target of the extended API.</param>
			public CarouselItemFields(CarouselItem instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// CarouselItemID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CarouselItemID;
				}
				set
				{
					mInstance.CarouselItemID = value;
				}
			}


			/// <summary>
			/// Carousel Image.
			/// </summary>
			public string CarouselImage
			{
				get
				{
					return mInstance.CarouselImage;
				}
				set
				{
					mInstance.CarouselImage = value;
				}
			}


			/// <summary>
			/// Carousel Title.
			/// </summary>
			public string CarouselTitle
			{
				get
				{
					return mInstance.CarouselTitle;
				}
				set
				{
					mInstance.CarouselTitle = value;
				}
			}


			/// <summary>
			/// Button Text.
			/// </summary>
			public string ButtonText
			{
				get
				{
					return mInstance.ButtonText;
				}
				set
				{
					mInstance.ButtonText = value;
				}
			}


			/// <summary>
			/// Button Link.
			/// </summary>
			public string ButtonLink
			{
				get
				{
					return mInstance.ButtonLink;
				}
				set
				{
					mInstance.ButtonLink = value;
				}
			}


			/// <summary>
			/// Carousel Description.
			/// </summary>
			public string CarouselDescription
			{
				get
				{
					return mInstance.CarouselDescription;
				}
				set
				{
					mInstance.CarouselDescription = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="CarouselItem" /> class.
		/// </summary>
		public CarouselItem() : base(CLASS_NAME)
		{
			mFields = new CarouselItemFields(this);
		}

		#endregion
	}
}