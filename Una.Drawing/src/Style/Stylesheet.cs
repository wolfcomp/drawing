﻿/* Una.Drawing                                                 ____ ___
 *   A declarative drawing library for FFXIV.                 |    |   \____ _____        ____                _
 *                                                            |    |   /    \\__  \      |    \ ___ ___ _ _ _|_|___ ___
 * By Una. Licensed under AGPL-3.                             |    |  |   |  \/ __ \_    |  |  |  _| .'| | | | |   | . |
 * https://github.com/una-xiv/drawing                         |______/|___|  (____  / [] |____/|_| |__,|_____|_|_|_|_  |
 * ----------------------------------------------------------------------- \/ --- \/ ----------------------------- |__*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Una.Drawing;

public class Stylesheet
{
    internal Dictionary<Rule, Style> Rules = [];

    public Stylesheet(Dictionary<string, Style>? rules = null)
    {
        if (rules is null) return;

        foreach ((string query, Style style) in rules)
            AddRule(query, style);
    }

    /// <summary>
    /// Adds a style rule matching the given query.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="style"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void AddRule(string query, Style style)
    {
        List<QuerySelector> results = QuerySelectorParser.Parse(query);

        foreach (var qs in results)
        {
            // Don't allow nested selectors in a stylesheet. This is a
            // deliberate design choice to keep performance high.
            if (qs.DirectChild is not null || qs.NestedChild is not null)
                throw new InvalidOperationException("A stylesheet rule declaration cannot have nested selectors.");

            Rules.Add(new(qs), style);
        }
    }

    internal class Rule(QuerySelector querySelector)
    {
        public bool Matches(Node node)
        {
            return querySelector.ClassList.All(className => node.ClassList.Contains(className))
                && querySelector.TagList.All(className => node.TagsList.Contains(className));
        }
    }
}
