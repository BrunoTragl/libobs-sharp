﻿/***************************************************************************
	Copyright (C) 2014-2015 by Nick Thijssen <lamah83@gmaill.com>

	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, see <http://www.gnu.org/licenses/>.
***************************************************************************/

using System;
using System.ComponentModel;
using System.Diagnostics;

using OBS;

using test.Utility;

namespace test
{
	public class Source : ObsSource
	{
		public Source(string id, string name)
			: base(ObsSourceType.Input, id, name)
		{
			Filters = new BindingList<Filter>();
		}

		public Source(string id, string name, ObsData settings)
			: base(ObsSourceType.Input, id, name, settings)
		{
			Filters = new BindingList<Filter>();
		}

		public Source(IntPtr instance) : base(instance)
		{
		}

		public new void Dispose()
		{
			ClearFilters();
			base.Dispose();
		}

		public BindingList<Filter> Filters { get; set; }

		public void AddFilter(Filter filtersource)
		{
			base.AddFilter(filtersource);
			Filters.Insert(0, filtersource);
		}

		public void RemoveFilter(Filter filter)
		{
			base.RemoveFilter(filter);
			Filters.Remove(filter);
			filter.Remove();
			filter.Dispose();
		}

		public void ClearFilters()
		{
			foreach (Filter filter in Filters)
			{
				base.RemoveFilter(filter);
				filter.Remove();
				filter.Dispose();
			}
			Filters.Clear();
		}

		public int MoveItem(Filter filter, obs_order_movement direction)
		{
			var oldindex = Filters.IndexOf(filter);
			int newindex = -1;
			switch (direction)
			{
				case obs_order_movement.OBS_ORDER_MOVE_UP:
					newindex = oldindex - 1;
					break;
				case obs_order_movement.OBS_ORDER_MOVE_DOWN:
					newindex = oldindex + 1;
					break;
				case obs_order_movement.OBS_ORDER_MOVE_TOP:
					newindex = 0;
					break;
				case obs_order_movement.OBS_ORDER_MOVE_BOTTOM:
					newindex = Filters.Count - 1;
					break;
			}

			SetFilterOrder(filter, direction);

			Filters.Move(oldindex, newindex);

			Debug.WriteLine(String.Format("{0} new index is {1}", filter.Name, newindex));
			return newindex;
		}
	}
}