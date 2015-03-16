using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace System.Web.UI.WebControls
{
    public class MockPagerGrid : GridView
    {
        private int? _mockItemCount;
        private int? _mockPageIndex;

        ///<summary>
        /// Set it to fool the pager item Count
        ///</summary>
        public int MockItemCount
        {
            get
            {
                if (_mockItemCount == null)
                {
                    if (ViewState["MockItemCount"] == null)
                        MockItemCount = Rows.Count;
                    else
                        MockItemCount = (int)ViewState["MockItemCount"];
                }
                return _mockItemCount.Value;
            }
            set
            {
                _mockItemCount = value;
                ViewState["MockItemCount"] = value;
            }
        }

        ///<summary>
        /// Set it to fool the pager page index
        ///</summary>
        public int MockPageIndex
        {
            get
            {
                if (_mockPageIndex == null)
                {
                    if (ViewState["MockPageIndex"] == null)
                        MockPageIndex = PageIndex;
                    else
                        MockPageIndex = (int)ViewState["MockPageIndex"];
                }
                return _mockPageIndex.Value;
            }
            set
            {
                _mockPageIndex = value;
                ViewState["MockPageIndex"] = value;
            }
        }

        ///<summary>
        ///Initializes the pager row displayed when the paging feature is enabled.
        ///</summary>
        ///
        ///<param name="columnSpan">The number of columns the pager row should span. </param>
        ///<param name="row">A <see cref="T:System.Web.UI.WebControls.GridViewRow"></see> that represents the pager row to initialize. </param>
        ///<param name="pagedDataSource">A <see cref="T:System.Web.UI.WebControls.PagedDataSource"></see> that represents the data source. </param>
        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (pagedDataSource.IsPagingEnabled && (MockItemCount != pagedDataSource.VirtualCount))
            {
                pagedDataSource.AllowCustomPaging = true;
                pagedDataSource.VirtualCount = MockItemCount;
                pagedDataSource.CurrentPageIndex = MockPageIndex;
            }
            base.InitializePager(row, columnSpan, pagedDataSource);
        }

        protected override int CreateChildControls
           (System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            PageIndex = MockPageIndex;
            return base.CreateChildControls(dataSource, dataBinding);
        }
    }
}