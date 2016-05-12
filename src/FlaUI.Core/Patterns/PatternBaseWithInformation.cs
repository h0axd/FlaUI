﻿using FlaUI.Core.Elements;
using System;

namespace FlaUI.Core.Patterns
{
    /// <summary>
    /// Base pattern for patterns which have information (properties)
    /// </summary>
    /// <typeparam name="T">Native type of the pattern</typeparam>
    /// <typeparam name="TProp">Type of the information object</typeparam>
    public abstract class PatternBaseWithInformation<TProp> : PatternBase where TProp : InformationBase
    {
        /// <summary>
        /// Cached information for this pattern
        /// </summary>
        public TProp Cached { get; private set; }

        /// <summary>
        /// Current information for this pattern
        /// </summary>
        public TProp Current { get; private set; }

        protected PatternBaseWithInformation(AutomationElement automationElement, object nativePattern, Func<AutomationElement, bool, TProp> createFunc)
            : base(automationElement, nativePattern)
        {
            Cached = createFunc(AutomationElement, true);
            Current = createFunc(AutomationElement, false);
        }
    }
}