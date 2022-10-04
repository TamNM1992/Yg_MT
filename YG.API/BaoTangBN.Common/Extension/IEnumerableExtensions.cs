using YG.Common.Extension;
using YG.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static List<T> FilerByField<T>(this List<T> items,string filterField, string filterText)
        {
            var result = items;
            try
            {
                // Filter by field
                // hàm này để filter ví dụ mày có 1 list học sinh lấy ra từ bảng học sinh
                // trên web có 1 ô là ô tìm kiếm theo tên - lớp - khoa - khóa ......
                /// ví dụ tao cần list ra danh sách học sinh có tên là ph...
                /// List<T> items => list học sinh
                /// filterField => ten (thông thường trong DB mình hay để chữ đầu viết hoa Ten, nhưng khi web gửi lên có thể chữ đầu sẽ viết thương ten)
                /// FirstCharToUpper() hàm này giúp chữ cái đầu luôn viết hoa
                /// filterText => ph
                

                // step 1 tìm cái trường có tên là Ten trong class HocSinh
                var prop = typeof(T).GetProperty(filterField.FirstCharToUpper());
                // nếu class học sinh có trường đó prop != null
                if (!string.IsNullOrEmpty(filterText) && prop != null)
                {
                    // thì tìm theo điều kiện where thôi 
                    result = items.Where(x => (prop.GetValue(x, null) != null && !string.IsNullOrEmpty(prop.GetValue(x, null).ToString())
                                           && prop.GetValue(x, null).ToString().ToLower().Contains(filterText.ToLower()))).ToList();
                }
            }
            catch
            {
                // có lỗi thì trả về list gốc
                result = items;
            }

            return result;
        }
        /// <summary>
        /// Sorting với đối tượng là List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">list truyền vào</param>
        /// <param name="sortBy">có 2 chế độ "asc" sorting a->z, từ 1-9: "desc" sorting ngược lại</param>
        /// <param name="sortField">tên của trường cần sort , ví dụ sort theo ten</param>
        /// <returns></returns>
        public static List<T> SortByField<T>(this List<T> items, string sortBy, string sortField)
        {
            // tương tự mình có hàm sort
            var sortList = items;
            try
            {
                // Sort by field
                var prop = typeof(T).GetProperty(sortField.FirstCharToUpper());
                if (prop != null)
                {
                    if (sortBy.ToLower() == "asc")
                    {
                        sortList = items.OrderBy(x => prop.GetValue(x, null)).ToList();
                    }
                    else if (sortBy.ToLower() == "desc")
                    {
                        sortList = items.OrderByDescending(x => prop.GetValue(x, null)).ToList();
                    }
                }
            }
            catch
            {
                sortList = items;
            }

            return sortList;
        }

        /// <summary>
        /// Hàm này để sort ngay khi nó mới được lấy ra từ DB (vẫn ở dạng IQueryable<T> )
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortField"></param>
        /// <returns></returns>
        public static IQueryable<T> SortByField<T>(this IQueryable<T> items, string sortBy, string sortField)
        {
            var sortList = items.ToList();
            try
            {
                // Sort by field
                var prop = typeof(T).GetProperty(sortField.FirstCharToUpper());
                if (prop != null)
                {
                    if (sortBy.ToLower() == "asc")
                    {
                        sortList = sortList.OrderBy(x => prop.GetValue(x, null)).ToList();
                    }
                    else if (sortBy.ToLower() == "desc")
                    {
                        sortList = sortList.OrderByDescending(x => prop.GetValue(x, null)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                sortList = items.ToList();
            }

            return sortList.AsQueryable();
        }

        /// <summary>
        /// Hàm này để paging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">tổng số record</param>
        /// <param name="pageSize">số record hiển thị trong 1 trang => cái này web truyền cho mày</param>
        /// <param name="pageIndex">index trang hiện tại => cía này user click vào số nào thì web truyền cho mày</param>
        /// <returns></returns>
        public static PagingList<T> ConvertToPaging<T>(this List<T> items, int pageSize, int pageIndex)
        {
            PagingList<T> result = new();

            if(items == null || items.Count == 0)
            {
                result.MetaData = new Metadata
                {
                    TotalCount = 0,
                    CurrentPage = pageIndex,
                    TotalPages = 0,
                };
                result.Items = new List<T>();

                return result;
            }

            result.MetaData = new Metadata
            {
                TotalCount = items.Count,
                CurrentPage = pageIndex,
                TotalPages = pageSize == 0 ? 0 : (int)Math.Ceiling((double)items.Count / pageSize),
            };

            // Paging
            var indexFrom = (pageIndex - 1) * pageSize;

            if (pageSize == 0 || pageIndex == 0 || indexFrom > items.Count)
                result.MetaData.Count = 0;
            else
            {
                if (items.Count >= indexFrom + pageSize)
                    result.MetaData.Count = pageSize;
                else
                    result.MetaData.Count = items.Count - indexFrom;
            }
            if (result.MetaData.Count > 0)
            {
                result.Items = items.GetRange(indexFrom, result.MetaData.Count);
            }

            return result;
        }
    }
}
