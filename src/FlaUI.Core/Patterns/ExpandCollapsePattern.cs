﻿using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ExpandCollapsePattern : PatternBaseWithInformation<ExpandCollapsePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse");
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        internal ExpandCollapsePattern(AutomationElement automationElement, UIA.IUIAutomationExpandCollapsePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new ExpandCollapsePatternInformation(element, cached))
        {
        }

        public UIA.IUIAutomationExpandCollapsePattern NativePattern
        {
            get { return (UIA.IUIAutomationExpandCollapsePattern)base.NativePattern; }
        }

        public void Collapse()
        {
            ComCallWrapper.Call(() => NativePattern.Collapse());
        }

        public void Expand()
        {
            ComCallWrapper.Call(() => NativePattern.Expand());
        }
    }

    public class ExpandCollapsePatternInformation : InformationBase
    {
        public ExpandCollapsePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public ExpandCollapseState ExpandCollapseState
        {
            get { return Get<ExpandCollapseState>(ExpandCollapsePattern.ExpandCollapseStateProperty); }
        }
    }
}
