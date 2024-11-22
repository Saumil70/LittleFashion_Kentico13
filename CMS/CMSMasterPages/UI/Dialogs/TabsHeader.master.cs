﻿using System;
using System.Web.UI.WebControls;

using CMS.Base.Web.UI;
using CMS.UIControls;

public partial class CMSMasterPages_UI_Dialogs_TabsHeader : CMSMasterPage
{
    #region "Properties"

    /// <summary>
    /// Tabs control.
    /// </summary>
    public override UITabs Tabs
    {
        get
        {
            return tabControlElem;
        }
    }


    /// <summary>
    /// PageTitle control.
    /// </summary>
    public override PageTitle Title
    {
        get
        {
            return titleElem;
        }
    }


    /// <summary>
    /// HeaderActions control.
    /// </summary>
    public override HeaderActions HeaderActions
    {
        get
        {
            if (base.HeaderActions != null)
            {
                return base.HeaderActions;
            }
            return actionsElem;
        }
    }


    /// <summary>
    /// Prepared for specifying the additional HEAD elements.
    /// </summary>
    public override Literal HeadElements
    {
        get
        {
            return ltlHeadElements;
        }
        set
        {
            ltlHeadElements = value;
        }
    }


    /// <summary>
    /// Left tabs panel.
    /// </summary>
    public override Panel PanelLeft
    {
        get
        {
            return pnlLeft;
        }
    }


    /// <summary>
    /// Right tabs panel.
    /// </summary>
    public override Panel PanelRight
    {
        get
        {
            return pnlRight;
        }
    }


    /// <summary>
    /// Separator panel.
    /// </summary>
    public override Panel PanelSeparator
    {
        get
        {
            return pnlSeparator;
        }
    }


    /// <summary>
    /// Panel containing title.
    /// </summary>
    public override Panel PanelTitle
    {
        get
        {
            return pnlTitle;
        }
    }


    /// <summary>
    /// Panel containing tab menu control.
    /// </summary>
    public override Panel PanelTabs
    {
        get
        {
            return pnlWhite;
        }
    }


    /// <summary>
    /// Tab master page doesn't hide page title.
    /// </summary>
    public override bool TabMode
    {
        get
        {
            return false;
        }
    }


    /// <summary>
    /// Gets placeholder located after form element.
    /// </summary>
    public override PlaceHolder AfterFormPlaceholder
    {
        get
        {
            return plcAfterForm;
        }
    }

    #endregion


    #region "Page events"

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        PageStatusContainer = plcStatus;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        // Hide actions panel if no actions are present and DisplayActionsPanel is false
        if (!DisplayActionsPanel && !actionsElem.IsVisible())
        {
            pnlActions.Visible = false;
        }

        if (tabControlElem != null)
        {
            string script = "function ReloadAndSetTab(parameter){" + ControlsHelper.GetPostBackEventReference(tabControlElem, "#value#").Replace("'#value#'", "unescape(parameter)") + ";}";
            ScriptHelper.RegisterClientScriptBlock(this, typeof(string), "ReloadAndSetTab", ScriptHelper.GetScript(script));

            // If breadcrumbs are visible, special tabs class will be added
            if (titleElem.Breadcrumbs.Count > 0)
            {
                pnlTabsContainer.CssClass += " BreadTabs";
            }
        }
    }

    #endregion
}
